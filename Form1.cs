using System.Diagnostics;
using static sm70_cp_450_GUI.TcpConnectionHandler;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private LogManager? _logManager;
        private TcpConnectionHandler? _tcpHandler;
        private CommandManager? _commandManager;
        private string? _SaveLocationCSV;
        private string? _SaveLocationLOG;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static MainForm? Instance { get; set; }

        private readonly Stopwatch _stopwatch = new();

        private enum SequenceSteps
        {
            idle,
            Charging,
            Discharging,
        }

        private SequenceSteps CurrentStep = SequenceSteps.idle;
        private SequenceSteps lastknownstep;

        public bool _ConsoleState = false;
        private bool DataSet = false;

        private double _ReadVoltage;
        private double _ReadCurrent;
        private double _ReadPower;

        public double _BulkVoltage;
        public double _MinimumVoltage;
        public double _Capacity;
        public double _MaxCurrent;
        public double _MinCurrent;
        public double _MaxPower;
        public double _MinPower;

        public double _ExpectedSoc;
        public double _TriggerPercentValue;
        public double _TriggerPercent;
        public TimeSpan _TriggerTime;

        private double _lastRecordedVoltage = double.MinValue;
        private double _lastRecordedCurrent = double.MinValue;

        private const double VoltageThreshold = 0.1; // Change in voltage in V to be considered significant
        private const double CurrentThreshold = 0.5; // Change in current in A to be considered significant


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


            InitializeFullCycleBatteryChart();
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
        private void InitializeFullCycleBatteryChart()
        {
            liveBatteryChart.Series.Clear();
            ChartArea chartArea = new()
            {
                Name = "BatteryChartArea",
                AxisX = { Title = "Time", LabelStyle = { Format = "HH:mm:ss" } },
                AxisY = { Title = "Voltage (V) / Current (A)" }
            };
            liveBatteryChart.ChartAreas.Add(chartArea);

            Series voltageSeries = new()
            {
                Name = "Voltage",
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.Blue
            };

            Series currentSeries = new()
            {
                Name = "Current",
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.Green
            };

            Series cvModeSeries = new()
            {
                Name = "Constant Voltage Mode",
                ChartType = SeriesChartType.Point,
                XValueType = ChartValueType.DateTime,
                Color = Color.Purple,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            Series ccModeSeries = new()
            {
                Name = "Constant Current Mode",
                ChartType = SeriesChartType.Point,
                XValueType = ChartValueType.DateTime,
                Color = Color.Orange,
                MarkerStyle = MarkerStyle.Triangle,
                MarkerSize = 8
            };

            Series dischargeSeries = new()
            {
                Name = "Discharge Mode",
                ChartType = SeriesChartType.Point,
                XValueType = ChartValueType.DateTime,
                Color = Color.Red,
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 8
            };

            liveBatteryChart.Series.Add(voltageSeries);
            liveBatteryChart.Series.Add(currentSeries);
            liveBatteryChart.Series.Add(cvModeSeries);
            liveBatteryChart.Series.Add(ccModeSeries);
            liveBatteryChart.Series.Add(dischargeSeries);
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
                _ReadVoltage = _tcpHandler.MeasuredVoltage;
                _ReadCurrent = _tcpHandler.MeasuredCurrent;
                _ReadPower = _tcpHandler.MeasuredPower;

                VoltageDisplay.Text = $"{_ReadVoltage} V";
                AmperageDisplay.Text = $"{_ReadCurrent} A";
                WattageDisplay.Text = $"{_ReadPower} W";
                Label_Remote_CV_UI.Text = _tcpHandler.SystemRemoteSettingVoltage;
                Label_Remote_CC_UI.Text = _tcpHandler.SystemRemoteSettingCurrent;
                Label_Remote_CP_UI.Text = _tcpHandler.SystemRemoteSettingPower;

                _logManager?.CollectBatteryMetrics(_ReadVoltage, _ReadCurrent, _ReadPower, (int)_ExpectedSoc);

                bool voltageSignificantChange = Math.Abs(_ReadVoltage - _lastRecordedVoltage) > VoltageThreshold;
                bool currentSignificantChange = Math.Abs(_ReadCurrent - _lastRecordedCurrent) > CurrentThreshold;

                if (voltageSignificantChange || currentSignificantChange)
                {
                    DateTime now = DateTime.Now;

                    _lastRecordedVoltage = _ReadVoltage;
                    _lastRecordedCurrent = _ReadCurrent;

                    liveBatteryChart.Series["Voltage"].Points.AddXY(now, _ReadVoltage);
                    liveBatteryChart.Series["Current"].Points.AddXY(now, _ReadCurrent);

                    if (CurrentStep == SequenceSteps.Charging)
                    {
                        if (_ReadCurrent <= _TriggerPercentValue)
                        {
                            liveBatteryChart.Series["Constant Voltage Mode"].Points.AddXY(now, _ReadVoltage);
                        }
                        else
                        {
                            liveBatteryChart.Series["Constant Current Mode"].Points.AddXY(now, _ReadCurrent);
                        }
                    }
                    else if (CurrentStep == SequenceSteps.Discharging)
                    {
                        liveBatteryChart.Series["Discharge Mode"].Points.AddXY(now, _ReadCurrent);
                    }

                    // Refresh the chart to reflect changes
                    liveBatteryChart.Invalidate();
                }
            }
        }

        private void StandardUpdate(object sender, EventArgs e)
        {
            if (_tcpHandler == null || _tcpHandler.ConnectionState != ConnectionStates.Established) return;
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
            LiveInfoData.Text = $"SM70-CP-450 Connection Status: {_tcpHandler.ConnectionState}"; 
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
                    Console_Simple_Textbox_UI.AppendText($"{logEntry.Time:HH:mm:ss} - {logEntry.Message} (Count: {logEntry.Count}){Environment.NewLine}");
                }
                Console_Simple_Textbox_UI.ScrollToCaret();
            }
        }

        private void StateManager()
        {
            if (_tcpHandler == null || _tcpHandler.ConnectionState != ConnectionStates.Established || !DataSet) return;

            Label_TriggerActualTime.Text = _stopwatch.Elapsed.Seconds.ToString();
            Progressbar_TriggerTime.Value = (100 / _TriggerTime.Seconds * _stopwatch.Elapsed.Seconds);

            switch (CurrentStep)
            {
                case SequenceSteps.idle:
                    SetValuesToMachine(_BulkVoltage, 2, 2, 2, 2);
                    radioButton1.Checked = true;
                    break;
                case SequenceSteps.Charging:
                    radioButton2.Checked = true;
                    HandleCharging();
                    break;
                case SequenceSteps.Discharging:
                    radioButton3.Checked = true;
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

        //warn user / disconnect socket before closing 
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_tcpHandler != null && _tcpHandler.ConnectionState == ConnectionStates.Established)
            {
                var result = MessageBox.Show("Closing the application will terminate the connection. Do you want to proceed?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                e.Cancel = true;

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

        //handles (almost) every onClick action
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
                    case "setData":
                        SaveInitialBatterySettings();
                        break;
                    case "Start":
                        if (_tcpHandler != null && _tcpHandler.ConnectionState == ConnectionStates.Established)
                        {
                            if (lastknownstep == SequenceSteps.idle) lastknownstep = SequenceSteps.Charging;
                            CurrentStep = lastknownstep;
                            _commandManager?.SetOutputState(true);
                        }
                        break;
                    case "Stop":
                        if (_tcpHandler != null && _tcpHandler.ConnectionState == ConnectionStates.Established)
                        {
                            lastknownstep = CurrentStep;
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
                        ToggleConsole_Btn.Text = _ConsoleState ? "Close console" : "Open console";
                        ConsoleBox.Height = _ConsoleState ? ConsoleBox.MaximumSize.Height : ConsoleBox.MinimumSize.Height;
                        Console_Simple_Textbox_UI.Visible = _ConsoleState;
                        break;
                    case "ClearConsole":
                        Console_Simple_Textbox_UI.Text = "";
                        Console_Short_ErrorLabel.Text = "This is where error should appear if there are any";
                        break;
                    case "TryConnectSocket":
                        if (_tcpHandler != null && _tcpHandler.ConnectionState != ConnectionStates.Established)
                        {
                            await _tcpHandler.InitializeTcpClient();
                        }
                        break;
                    case "DisconnectSocket":
                        if (_tcpHandler != null && _tcpHandler.ConnectionState == ConnectionStates.Established)
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
