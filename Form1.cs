using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private LogManager? logManager;
        private TcpConnectionHandler? _tcpHandler;
        private BatteryManager? _batteryManager;
        private CommandManager? _commandManager;


        public static MainForm? Instance { get; private set; }

        private Timer? errorCleanupTimer;
        private bool _started = false;
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

        private double VoltageLimit = 0;
        private double CurrentLimit = 0;
        private double PowerLimit = 0;
        private double NegativeCurrentLimit = 0;
        private double NegativePowerLimit = 0;


        private TimeSpan _timeSinceLastSave = TimeSpan.Zero;
        private readonly Stopwatch _stopwatch = new();
        private TimeSpan? EstimateTotalTime;


        private double _StoredVoltageSetting = 0;
        private double _StoredCurrent = 0;
        private double _StoredPower = 0;
        private double _StoredNegativeCurrent = 0;
        private double _StoredNegativePower = 0;

        // UI dictionary

        public Dictionary<string, Action<string>> _commandToUIActions;

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

                { "SYSTem:LIMits:VOLtage?", (response) => VoltageLimit = Double.Parse(response)},
                { "SYSTem:LIMits:CURrent?", (response) => CurrentLimit = Double.Parse(response)},
                { "SYSTem:LIMits:POWEr?", (response) => PowerLimit = Double.Parse(response)},
                { "SYSTem:LIMits:CURrent:NEGative?", (response) => NegativeCurrentLimit = Double.Parse(response)},
                { "SYSTem:LIMits:POWer:NEGative?", (response) => NegativePowerLimit = Double.Parse(response)},
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

                _commandManager?.RequestTime();
                StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();

                //LockButtons();



                // Always update the elapsed time display
                if (_stopwatch.IsRunning)
                {
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
                }
            };

            Timer? LateUpdate = new()
            {
                Interval = 5000 // 5 second interval
            };
            LateUpdate.Tick += (sender, e) =>
            {
                LiveInfoData.Text = $"SM70-CP-450 Controller Status:{(_tcpHandler == null ? "Not initialized" : (_tcpHandler.IsConnected ? "Connected" : "Not Connected"))}";
                _commandManager?.RequestRemoteSetting_CV();
                _commandManager?.RequestRemoteSetting_CC();
                _commandManager?.RequestRemoteSetting_CP();

                _commandManager?.RequestSystemVoltageLimit();
                _commandManager?.RequestSystemCurrentLimit();
                _commandManager?.RequestSystemPowerLimit();
                _commandManager?.RequestSystemNegCurrentLimit();
                _commandManager?.RequestSystemNegPowerLimit();
            };



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
                    AvailablePrograms storedProgram = _SelectedProgram;
                    Operation_Output_Switch.Visible = !_CheckBox.Checked;
                    Operation_Output_Switch.BackColor = _started ? Color.Red : Color.Green;
                    Operation_Output_Switch.Text = _started ? "Stop" : "Start";

                    if (_CheckBox.Checked) _SelectedProgram = storedProgram; else {
                        _SelectedProgram = AvailablePrograms.None;
                        _commandManager?.SetOutputVoltage(_StoredVoltageSetting);
                        _commandManager?.SetOutputCurrent(1.5);
                    }
                }

            }

            if (sender is Button button)
            {
                switch (button.Name)
                {
                    case "Operation_Output_Switch":
                        if(_SelectedProgram != AvailablePrograms.None)
                        {
                            ToggleOutput();
                            //MessageBox.Show($"selected switch {_started}, {Operation_Output_Switch.Location}");
                        }
                        break;
                    case "Operation_Charge_selection":
                        if (!_started)
                        {
                            _SelectedProgram = AvailablePrograms.Charging;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_Charge_selection.Location.Y);
                            ChargeMethod(1);
                        }
                        break;
                    case "Operation_Discharge_selection":
                        if(!_started){
                            _SelectedProgram = AvailablePrograms.Discharging;
                            Operation_Output_Switch.Location = new Point(Operation_Output_Switch.Location.X, Operation_Discharge_selection.Location.Y);
                            DischargeMethod(1);
                        }
                        break;
                    case "Operation_DischargeTo30_selection":
                        if(!_started)
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
            if (_started) _stopwatch.Start(); else _stopwatch.Stop();
        }

        private void ChargeMethod(double Percentage)
        {
            SetTimer(Percentage);
            _commandManager?.SetOutputCurrent(_StoredCurrent);
            _commandManager?.SetOutputPower(_StoredPower);
            _commandManager?.SetOutputCurrentNegative(0);
            _commandManager?.SetOutputPowerNegative(0);
        }

        private void DischargeMethod(double Percentage)
        {
            SetTimer(Percentage);
            _commandManager?.SetOutputCurrent(0);
            _commandManager?.SetOutputPower(0);
            _commandManager?.SetOutputCurrentNegative(_StoredNegativeCurrent);
            _commandManager?.SetOutputPowerNegative(_StoredNegativePower);
        }

        private void SetTimer(double Percentage)
        {
            Label_Elapsed_Time_UI.Text = "00:00:00";
            _stopwatch.Reset();
            logManager?.batteryData.Clear();

            EstimateTotalTime = _batteryManager?.CalculateTimeEstimate(Percentage);
        }

        #region buttons



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

        private void MenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                // Retrieve the URL from the Tag property
                string? url = menuItem.Tag as string;

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
        }

        private void ToolStripMenuSetting_keepSessionData_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._KeepMemory = toolStripMenuSetting_keepSessionData.Checked;
            Properties.Settings.Default.Save();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private async void SocketTab_Connect_Btn_click(object sender, EventArgs e)
        {
            if (_tcpHandler != null)
            {
                if (!_tcpHandler.IsConnected)
                {
                    _ = await _tcpHandler.InitializeTcpClient();
                }
            }

        }

        private void SocketTab_Disconnect_Btn_Click(object sender, EventArgs e)
        {
            if (_tcpHandler != null)
            {
                if (_tcpHandler.IsConnected)
                {
                    _tcpHandler?.CloseConnection();
                }
            }

        }

        private void RuntimeCSV_ToolstripItem_Click(object sender, EventArgs e)
        {
            logManager?.ExportToCsv(sender, e);
        }

        private void errorLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logManager?.ExportLogToFile(sender, e);
        }

        private void ToggleConsole_Btn_Click(object sender, EventArgs e)
        {
            _ConsoleState = !_ConsoleState;
            ToggleConsole_Btn.Text = _ConsoleState ? "Open console" : "close button";
            ConsoleBox.Height = _ConsoleState ? ConsoleBox.MaximumSize.Height : ConsoleBox.MinimumSize.Height;
            Console_Simple_Textbox_UI.Visible = _ConsoleState;
        }
        private void ConsoleClear_Btn_Click(object sender, EventArgs e)
        {
            Console_Simple_Textbox_UI.Text = "";
            Console_Short_ErrorLabel.Text = "this is where error should appear if there are any";
        }
        #endregion
    }
}
