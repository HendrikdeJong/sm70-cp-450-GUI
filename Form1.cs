using System.Data;
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
        private readonly Stopwatch _stopwatch = new();
        private enum AvailableState
        {
            None,
            Charge,
            Discharge,
        }


        //private TimeSpan _timeSinceLastSave = TimeSpan.Zero;
        //private TimeSpan? EstimateTotalTime;

        private bool _started = false;
        public bool _ConsoleState = false;
        private bool _EditingValues = false;
        private bool _OngoingOperation = false;

        public double currentVoltage = 0;
        public double currentCurrent = 0;
        public double currentPower = 0;

        private double _MaxChargeVoltage;
        private double _MaxPower;
        private double _MaxCurrent;
        private double Charge_C_Rating;

        private double _CutOffDischargeVoltage;
        private double _MinPower;
        private double _MinCurrent;
        private double Discharge_C_Rating;

        private double _ratedVoltage = 0;
        private double _ratedCapacity = 0;

        private bool DataSet = false;
        private bool ShowOnce = false;
        private bool BatteryConnected = false;

        private double SOC_Charge = 0;
        private double SOC_Discharge = 0;
        private AvailableState currentState;
        public Dictionary<string, Action<string>> _commandToUIActions;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            _commandToUIActions = new Dictionary<string, Action<string>>(); // Initialize the dictionary
            Load += MainForm_Load;
            InitializeUIActions(); // Call the new function to initialize UI actions
            Timers();
        }

        private void InitializeUIActions()
        {
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
                { "SYSTem:LIMits:POWer?", (response) => LimitLabel_03.Text = response  + " W" },
                { "SYSTem:LIMits:CURrent:NEGative?", (response) => LimitLabel_04.Text = "-" + response  + " A" },
                { "SYSTem:LIMits:POWer:NEGative?", (response) => LimitLabel_05.Text = "-" + response + " W"},
            };
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
            if (InvokeRequired) Invoke(new Action(() => LogManager_OnLogUpdate(logMessage))); else Console_Simple_Textbox_UI.Text = logMessage;
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
            Timer? updateTimer = new(){Interval = 1000};
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

                //Operation_NoneORStop_Selection.BackColor = _OngoingOperation ? Color.Red : SystemColors.Control;
                //Operation_NoneORStop_Selection.Enabled = !_started;

                StateManager();
                if (_stopwatch.IsRunning)
                {
                    TimeSpan elapsed = _stopwatch.Elapsed;

                    //TimeSpan _TimeRemaining = ((EstimateTotalTime ?? TimeSpan.Zero) - elapsed);

                    //Label_Total_Time_UI.Text = $"{_TimeRemaining.Hours:D2}:{_TimeRemaining.Minutes:D2}:{_TimeRemaining.Seconds:D2}";
                    Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                }

                if( currentState != AvailableState.None)
                {
                    _started = true;
                    _stopwatch.Start();
                } else
                {
                    _started = false;
                    _stopwatch.Stop();
                }
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
                CalculateSOC();
                if(_stopwatch.IsRunning) logManager?.CollectBatteryMetrics(currentVoltage, currentCurrent, currentPower);
            };


            LateUpdate.Start();
            updateTimer.Start();
            if (logManager != null)
            {
                errorCleanupTimer = new Timer{Interval = 1000};
                errorCleanupTimer.Tick += (sender, e) => logManager.UpdateConsole();
                errorCleanupTimer.Start();
            }
        }

        private void CalculateSOC()
        {
            if (_started)
            {
                // Calculate the state of charge (SoC) in percentage
                SOC_Charge = (currentCurrent / _ratedCapacity) * 100;
                SOC_Discharge = (1 - (currentCurrent * (_stopwatch.Elapsed.TotalMinutes * 60)) / _ratedCapacity) * 100;

                textBox1.Text = SOC_Charge.ToString() + " %";
                textBox2.Text = SOC_Discharge.ToString() + " %";
            }
        }

        private void StateManager()
        {
            if (_tcpHandler == null) return;
            if (DataSet && _tcpHandler.IsConnected)
            {
                if (!Operation_ConnectBattery_Override.Checked)
                {
                    if (!BatteryConnected)
                    {
                        SetValuesToMachine(true, _MaxChargeVoltage, 1);
                        if (!IsApproximatelyEqual(currentCurrent, 0.5, 2)) BatteryConnected = true;
                    }
                }

                if (!ShowOnce && BatteryConnected == true)
                {
                    ShowOnce = true;
                    SetValuesToMachine(false, _ratedVoltage);
                    currentState = AvailableState.None;
                    MessageBox.Show("battery is connected");
                }


                if (currentState == AvailableState.Charge)
                {
                    if (IsApproximatelyEqual(currentVoltage, _MaxChargeVoltage, 0.5) && IsApproximatelyEqual(currentCurrent, 0, 0.1))
                    {
                        SetValuesToMachine(false, _ratedVoltage);
                        currentState = AvailableState.None;
                        MessageBox.Show("Battery is fully charged");
                    }
                    //if (SOC_Charge >= 30)
                    //{
                    //    SetValuesToMachine(SetState.None);
                    //    MessageBox.Show("Battery charged to target SoC (30%)");
                    //}
                }
                else if (currentState == AvailableState.Discharge)
                {
                    if (IsApproximatelyEqual(currentVoltage, _CutOffDischargeVoltage, 0.5) && IsApproximatelyEqual(currentCurrent, 0, 0.1))
                    {
                        SetValuesToMachine(false, _ratedVoltage);
                        currentState = AvailableState.None;
                        MessageBox.Show("Battery is fully discharged");
                    }
                    if (SOC_Discharge <= 30)
                    {
                        SetValuesToMachine(false, _ratedVoltage);
                        currentState = AvailableState.None;
                        MessageBox.Show("Battery discharged to target SoC (30%)");
                    }
                }
            }
        }


        private void SetValuesToMachine(bool output, double voltage, double amp = 0, double ampNeg = 0, double power = 0, double powerNeg = 0)
        {
            amp = amp == 0 ? _MaxCurrent : amp;
            ampNeg = ampNeg != 0 ? _MinCurrent : ampNeg;
            power = power != 0 ? _MaxPower : power;
            powerNeg = powerNeg != 0 ? _MinPower : powerNeg;
            voltage = Math.Round(voltage, 1);

            MessageBox.Show($"trying to set values: {output}, {voltage}, {amp}, {ampNeg}, {power}, {powerNeg}");
            _commandManager?.SetOutputState(output);
            _commandManager?.SetOutputVoltage(voltage);
            _commandManager?.SetOutputCurrent(amp);
            _commandManager?.SetOutputCurrentNegative(ampNeg);
            _commandManager?.SetOutputPower(power);
            _commandManager?.SetOutputPowerNegative(powerNeg);
        }
        private void InitializeBatterySettings()
        {
            double typicalVoltagePerCell = 2;
            double numberOfCells = 2;

            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryAmperageUI.Text);
            Charge_C_Rating = ParseInput(Charge_cRating.Text);
            Discharge_C_Rating = ParseInput(Discharge_cRating.Text);

            if (string.IsNullOrEmpty(RatedBatteryVoltageUI.Text) || string.IsNullOrEmpty(RatedBatteryAmperageUI.Text) || string.IsNullOrEmpty(Charge_cRating.Text))
            {
                DataSet = false;
                return;
            }

            _MaxCurrent = _ratedCapacity * Charge_C_Rating;
            _MaxPower = _MaxCurrent * _ratedVoltage;
            _MinCurrent = _ratedCapacity * Discharge_C_Rating;
            _MinPower = _MinCurrent * _ratedVoltage;

            if (BatteryChemistryType.SelectedIndex == 0)
            {
                typicalVoltagePerCell = 3.7; // Nominal voltage for a Lithium-Ion cell
                numberOfCells = Math.Round(_ratedVoltage / typicalVoltagePerCell);

                _MaxChargeVoltage = numberOfCells * 4.2;
                _CutOffDischargeVoltage = numberOfCells * 3.0;
            }
            else if (BatteryChemistryType.SelectedIndex == 1)// this is Lead-Acid
            {
                typicalVoltagePerCell = 2.0; // Nominal voltage for a Lead-Acid cell
                numberOfCells = Math.Round(_ratedVoltage / typicalVoltagePerCell);

                _MaxChargeVoltage = numberOfCells * 2.4;
                _CutOffDischargeVoltage = numberOfCells * 1.75;
            }

            InputField_StoredValueVoltage.Text = ($"{_CutOffDischargeVoltage} ~ {_MaxChargeVoltage} V");
            InputField_StoredValueCurrentPlus.Text = ($"{_MaxCurrent} A");
            InputField_StoredValuePowerPlus.Text = ($"{_MaxPower} W");
            InputField_StoredValueCurrentMin.Text = ($" - {_MinCurrent} A");
            InputField_StoredValuePowerMin.Text = ($" - {_MinPower} W");
            DataSet = true;
        }
        public static bool IsApproximatelyEqual(double value1, double value2, double value3 = 0.1)
        {
            double difference = Math.Abs(value1 - value2);
            return difference <= value3;
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
                //logManager?.AddDebugLogMessage($"Tag found: {tag}");

                switch (tag)
                {
                    case "TEST":
                        double voltage = Math.Round(_MaxChargeVoltage, 1);
                        
                        _tcpHandler?.EnqueueCommand($"SOURce:VOLtage {voltage}");
                        MessageBox.Show($"Test button Pressed, trying: SOURce:VOLtage {voltage}");
                        break;
                    case "setData":
                        InitializeBatterySettings();
                        break;
                    case "SetStateIdle":
                        currentState = AvailableState.None;
                        SetValuesToMachine(false, _ratedVoltage);
                        MessageBox.Show("Machine is now idle");
                        break;
                    case "SetStateCharge":
                        currentState = AvailableState.Charge;
                        SetValuesToMachine(true, _MaxChargeVoltage);
                        MessageBox.Show($"Machine is now charging{_MaxChargeVoltage}");
                        break;
                    case "SetStateDischarge":
                        currentState = AvailableState.Discharge;
                        SetValuesToMachine(true, _CutOffDischargeVoltage);
                        MessageBox.Show($"Machine is now discharging{_CutOffDischargeVoltage}");
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
                        if (_tcpHandler != null && !_tcpHandler.IsConnected)
                        {
                            _ = await _tcpHandler.InitializeTcpClient();
                            InitializeUIActions();
                        }
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
    }
}
