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
        //private TimeSpan _timeSinceLastSave = TimeSpan.Zero;
        //private readonly Stopwatch _stopwatch = new();
        //private TimeSpan? EstimateTotalTime;

        public bool _ConsoleState = false;
        private bool _EditingValues = false;
        private bool _started = false;
        private bool _OngoingOperation = false;

        public double currentVoltage = 0;
        public double currentCurrent = 0;
        public double currentPower = 0;

        public Dictionary<string, Action<string>> _commandToUIActions;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            Load += MainForm_Load;

            // UI actions associated with commands
            _commandToUIActions = new Dictionary<string, Action<string>>
            {
                { "MEASure:VOLtage?", (response) => {VoltageDisplay.Text = response + " V"; currentVoltage = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);}},
                { "MEASure:CURrent?", (response) => {AmperageDisplay.Text = response + " A"; currentCurrent = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);}},
                { "MEASure:POWer?", (response) => {WattageDisplay.Text = response + " W"; currentPower = double.Parse(response, System.Globalization.CultureInfo.InvariantCulture);}},

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
                UpdateUIFromStoredCookies();
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

        private void UpdateUIFromStoredCookies()
        {

            //_ratedVoltage = Properties.Settings.Default._ratedVoltage;
            //_ratedCapacity = Properties.Settings.Default._ratedCapacity;
            //_ratedPower = Properties.Settings.Default._ratedPower;
            //_cRating = Properties.Settings.Default._cRating;

            //_StoredVoltageSetting = Properties.Settings.Default._StoredVoltageSetting;
            //_StoredCurrent = Properties.Settings.Default._StoredCurrent;
            //_StoredPower = Properties.Settings.Default._StoredPower;

            //_StoredNegativeCurrent = Properties.Settings.Default._StoredNegativeCurrent;
            //_StoredNegativePower = Properties.Settings.Default._StoredNegativePower;


            //RatedBatteryVoltageUI.Text = _ratedVoltage.ToString();
            //RatedBatteryAmperageUI.Text = _ratedCapacity.ToString();
            //C_Rating_UI.Text = _cRating.ToString();

            //// Update your UI elements with loaded values
            //InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
            //InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
            //InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
            //InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
            //InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";
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

                Operation_NoneORStop_Selection.BackColor = _OngoingOperation ? Color.Red : SystemColors.Control;
                Operation_NoneORStop_Selection.Enabled = !_started;

                StateManager();
            };

            Timer? LateUpdate = new()
            {
                Interval = 10000
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
                    Interval = 1000
                };
                errorCleanupTimer.Tick += (sender, e) => logManager.UpdateConsole();
                errorCleanupTimer.Start();
            }
        }
        private CurrentState _currentState;

        private enum CurrentState
        {
            Idle,
            Charging,
            Discharging,
            ConnectingBattery,
        }

        private enum SetState
        {
            Charge,
            Discharge,
            BatteryConnect,
        }

        private double _EstimateVoltageSum = 2; // TEMP 2 Volts above or below _ratedVoltage

        private double _MaxChargeVoltage;
        private double _MaxPower;
        private double _MaxCurrent;

        private double _CutOffDischargeVoltage;
        private double _MinPower;
        private double _MinCurrent;

        private double Charge_C_Rating;
        private double Discharge_C_Rating;

        private double _ratedVoltage = 0;
        private double _ratedCapacity = 0;


        private async void StateManager()
        {
            while (!await Task.Run(() => InitialSetup()))
            {
                await Task.Delay(1000);
            }

            // Check if output should be turned on or off based on the state
            bool outputShouldBeOn = (_currentState != CurrentState.Idle && _currentState != CurrentState.ConnectingBattery);

            // Temporarily turn off output to check no-load voltage
            if (_commandManager != null)
            {
                // Turn output off to measure no-load voltage
                _commandManager.SetOutputState(false);
                await Task.Delay(500);  // Allow some time for the voltage to stabilize without load

                // Check current no-load voltage
                double noLoadVoltage = currentVoltage;

                // Conditions for stopping operation (full or empty)
                if (_currentState == CurrentState.Charging && noLoadVoltage >= _MaxChargeVoltage)
                {
                    // Battery is full, turn output off and highlight front panel
                    outputShouldBeOn = false;
                    _tcpHandler?.EnqueueCommand("SYSTem:FROntpanel:HIGhlight");
                }
                else if (_currentState == CurrentState.Discharging && noLoadVoltage <= _CutOffDischargeVoltage)
                {
                    // Battery is empty, turn output off and highlight front panel
                    outputShouldBeOn = false;
                    _tcpHandler?.EnqueueCommand("SYSTem:FROntpanel:HIGhlight");
                }

                // Re-enable the output based on state
                _commandManager.SetOutputState(outputShouldBeOn);
            }

            switch (_currentState)
            {
                case CurrentState.Idle:
                    // No action needed, output should remain off
                    break;
                case CurrentState.Charging:
                    SetValuesToMachine(SetState.Charge);
                    break;
                case CurrentState.Discharging:
                    SetValuesToMachine(SetState.Discharge);
                    break;
                case CurrentState.ConnectingBattery:
                    SetValuesToMachine(SetState.BatteryConnect);
                    break;
                default:
                    break;
            }
        }

        private bool InitialSetup()
        {
            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryAmperageUI.Text);
            Charge_C_Rating = ParseInput(C_Rating_UI.Text);
            Discharge_C_Rating = ParseInput(C_Rating_UI.Text);
            
            if(_ratedVoltage <= 0 || _ratedCapacity <= 0 || Charge_C_Rating <= 0 || Discharge_C_Rating <= 0)
                return false;

            _MaxCurrent = _ratedCapacity * Charge_C_Rating;
            _MaxPower = _MaxCurrent * _ratedVoltage;

            _MinCurrent = _ratedCapacity * Discharge_C_Rating;
            _MinPower = _MinCurrent * _ratedVoltage;

            _MaxChargeVoltage = _ratedVoltage + _EstimateVoltageSum;
            _CutOffDischargeVoltage = _ratedVoltage + _EstimateVoltageSum;
            return true;
        }


        private void SetValuesToMachine(SetState State)
        {
            if(_currentState != CurrentState.Idle)
            {
                _commandManager?.SetOutputCurrent(_MaxCurrent);
                _commandManager?.SetOutputPower(_MaxPower);
                _commandManager?.SetOutputCurrentNegative(_MinCurrent);
                _commandManager?.SetOutputPowerNegative(_MinPower);

                switch (State)
                {
                    case SetState.Charge:
                        _commandManager?.SetOutputVoltage(_MaxChargeVoltage);
                        break;
                    case SetState.Discharge:
                        _commandManager?.SetOutputVoltage(_CutOffDischargeVoltage);
                        break;
                    case SetState.BatteryConnect:
                        _commandManager?.SetOutputVoltage(_ratedVoltage);
                        break;
                    default:
                        _commandManager?.SetOutputVoltage(0);
                        break;
                }
            }
            else
            {
                _commandManager?.SetOutputVoltage(0);
                _commandManager?.SetOutputCurrent(0);
                _commandManager?.SetOutputPower(0);
                _commandManager?.SetOutputCurrentNegative(0);
                _commandManager?.SetOutputPowerNegative(0);
            }
           
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
        private static double ParseInput(string input)
        {
            return double.TryParse(RemoveNonNumeric(input), out double result) ? result : 0;
        }
        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',').ToArray());
        }


        //private void SaveSettings(object sender, EventArgs e)
        //{
        //    SaveFileDialog? saveFileDialog = new()
        //    {
        //        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Save as .txt file
        //        Title = "Save Factory Settings",
        //        FileName = "factory_settings.txt"
        //    };

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = saveFileDialog.FileName;

        //        using (StreamWriter? writer = new(filePath))
        //        {
        //            // Save the settings in comma-separated format (CSV-like)
        //            writer.WriteLine($"{_StoredVoltageSetting},{_StoredCurrent},{_StoredPower},{_StoredNegativeCurrent},{_StoredNegativePower}");
        //        }

        //        _ = MessageBox.Show("Settings successfully saved to " + filePath);
        //    }
        //}
        //private void LoadSettings(object sender, EventArgs e)
        //{
        //    OpenFileDialog? openFileDialog = new()
        //    {
        //        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Load from .txt file
        //        Title = "Load Factory Settings"
        //    };

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = openFileDialog.FileName;

        //        using StreamReader? reader = new(filePath);
        //        string? line = reader.ReadLine();
        //        if (!string.IsNullOrEmpty(line))
        //        {
        //            // Split the values by comma
        //            string[] values = line.Split(',');

        //            if (values.Length == 5)
        //            {
        //                _StoredVoltageSetting = double.Parse(values[0]);
        //                _StoredCurrent = double.Parse(values[1]);
        //                _StoredPower = double.Parse(values[2]);
        //                _StoredNegativeCurrent = double.Parse(values[3]);
        //                _StoredNegativePower = double.Parse(values[4]);

        //                // Populate the UI fields with the loaded values
        //                InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
        //                InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
        //                InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
        //                InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
        //                InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";

        //                _ = MessageBox.Show("Settings successfully loaded from " + filePath);
        //            }
        //            else
        //            {
        //                _ = MessageBox.Show("Error: Incorrect format in the settings file.");
        //            }
        //        }
        //    }
        //}
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

                    case "SetStateIdle":
                        _currentState = CurrentState.Idle;
                        break;
                    case "SetStateCharge":
                        _currentState = CurrentState.Charging;
                        break;
                    case "SetStateDischarge":
                        _currentState = CurrentState.Discharging;
                        break;
                    case "SetStateConnectBattery":
                        _currentState = CurrentState.ConnectingBattery;
                        break;

                    case "SaveCSV":
                        logManager?.ExportToCsv(false, _SaveLocationCSV);
                        break;
                    case "SaveAsCSV":
                        logManager?.ExportToCsv(true, null);
                        break;
                    case "SaveLOG":
                        logManager?.ExportLogToFile(false, _SaveLocationLOG);
                        break;
                    case "SaveAsLOG":
                        logManager?.ExportLogToFile(true, null);
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
