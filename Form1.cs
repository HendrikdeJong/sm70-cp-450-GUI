using System.Diagnostics;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private LogManager? logManager;
        private TcpConnectionHandler? _tcpHandler;
        private BatteryManager? _batteryManager;
        private CommandManager? _commandManager;
        private string? _SaveLocationCSV;
        private string? _SaveLocationLOG;


        public static MainForm? Instance { get; private set; }

        private Timer? errorCleanupTimer;


        public bool _ConsoleState = false;
        private bool _EditingValues = false;
        private AvailablePrograms _SelectedProgram = AvailablePrograms.None;

        private double _ratedVoltage = 0;
        private double _ratedCapacity = 0;
        private double _ratedPower = 0;
        private double _cRating = 0;

        public double currentVoltage = 0;
        public double currentCurrent = 0;
        public double currentPower = 0;

        private TimeSpan _timeSinceLastSave = TimeSpan.Zero;
        private readonly Stopwatch _stopwatch = new();
        private TimeSpan? EstimateTotalTime;

        private double _StoredVoltageSetting = 0;
        private double _StoredCurrent = 0;
        private double _StoredPower = 0;
        private double _StoredNegativeCurrent = 0;
        private double _StoredNegativePower = 0;

        private double _TEMPCurrent = 0;
        private double _TEMPPower = 0;
        private double _TEMPNegativeCurrent = 0;
        private double _TEMPNegativePower = 0;

        public Dictionary<string, Action<string>> _commandToUIActions;

        private bool _started = false;
        private bool _OngoingOperation = false;
        private enum AvailablePrograms
        {
            None,
            Charging,
            Discharging,
            DischargingTo30,
        }

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            Load += MainForm_Load;

            // UI actions associated with commands
            _commandToUIActions = new Dictionary<string, Action<string>>
            {
                { "MEASure:VOLtage?", (response) => {VoltageDisplay.Text = response + " V";     currentVoltage = double.Parse(response);}},
                { "MEASure:CURrent?", (response) => {AmperageDisplay.Text = response + " A";    currentCurrent = double.Parse(response);}},
                { "MEASure:POWer?", (response) => {WattageDisplay.Text = response + " W";    currentPower = double.Parse(response);}},

                { "SOURce:VOLtage?", (response) => Label_MachineAppliedVoltage_UI.Text = response + " V" },
                { "SOURce:CURrent?", (response) => Label_MachineAppliedCurrentPlus_UI.Text = response + " A" },
                { "SOURce:POWer?", (response) => Label_MachineAppliedPowerPlus_UI.Text = response + " W" },
                { "SOURce:CURrent:NEGative?", (response) => Label_MachineAppliedCurrentMin_UI.Text = response + " A" },
                { "SOURce:POWer:NEGative?", (response) => Label_MachineAppliedPowerMin_UI.Text = response + " W" },

                { "SYSTem:REMote:CV?", (response) => Label_Remote_CV_UI.Text = response},
                { "SYSTem:REMote:CC?", (response) => Label_Remote_CC_UI.Text = response},
                { "SYSTem:REMote:CP?", (response) => Label_Remote_CP_UI.Text = response},

                { "SYSTem:LIMits:VOLtage?", (response) => LimitLabel_01.Text = response  + " V" },
                { "SYSTem:LIMits:CURrent?", (response) => LimitLabel_02.Text = response  + " A" },
                { "SYSTem:LIMits:POWEr?", (response) => LimitLabel_03.Text = response  + " W" },
                { "SYSTem:LIMits:CURrent:NEGative?", (response) => LimitLabel_04.Text = "-" + response  + " A" },
                { "SYSTem:LIMits:POWer:NEGative?", (response) => LimitLabel_05.Text = "-" + response + " W"},
            };
            Timers();
        }

        private void MainForm_Load(object? sender, EventArgs? e)
        {
            _commandManager = CommandManager.Instance;
            logManager = LogManager.Instance;
            _tcpHandler = TcpConnectionHandler.Instance;
            _batteryManager = BatteryManager.Instance;
            logManager.OnLogUpdate += LogManager_OnLogUpdate;




            if (Properties.Settings.Default._KeepMemory == true)
            {
                UpdateUIFromSettings();
            }
            toolStripMenuSetting_keepSessionData.Checked = Properties.Settings.Default._KeepMemory;
            _SaveLocationCSV = Properties.Settings.Default.SaveLocationCSV;
            _SaveLocationLOG = Properties.Settings.Default.SaveLocationLOG;

            Timers();
            Show();
        }

        private void LogManager_OnLogUpdate(string logMessage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => LogManager_OnLogUpdate(logMessage)));  // Ensure it's invoked on the UI thread
            }
            else
            {
                Console_Simple_Textbox_UI.Text = logMessage;  // Update the UI with the log message
            }
        }

        private void UpdateUIFromSettings()
        {

            _ratedVoltage = Properties.Settings.Default._ratedVoltage;
            _ratedCapacity = Properties.Settings.Default._ratedCapacity;
            _ratedPower = Properties.Settings.Default._ratedPower;
            _cRating = Properties.Settings.Default._cRating;

            _StoredVoltageSetting = Properties.Settings.Default._StoredVoltageSetting;
            _StoredCurrent = Properties.Settings.Default._StoredCurrent;
            _StoredPower = Properties.Settings.Default._StoredPower;

            _StoredNegativeCurrent = Properties.Settings.Default._StoredNegativeCurrent;
            _StoredNegativePower = Properties.Settings.Default._StoredNegativePower;


            RatedBatteryVoltageUI.Text = _ratedVoltage.ToString();
            RatedBatteryAmperageUI.Text = _ratedCapacity.ToString();
            C_Rating_UI.Text = _cRating.ToString();

            // Update your UI elements with loaded values
            InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
            InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
            InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
            InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
            InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";
        }

        private void Timers()
        {
            Timer? updateTimer = new()
            {
                Interval = 1000
            };
            updateTimer.Tick += (sender, e) =>
            {
                _commandManager?.Request_Measure_Voltage();
                _commandManager?.Request_Measure_Current();
                _commandManager?.Request_Measure_Power();

                _commandManager?.Request_Source_Voltage();
                _commandManager?.Request_Source_Current();
                _commandManager?.Request_Source_Power();
                _commandManager?.Request_Source_Current_Negative();
                _commandManager?.Request_Source_Power_Negative();

                //_commandManager?.RequestTime();
                StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();

                // Always update the elapsed time display
                if (_stopwatch.IsRunning)
                {
                    _OngoingOperation = true;
                    _timeSinceLastSave = _timeSinceLastSave.Add(TimeSpan.FromSeconds(1)); // Increment by 1 second

                    if (_timeSinceLastSave.TotalSeconds >= 5)  // Check if 5 seconds have passed
                    {
                        logManager?.CollectBatteryMetrics(currentVoltage, currentCurrent, currentPower);
                        _timeSinceLastSave = TimeSpan.Zero;  // Reset the timer
                    }


                    TimeSpan elapsed = _stopwatch.Elapsed;

                    TimeSpan _TimeRemaining = ((EstimateTotalTime ?? TimeSpan.Zero) - elapsed);

                    Label_Total_Time_UI.Text = $"{_TimeRemaining.Hours:D2}:{_TimeRemaining.Minutes:D2}:{_TimeRemaining.Seconds:D2}";
                    Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";

                    // Check if the remaining time is less than or equal to zero
                    if (_TimeRemaining <= TimeSpan.Zero)
                    {
                        _OngoingOperation = false;
                        _stopwatch.Stop();  // Stop the stopwatch
                        //ToggleOutput();
                        _tcpHandler?.EnqueueCommand("SYSTem:FROntpanel:HIGhlight");
                        MessageBox.Show("Time is up! The machine has been stopped.");
                    }
                } else _OngoingOperation = false;
            };

            Timer? LateUpdate = new()
            {
                Interval = 10000 // 10 second interval
            };
            LateUpdate.Tick += (sender, e) =>
            {
                LiveInfoData.Text = $"SM70-CP-450 Controller Status:{(_tcpHandler == null ? " Not initialized" : (_tcpHandler.IsConnected ? " Connected" : " Not Connected"))}";
                _commandManager?.RequestRemoteSetting_CV();
                _commandManager?.RequestRemoteSetting_CC();
                _commandManager?.RequestRemoteSetting_CP();

                _commandManager?.RequestSystemVoltageLimit();
                _commandManager?.RequestSystemCurrentLimit();
                _commandManager?.RequestSystemPowerLimit();
                _commandManager?.RequestSystemNegCurrentLimit();
                _commandManager?.RequestSystemNegPowerLimit();
            };


            LateUpdate.Start();
            updateTimer.Start();
            if (logManager != null)
            {
                errorCleanupTimer = new Timer
                {
                    Interval = 1000 // 1 second interval
                };
                errorCleanupTimer.Tick += (sender, e) => logManager.UpdateConsole();
                errorCleanupTimer.Start();
            }
        }

        private void ToggleManualEditing(object sender, EventArgs e)
        {
            _EditingValues = !_EditingValues;
            InputField_StoredValueVoltage.ReadOnly = !_EditingValues;
            InputField_StoredValueCurrentPlus.ReadOnly = !_EditingValues;
            InputField_StoredValuePowerPlus.ReadOnly = !_EditingValues;
            InputField_StoredValueCurrentMin.ReadOnly = !_EditingValues;
            InputField_StoredValuePowerMin.ReadOnly = !_EditingValues;

            if (_EditingValues)
            {
                Button_Toggle_ValueEditor.Text = "Save And Update Values";
                //UpdateFromManualOverride();
            }
            else
            {
                Button_Toggle_ValueEditor.Text = "Edit Values";
                UpdateFromManualOverride();
            }
        }
        private void UpdateFromManualOverride()
        {
            InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
            InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
            InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
            InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
            InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";
            _StoredVoltageSetting = ParseInput(InputField_StoredValueVoltage.Text);
            _StoredCurrent = ParseInput(InputField_StoredValueCurrentPlus.Text);
            _StoredPower = ParseInput(InputField_StoredValuePowerPlus.Text);
            _StoredNegativeCurrent = ParseInput(InputField_StoredValueCurrentMin.Text);
            _StoredNegativePower = ParseInput(InputField_StoredValuePowerMin.Text);
            SaveSettings(_StoredVoltageSetting, _StoredCurrent, _StoredPower, _StoredNegativeCurrent, _StoredNegativePower);
        }
        private void SaveSettings(double V, double A, double W, double N_A, double N_W)
        {
            _StoredVoltageSetting = V;
            _StoredCurrent = A;
            _StoredPower = W;
            _StoredNegativeCurrent = N_A;
            _StoredNegativePower = N_W;

            _batteryManager?.SaveSettings(V, A, W, N_A, N_W);

            InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
            InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
            InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
            InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
            InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";
        }
        private void UpdateFromBatteryLabelData(object sender, EventArgs e)
        {
            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryAmperageUI.Text);
            _cRating = ParseInput(C_Rating_UI.Text);

            _batteryManager?.SetBatterySettings(_ratedVoltage, _ratedCapacity, _cRating);
            CalculateWithCRating();
        }
        private void CalculateWithCRating()

        {
            double amps = _ratedCapacity * _cRating;  // How much current can be applied safely
            double watts = amps * _ratedVoltage;      // Power in watts
            _ratedPower = watts;

            SaveSettings(_ratedVoltage, amps, watts, -amps, -watts);
        }
        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',').ToArray());
        }
        private double ParseInput(string input)
        {
            return double.TryParse(RemoveNonNumeric(input), out double result) ? result : 0;
        }

        private void SelectOperation(Object sender, EventArgs e)
        {
            _commandManager?.SetOutputVoltage(_StoredVoltageSetting);

            if (sender is CheckBox _CheckBox)
            {
                if (_CheckBox.Name == "Operation_ConnectBattery_Override")
                {
                    if (!_started || _OngoingOperation)
                    {
                        AvailablePrograms storedProgram = _SelectedProgram;


                        Operation_Output_Switch.Visible = !_CheckBox.Checked;
                        Operation_Output_Switch.Enabled = !_CheckBox.Checked;
                        _tcpHandler?.EnqueueCommand(_CheckBox.Checked ? "OUTPut ON" : "OUTPut OFF");


                        if (_CheckBox.Checked)
                        {
                            _commandManager?.SetOutputVoltage(_StoredVoltageSetting);
                            _commandManager?.SetOutputCurrent(_TEMPCurrent);
                            _commandManager?.SetOutputPower(_TEMPPower);
                            _commandManager?.SetOutputCurrentNegative(_TEMPNegativeCurrent);
                            _commandManager?.SetOutputPowerNegative(_TEMPNegativePower);
                        }
                        else
                        {
                            _commandManager?.SetOutputVoltage(_StoredVoltageSetting);
                            _commandManager?.SetOutputCurrent(1.5);
                            _commandManager?.SetOutputPower(0);
                            _commandManager?.SetOutputCurrentNegative(0);
                            _commandManager?.SetOutputPowerNegative(0);
                        }
                    }
                }

            }

            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "Operation_Output_Switch":
                        if (_SelectedProgram != AvailablePrograms.None)
                        {
                            ToggleOutput();
                            //MessageBox.Show($"selected switch {_started}, {Operation_Output_Switch.Location}");
                        }
                        break;
                    case "Operation_NoneORStop_Selection":
                        if (!_started)
                        {
                            SetTimer(00);
                            _SelectedProgram = AvailablePrograms.None;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_NoneORStop_Selection.Location.Y);
                            _TEMPCurrent = 0;
                            _TEMPPower = 0;
                            _TEMPNegativeCurrent = 0;
                            _TEMPNegativePower = 0;
                        }
                        break;
                    case "Operation_Charge_selection":
                        if (!_started && !_OngoingOperation)
                        {
                            _SelectedProgram = AvailablePrograms.Charging;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_Charge_selection.Location.Y);
                            ChargeMethod(1);
                        }
                        break;
                    case "Operation_Discharge_selection":
                        if (!_started && !_OngoingOperation)
                        {
                            _SelectedProgram = AvailablePrograms.Discharging;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_Discharge_selection.Location.Y);
                            DischargeMethod(1);
                        }
                        break;
                    case "Operation_DischargeTo30_selection":
                        if (!_started && !_OngoingOperation)
                        {
                            _SelectedProgram = AvailablePrograms.DischargingTo30;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_DischargeTo30_selection.Location.Y);
                            DischargeMethod(0.7);
                        }
                        break;
                }
            }
        }

        private void ToggleOutput()
        {
            _started = !_started;
            _tcpHandler?.EnqueueCommand(_started ? "OUTPut ON" : "OUTPut OFF");
            Operation_Output_Switch.BackColor = _started ? Color.Red : Color.Green;
            Operation_Output_Switch.Text = _started ? "pause" : "start";
            if (_started) _stopwatch.Start(); else _stopwatch.Stop();
        }

        private void ChargeMethod(double Percentage)
        {
            SetTimer(Percentage);
            _commandManager?.SetOutputCurrent(_StoredCurrent);
            _commandManager?.SetOutputPower(_StoredPower);
            _commandManager?.SetOutputCurrentNegative(0);
            _commandManager?.SetOutputPowerNegative(0);

            _TEMPCurrent = _StoredCurrent;
            _TEMPPower = _StoredPower;
            _TEMPNegativeCurrent = 0;
            _TEMPNegativePower = 0;

        }

        private void DischargeMethod(double Percentage)
        {
            SetTimer(Percentage);
            _commandManager?.SetOutputCurrent(0);
            _commandManager?.SetOutputPower(0);
            _commandManager?.SetOutputCurrentNegative(_StoredNegativeCurrent);
            _commandManager?.SetOutputPowerNegative(_StoredNegativePower);

            _TEMPCurrent = 0;
            _TEMPPower = 0;
            _TEMPNegativeCurrent = _StoredNegativeCurrent;
            _TEMPNegativePower = _StoredNegativePower;

        }

        private void SetTimer(double Percentage, bool? CancelOperation = false)
        {
            Label_Elapsed_Time_UI.Text = "00:00:00";
            _stopwatch.Reset();
            logManager?.batteryData.Clear();

            if (CancelOperation == false) EstimateTotalTime = _batteryManager?.CalculateTimeEstimate(Percentage);
        }


        private static void OpenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                // Open the browser with the URL
                try
                {
                    _ = Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // Open in default browser
                    });
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Unable to open the browser. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SaveSettings(object sender, EventArgs e)
        {
            SaveFileDialog? saveFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Save as .txt file
                Title = "Save Factory Settings",
                FileName = "factory_settings.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter? writer = new(filePath))
                {
                    // Save the settings in comma-separated format (CSV-like)
                    writer.WriteLine($"{_StoredVoltageSetting},{_StoredCurrent},{_StoredPower},{_StoredNegativeCurrent},{_StoredNegativePower}");
                }

                _ = MessageBox.Show("Settings successfully saved to " + filePath);
            }
        }
        private void LoadSettings(object sender, EventArgs e)
        {
            OpenFileDialog? openFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Load from .txt file
                Title = "Load Factory Settings"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using StreamReader? reader = new(filePath);
                string? line = reader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    // Split the values by comma
                    string[] values = line.Split(',');

                    if (values.Length == 5)
                    {
                        _StoredVoltageSetting = double.Parse(values[0]);
                        _StoredCurrent = double.Parse(values[1]);
                        _StoredPower = double.Parse(values[2]);
                        _StoredNegativeCurrent = double.Parse(values[3]);
                        _StoredNegativePower = double.Parse(values[4]);

                        // Populate the UI fields with the loaded values
                        InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
                        InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
                        InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
                        InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
                        InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";

                        _ = MessageBox.Show("Settings successfully loaded from " + filePath);
                    }
                    else
                    {
                        _ = MessageBox.Show("Error: Incorrect format in the settings file.");
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private async void ButtonHandler(object sender, EventArgs e)
        {
            // Try to extract the Tag from both Control and ToolStripItem
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

            // If we found a valid tag, process it
            if (tag != null)
            {
                //logManager?.AddDebugLogMessage($"Tag found: {tag}");

                switch (tag)
                {
                    case "Start":
                        
                        break;
                    case "TogglePause":
                        
                        break;
                    case "Stop":
                        
                        break;
                    case "SaveCSV":
                        logManager?.ExportToCsv(sender, e, false, _SaveLocationCSV);
                        break;
                    case "SaveAsCSV":
                        logManager?.ExportToCsv(sender, e, true, null);
                        break;
                    case "SaveLOG":
                        logManager?.ExportLogToFile(sender, e, false, _SaveLocationLOG);
                        break;
                    case "SaveAsLOG":
                        logManager?.ExportLogToFile(sender, e, true, null);
                        break;
                    case "ToggleConsole":
                        _ConsoleState = !_ConsoleState;
                        ToggleConsole_Btn.Text = _ConsoleState ? "Open console" : "close button";
                        ConsoleBox.Height = _ConsoleState ? ConsoleBox.MaximumSize.Height : ConsoleBox.MinimumSize.Height;
                        Console_Simple_Textbox_UI.Visible = _ConsoleState;
                        break;
                    case "ClearConsole":
                        Console_Simple_Textbox_UI.Text = "";
                        Console_Short_ErrorLabel.Text = "this is where error should appear if there are any";
                        break;
                    case "TryConnectSocket":
                        if (_tcpHandler != null && !_tcpHandler.IsConnected) _ = await _tcpHandler.InitializeTcpClient();
                        break;
                    case "DisconnectSocket":
                        if (_tcpHandler != null && _tcpHandler.IsConnected) _tcpHandler?.CloseConnection();
                        break;
                    case "ToggleSessionData":
                        Properties.Settings.Default._KeepMemory = toolStripMenuSetting_keepSessionData.Checked;
                        Properties.Settings.Default.Save();
                        break;
                    case "OpenDeltaURL":
                        if (name != null) OpenURL(name);
                        break;
                    case "OpenGitURL":
                        if (name != null) OpenURL(name);
                        break;
                    default:
                        MessageBox.Show($"Tag: {tag},  not recognized");
                        break;
                }
            }
            else
            {
                //logManager?.AddDebugLogMessage("No valid tag found for the control or item.");
            }

        }
    }
}
