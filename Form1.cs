using System.Diagnostics;
using System.Text.Json;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private LogManager? _logManager;
        private TcpConnectionHandler? _tcpHandler;
        private CommandManager? _commandManager;
        private string? _SaveLocationCSV;
        private string? _SaveLocationLOG;

        public static MainForm? Instance { get; set; }

        private readonly Stopwatch _stopwatch = new();

        private enum SequenceSteps
        {
            idle,
            Charging,
            Discharging,
        }

        private SequenceSteps CurrentStep = SequenceSteps.idle;

        public bool _ConsoleState = false;
        private bool DataSet = false;

        private double _ReadVoltage;
        private double _ReadCurrent;
        private double _ReadPower;

        private double _BulkVoltage;
        private double _MinimumVoltage;
        private double _Capacity;
        private double _MaxCurrent;
        private double _MinCurrent;
        private double _MaxPower;
        private double _MinPower;

        private double _ExpectedSoc;
        private double _TriggerPercentValue;
        private double _TriggerPercent;
        private TimeSpan _TriggerTime;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            Load += MainForm_Init;
        }

        private void MainForm_Init(object? sender, EventArgs? e)
        {
            _tcpHandler = TcpConnectionHandler.Instance;
            _commandManager = CommandManager.Instance;
            _logManager = LogManager.Instance;

            if (_tcpHandler != null)
            {
                _tcpHandler.OnConnectionLost += HandleConnectionLost;
            }

            if (_logManager != null)
            {
                _logManager.OnLogUpdate += LogManager_OnLogUpdate;
            }

            toolStripMenuSetting_keepSessionData.Checked = Properties.Settings.Default._KeepMemory;
            _SaveLocationCSV = Properties.Settings.Default.SaveLocationCSV;
            _SaveLocationLOG = Properties.Settings.Default.SaveLocationLOG;

            Show();
        }

        private void HandleConnectionLost()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(HandleConnectionLost));
            }
            else
            {
                VoltageDisplay.Text = "N/A";
                AmperageDisplay.Text = "N/A";
                WattageDisplay.Text = "N/A";
                Label_Remote_CV_UI.Text = "N/A";
                Label_Remote_CC_UI.Text = "N/A";
                Label_Remote_CP_UI.Text = "N/A";
            }
        }

        public void UpdateAllUIFields()
        {
            if (_tcpHandler == null) return;

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateAllUIFields));
            }
            else
            {
                // Update the UI fields with the current values from TcpConnectionHandler
                _ReadVoltage = _tcpHandler.MeasuredVoltage;
                _ReadCurrent = _tcpHandler.MeasuredCurrent;
                _ReadPower = _tcpHandler.MeasuredPower;

                Label_Remote_CV_UI.Text = _tcpHandler.SystemRemoteSettingVoltage;
                Label_Remote_CC_UI.Text = _tcpHandler.SystemRemoteSettingCurrent;
                Label_Remote_CP_UI.Text = _tcpHandler.SystemRemoteSettingPower;

                VoltageDisplay.Text = $"{_ReadVoltage} V";
                AmperageDisplay.Text = $"{_ReadCurrent} A";
                WattageDisplay.Text = $"{_ReadPower} W";
                Label_MachineAppliedVoltage_UI.Text = $"{_tcpHandler.SourceVoltage} V";
                Label_MachineAppliedCurrentPlus_UI.Text = $"{_tcpHandler.SourceCurrent} A";
                Label_MachineAppliedPowerPlus_UI.Text = $"{_tcpHandler.SourcePower} W";
                Label_MachineAppliedCurrentMin_UI.Text = $"{_tcpHandler.SourceNegativeCurrent} A";
                Label_MachineAppliedPowerMin_UI.Text = $"{_tcpHandler.SourceNegativePower} W";
            }
        }

        private void StandardUpdate(object sender, EventArgs e)
        {
            if (_tcpHandler == null || !_tcpHandler.IsConnected) return;
            _commandManager?.Request_Measure_Voltage();
            _commandManager?.Request_Measure_Current();
            _commandManager?.Request_Measure_Power();
            _commandManager?.Request_Source_Voltage();
            _commandManager?.Request_Source_Current();
            _commandManager?.Request_Source_Power();
            _commandManager?.Request_Source_Current_Negative();
            _commandManager?.Request_Source_Power_Negative();
            StateManager();
        }

        private void LateUpdate(object sender, EventArgs e)
        {
            if (_tcpHandler == null) return;
            LiveInfoData.Text = $"SM70-CP-450 Controller Status: {(_tcpHandler.IsConnected ? "Connected" : "Not Connected")}";
            _commandManager?.RequestRemoteSetting_CV();
            _commandManager?.RequestRemoteSetting_CC();
            _commandManager?.RequestRemoteSetting_CP();
        }

        private void LogManager_OnLogUpdate(List<LogManager.LogEntry> logEntries)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogManager_OnLogUpdate(logEntries)));
            }
            else
            {
                Console_Simple_Textbox_UI.Clear();

                foreach (var logEntry in logEntries)
                {
                    Console_Simple_Textbox_UI.SelectionColor = logEntry.DisplayColor;
                    Console_Simple_Textbox_UI.AppendText($"{logEntry.Time:yyyy-MM-dd HH:mm:ss} - {logEntry.Message} (Count: {logEntry.Count}){Environment.NewLine}");
                }

                Console_Simple_Textbox_UI.ScrollToCaret();
            }
        }

        private void StateManager()
        {
            if (_tcpHandler == null || !_tcpHandler.IsConnected || !DataSet) return;

            Label_TriggerActualTime.Text = _stopwatch.Elapsed.Seconds.ToString();

            switch (CurrentStep)
            {
                case SequenceSteps.idle:
                    SetValuesToMachine(_BulkVoltage, 2, 2, 2, 2);
                    tabControl1.SelectedTab = Tab_IdlePage;
                    break;
                case SequenceSteps.Charging:
                    tabControl1.SelectedTab = Tab_ChargePage;
                    HandleCharging();
                    break;
                case SequenceSteps.Discharging:
                    tabControl1.SelectedTab = Tab_DischargePage;
                    HandleDischarging();
                    break;
                default:
                    _logManager?.AddErrorLogMessage("StateManager: Unknown sequence step.");
                    break;
            }
        }

        private void HandleCharging()
        {
            SetValuesToMachine(_BulkVoltage);
            if (_ReadVoltage >= _BulkVoltage)
            {
                if (_ReadCurrent <= _TriggerPercentValue)
                {
                    _stopwatch.Start();
                    checkBox1.Checked = true;
                    if (_stopwatch.IsRunning && _stopwatch.Elapsed >= _TriggerTime)
                    {
                        CurrentStep = SequenceSteps.Discharging;
                        _logManager?.AddInfoLogMessage("StateManager_HC: Battery fully charged. Switching to discharge mode.");
                        checkBox1.Checked = false;
                    }
                }
                else
                {
                    checkBox1.Checked = false;
                    _stopwatch.Reset();
                }
            }
        }

        private void HandleDischarging()
        {
            SetValuesToMachine(_MinimumVoltage);

            double elapsedHours = _stopwatch.Elapsed.TotalHours;
            double accumulatedCharge = Math.Max(0, _Capacity - (Math.Abs(_ReadCurrent) * elapsedHours));
            double dischargeSOC = (accumulatedCharge / _Capacity) * 100;

            Label_AccumulatedCharge.Text = ($"AccumulatedCharge: {accumulatedCharge}A");
            Label_KnownSOC.Text = ($"Soc: {dischargeSOC}%");

            if (dischargeSOC <= _ExpectedSoc)
            {
                _stopwatch.Stop();
                CurrentStep = SequenceSteps.idle;
                _logManager?.AddInfoLogMessage($"StateManager_HD: Target SOC {_ExpectedSoc}% reached. Stopping discharge.");
            }
        }

        private void SetValuesToMachine(double voltage, double amp = 0, double ampNeg = 0, double power = 0, double powerNeg = 0)
        {
            amp = amp == 0 ? _MaxCurrent : amp;
            ampNeg = ampNeg == 0 ? _MinCurrent : ampNeg;
            power = power == 0 ? _MaxPower : power;
            powerNeg = powerNeg == 0 ? _MinPower : powerNeg;

            _commandManager?.SetOutputVoltage(voltage);
            _commandManager?.SetOutputCurrent(amp);
            _commandManager?.SetOutputCurrentNegative(ampNeg);
            _commandManager?.SetOutputPower(power);
            _commandManager?.SetOutputPowerNegative(powerNeg);
        }


        private void ManualSetValues()
        {
            _BulkVoltage = UtilityBase.ParseInput(InputField_StoredValueVoltage.Text);
            _MaxCurrent = UtilityBase.ParseInput(InputField_StoredValueCurrentPlus.Text);
            _MinCurrent = UtilityBase.ParseInput(InputField_StoredValueCurrentMin.Text);
            _MaxPower = UtilityBase.ParseInput(InputField_StoredValuePowerPlus.Text);
            _MinPower = UtilityBase.ParseInput(InputField_StoredValuePowerMin.Text);
            DataSet = true;
        }

        private void SaveInitialBatterySettings()
        {
            _BulkVoltage = UtilityBase.ParseInput(Textbox_BulkVoltage.Text);
            _MinimumVoltage = UtilityBase.ParseInput(Textbox_CutoffVoltage.Text);
            _Capacity = UtilityBase.ParseInput(Textbox_Capacity.Text);
            _MaxCurrent = UtilityBase.ParseInput(Textbox_MaxCurrent.Text);
            _MinCurrent = -Math.Abs(UtilityBase.ParseInput(Textbox_MinCurrent.Text));
            _MaxPower = _MaxCurrent * _BulkVoltage;
            _MinPower = -Math.Abs(_MinCurrent * _MinimumVoltage);
            _ExpectedSoc = UtilityBase.ParseInput(Textbox_ExpectedSoc.Text);
            _TriggerPercent = UtilityBase.ParseInput(Textbox_TriggerPercent.Text);
            _TriggerTime = TimeSpan.FromSeconds(UtilityBase.ParseInput(Textbox_TriggerTime.Text));
            _TriggerPercentValue = (_MaxCurrent / 100 * _TriggerPercent);

            // Update UI Labels with new settings
            Label_Volt.Text = _BulkVoltage.ToString();
            Label_CutVolt.Text = _MinimumVoltage.ToString();
            Label_Cap.Text = _Capacity.ToString();
            Label_MaxCurr.Text = $"{_MaxCurrent}A / {_MaxPower}W";
            Label_MinCurr.Text = $"{_MinCurrent}A / {_MinPower}W";
            Label_Soc.Text = _ExpectedSoc.ToString();
            Label_trigger.Text = $"{_TriggerPercent}% = {_TriggerPercentValue}A";
            Label_TriggerTime.Text = _TriggerTime.ToString();

            DataSet = true;
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tcpHandler != null && _tcpHandler.IsConnected)
            {
                // Notify user that the application is attempting to close the connection first
                var result = MessageBox.Show("Closing the application will terminate the connection. Do you want to proceed?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                // Prevent the application from closing until the connection is properly terminated
                e.Cancel = true;

                // Attempt to close the TCP connection
                try
                {
                    await _tcpHandler.CloseConnectionAsync();
                    e.Cancel = false;
                    Close();
                }
                catch (Exception ex)
                {
                    _logManager?.AddErrorLogMessage($"Failed to close the connection: {ex.Message}");
                }
            }
        }
        private async void ButtonHandler(object sender, EventArgs e)
        {
            string? tag = null;
            string? name = null;

            if (sender is Control control)
            {
                tag = control.Tag as string;
                name = control.Name;
            }
            else if (sender is ToolStripItem toolStripItem)
            {
                tag = toolStripItem.Tag as string;
                name = toolStripItem.Name;
            }

            if (tag != null)
            {
                switch (tag)
                {
                    case "ManualSetValues":
                        ManualSetValues();
                        break;
                    case "setData":
                        SaveInitialBatterySettings();
                        break;
                    case "OpenManualForm":
                        new ManualForm().Show();
                        break;
                    case "OpenSequencer":
                        new UpdatedForm().Show();
                        break;
                    case "Start":
                        if (_tcpHandler != null && _tcpHandler.IsConnected)
                        {
                            CurrentStep = SequenceSteps.Charging;
                            _commandManager?.SetOutputState(true);
                        }
                        break;
                    case "Stop":
                        if (_tcpHandler != null && _tcpHandler.IsConnected)
                        {
                            CurrentStep = SequenceSteps.idle;
                            _commandManager?.SetOutputState(false);
                        }
                        break;
                    case "SaveSettings":
                        _logManager?.ExportSettings(false, "Settings");
                        break;
                    case "LoadSettings":
                        _logManager?.ImportSettings("test1");
                        break;
                    case "SaveCSV":
                        _logManager?.ExportToCsv(false, _SaveLocationCSV);
                        break;
                    case "SaveAsCSV":
                        _logManager?.ExportToCsv(true, null);
                        break;
                    case "SaveLOG":
                        _logManager?.ExportLogToFile(false, _SaveLocationLOG);
                        break;
                    case "SaveAsLOG":
                        _logManager?.ExportLogToFile(true, null);
                        break;
                    case "ToggleConsole":
                        _ConsoleState = !_ConsoleState;
                        ToggleConsole_Btn.Text = _ConsoleState ? "Open console" : "Close console";
                        ConsoleBox.Height = _ConsoleState ? ConsoleBox.MaximumSize.Height : ConsoleBox.MinimumSize.Height;
                        Console_Simple_Textbox_UI.Visible = _ConsoleState;
                        break;
                    case "ClearConsole":
                        Console_Simple_Textbox_UI.Text = "";
                        Console_Short_ErrorLabel.Text = "This is where error should appear if there are any";
                        break;
                    case "TryConnectSocket":
                        if (_tcpHandler != null && !_tcpHandler.IsConnected)
                        {
                            await _tcpHandler.InitializeTcpClient();
                        }
                        break;
                    case "DisconnectSocket":
                        if (_tcpHandler != null && _tcpHandler.IsConnected)
                        {
                            await _tcpHandler.CloseConnectionAsync();
                        }
                        break;
                    case "ToggleSessionData":
                        Properties.Settings.Default._KeepMemory = toolStripMenuSetting_keepSessionData.Checked;
                        Properties.Settings.Default.Save();
                        break;
                    case "OpenDeltaURL":
                    case "OpenGitURL":
                        if (name != null)
                        {
                            UtilityBase.OpenURL(name);
                        }
                        break;
                    default:
                        _logManager?.AddErrorLogMessage($"Tag: {tag}, not recognized");
                        break;
                }
            }
        }
    }
}
