using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private LogManager? logManager;
        private TcpConnectionHandler? _tcpHandler;
        private CommandManager? _commandManager;
        private string? _SaveLocationCSV;
        private string? _SaveLocationLOG;


        public static MainForm? Instance { get; set; }

        private Timer? errorCleanupTimer;
        private readonly Stopwatch _stopwatch = new();
        private enum AvailableState
        {
            None,
            Charge,
            Discharge,
        }
        private bool _started = false;
        private bool _EditingValues = false;
        public bool _ConsoleState = false;

        public double currentVoltage = 0;
        public double currentCurrent = 0;

        public double currentPower = 0;

        public double _MaxChargeVoltage;
        public double _MaxPower;
        public double _MaxCurrent;
        public double Charge_C_Rating;

        public double _CutOffDischargeVoltage;
        public double _MinPower;
        public double _MinCurrent;
        public double Discharge_C_Rating;

        private double _ratedVoltage = 0;
        private double _ratedCapacity = 0;

        private bool DataSet = false;

        private double SOC_Charge = 0;
        private double SOC_Discharge = 0;
        private AvailableState currentState;
        public Dictionary<string, Action<string>> _commandToUIActions;

        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            _commandToUIActions = new Dictionary<string, Action<string>>();
            TcpConnectionHandler.Instance.OnConnectionEstablished += InitializeUIActions;
            TcpConnectionHandler.Instance.OnConnectionLost += HandleConnectionLost;
            Load += MainForm_Load;
        }
        private void MainForm_Load(object? sender, EventArgs? e)
        {
            _commandManager = CommandManager.Instance;
            logManager = LogManager.Instance;
            _tcpHandler = TcpConnectionHandler.Instance;
            logManager.OnLogUpdate += LogManager_OnLogUpdate;
            toolStripMenuSetting_keepSessionData.Checked = Properties.Settings.Default._KeepMemory;
            _SaveLocationCSV = Properties.Settings.Default.SaveLocationCSV;
            _SaveLocationLOG = Properties.Settings.Default.SaveLocationLOG;
            InitTimers();
            Show();
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
        private void HandleConnectionLost()
        {
            VoltageDisplay.Text = "N/A";
            AmperageDisplay.Text = "N/A";
            WattageDisplay.Text = "N/A";
            Label_Remote_CV_UI.Text = "N/A";
            Label_Remote_CC_UI.Text = "N/A";
            Label_Remote_CP_UI.Text = "N/A";
        }

        #region Time based Functions
        private void InitTimers()
        {
            Timer? updateTimer = new() { Interval = 1000 };
            updateTimer.Tick += (sender, e) => StandardUpdate();
            updateTimer.Start();

            Timer? LateUpdateTimer = new() { Interval = 10000 };
            LateUpdateTimer.Tick += (sender, e) => LateUpdate();
            LateUpdateTimer.Start();

            if (logManager != null)
            {
                errorCleanupTimer = new Timer { Interval = 1000 };
                errorCleanupTimer.Tick += (sender, e) => logManager.UpdateConsole();
                errorCleanupTimer.Start();
            }
        }
        private void StandardUpdate()
        {
            _commandManager?.Request_Measure_Voltage();
            _commandManager?.Request_Measure_Current();
            _commandManager?.Request_Measure_Power();
            _commandManager?.Request_Source_Voltage();
            _commandManager?.Request_Source_Current();
            _commandManager?.Request_Source_Power();
            _commandManager?.Request_Source_Current_Negative();
            _commandManager?.Request_Source_Power_Negative();
            StateManager();
            if (_stopwatch.IsRunning) { TimeSpan elapsed = _stopwatch.Elapsed; Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}"; }
            Operation_NoneORStop_Selection.BackColor = currentState != AvailableState.None ? Color.Red : SystemColors.Control;
            _started = currentState != AvailableState.None;
            if (currentState != AvailableState.None) _stopwatch.Start(); else _stopwatch.Stop();
        }
        private void LateUpdate()
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
            if (_stopwatch.IsRunning) logManager?.CollectBatteryMetrics(currentVoltage, currentCurrent, currentPower);
        }
        private void LogManager_OnLogUpdate(string logMessage) { if (InvokeRequired) Invoke(new Action(() => LogManager_OnLogUpdate(logMessage))); else Console_Simple_Textbox_UI.Text = logMessage; }
        //handle the state of the machine
        private bool _isPreChargeInProgress = false;
        private bool batteryConnected = false;
        private async void StateManager()
        {
            if (_tcpHandler == null) return;

            if (!DataSet || !_tcpHandler.IsConnected) return;

            //step 1: check battery connection
            if (!_isPreChargeInProgress)
            {
                _isPreChargeInProgress = true;
                batteryConnected = await TryPreChargePulse();
                if (!batteryConnected)
                {
                    MessageBox.Show("Failed to connect the battery after 3 attempts.");
                    return;
                }
            }

            if (currentState == AvailableState.Charge && batteryConnected)
            {
                if (UtilityBase.IsApproximatelyEqual(currentVoltage, _MaxChargeVoltage, 1))
                {
                    if (UtilityBase.IsApproximatelyEqual(currentCurrent, 0, 1))
                    {
                        _commandManager?.SetOutputState(false);
                        currentState = AvailableState.None;
                        MessageBox.Show("Battery is fully charged");
                    }
                }
            }
            else if (currentState == AvailableState.Discharge && batteryConnected)
            {
                // not handling discharging yet, so this part can be developed later
            }
        }
        private async Task<bool> TryPreChargePulse()
        {
            const int maxRetries = 3;
            int attempts = 0;
            bool batteryConnected = false;
            while (attempts < maxRetries)
            {
                attempts++;

                // PreCharge pulse with max voltage
                _commandManager?.SetOutputVoltage(_MaxChargeVoltage);
                _commandManager?.SetOutputState(true); // Turn on

                // Wait briefly to allow the system to stabilize
                await Task.Delay(2500); // Adjust delay as needed for system response time
                double _preChargeActiveVoltage = currentVoltage;

                // Turn off
                _commandManager?.SetOutputState(false);

                await Task.Delay(2500);

                //Step 2: Check if the voltage is stabilized (i.e., battery is connected)
                if (CheckBatteryConnection(_preChargeActiveVoltage)) { batteryConnected = true; break; }
                MessageBox.Show($"Attempt {attempts} trying to check for battery connection");

                await Task.Delay(1000); // Delay between retries
            }

            return batteryConnected;
        }
        private bool CheckBatteryConnection(double V)
        {
            if (UtilityBase.IsApproximatelyEqual(currentVoltage, V, 1)) return false; // If the voltage does not stabilize, return false
            if (UtilityBase.IsApproximatelyEqual(currentVoltage, 0, 5)) return false; //this voltage is too low to be a correct connection
            return true; // If the voltage is stable (not dropping to zero), the battery is connected
        }
        #endregion

        private void CalculateSOC()
        {
            if (!_started) return;
            // Calculate the state of charge (SoC) in percentage
            SOC_Charge = (currentCurrent / _ratedCapacity) * 100;
            SOC_Discharge = (1 - (currentCurrent * _stopwatch.Elapsed.TotalHours) / _ratedCapacity) * 100;

            textBox1.Text = SOC_Charge.ToString() + " %";
            textBox2.Text = SOC_Discharge.ToString() + " %";
        }

        private void SetValuesToMachine(double voltage, double amp = 0, double ampNeg = 0, double power = 0, double powerNeg = 0)
        {
            amp = amp == 0 ? _MaxCurrent : amp;
            ampNeg = ampNeg != 0 ? _MinCurrent : ampNeg;
            power = power != 0 ? _MaxPower : power;
            powerNeg = powerNeg != 0 ? _MinPower : powerNeg;

            _commandManager?.SetOutputVoltage(voltage);
            _commandManager?.SetOutputCurrent(amp);
            _commandManager?.SetOutputCurrentNegative(ampNeg);
            _commandManager?.SetOutputPower(power);
            _commandManager?.SetOutputPowerNegative(powerNeg);
        }
        private void UpdateBatterySettings()
        {
            _CutOffDischargeVoltage = UtilityBase.ParseInput(InputField_StoredValueVoltageMAX.Text);
            _MaxChargeVoltage = UtilityBase.ParseInput(InputField_StoredValueVoltageMIN.Text);
            _MaxCurrent = UtilityBase.ParseInput(InputField_StoredValueCurrentPlus.Text);
            _MaxPower = UtilityBase.ParseInput(InputField_StoredValuePowerPlus.Text);
            _MinCurrent = UtilityBase.ParseInput(InputField_StoredValueCurrentMin.Text);
            _MinPower = UtilityBase.ParseInput(InputField_StoredValuePowerMin.Text);
            MessageBox.Show($"Values saved: {_CutOffDischargeVoltage}, {_MaxChargeVoltage}, {_MaxCurrent}, {_MaxPower}, {_MinCurrent}, {_MinPower}");
        }

        private void InitializeBatterySettings()
        {
            double typicalVoltagePerCell;
            double numberOfCells;
            _ratedVoltage = UtilityBase.ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = UtilityBase.ParseInput(RatedBatteryAmperageUI.Text);
            Charge_C_Rating = UtilityBase.ParseInput(Charge_cRating.Text);
            Discharge_C_Rating = UtilityBase.ParseInput(Discharge_cRating.Text);

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
                typicalVoltagePerCell = 3.6; // Nominal voltage for a Lithium-Ion cell
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

            InputField_StoredValueVoltageMAX.Text = ($"{_MaxChargeVoltage} V");
            InputField_StoredValueVoltageMIN.Text = ($"{_CutOffDischargeVoltage} V");
            InputField_StoredValueCurrentPlus.Text = ($"{_MaxCurrent} A");
            InputField_StoredValuePowerPlus.Text = ($"{_MaxPower} W");
            InputField_StoredValueCurrentMin.Text = ($" - {_MinCurrent} A");
            InputField_StoredValuePowerMin.Text = ($" - {_MinPower} W");
            DataSet = true;
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
                    case "ToggleEditing":
                        _EditingValues = !_EditingValues;
                        InputField_StoredValueVoltageMAX.ReadOnly = !_EditingValues;
                        InputField_StoredValueVoltageMIN.ReadOnly = !_EditingValues;
                        InputField_StoredValueCurrentPlus.ReadOnly = !_EditingValues;
                        InputField_StoredValuePowerPlus.ReadOnly = !_EditingValues;
                        InputField_StoredValueCurrentMin.ReadOnly = !_EditingValues;
                        InputField_StoredValuePowerMin.ReadOnly = !_EditingValues;
                        Button_Toggle_ValueEditor.Text = _EditingValues ? "Save And Update Values" : "Edit Values";
                        if (!_EditingValues) UpdateBatterySettings();
                        break;
                    case "setData":
                        InitializeBatterySettings();
                        break;
                    case "OpenManualForm":
                        ManualForm manualForm = new();
                        manualForm.Show();
                        break;
                    case "OpenSequencer":
                        UpdatedForm updatedForm = new();
                        updatedForm.Show();
                        break;
                    case "SetStateIdle":
                        currentState = AvailableState.None;
                        SetValuesToMachine(_ratedVoltage); _commandManager?.SetOutputState(false);
                        break;
                    case "SetStateCharge":
                        currentState = AvailableState.Charge;
                        SetValuesToMachine(_MaxChargeVoltage); _commandManager?.SetOutputState(true);
                        break;
                    case "SetStateDischarge":
                        currentState = AvailableState.Discharge;
                        SetValuesToMachine(_CutOffDischargeVoltage); _commandManager?.SetOutputState(true);
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
                        if (_tcpHandler != null && _tcpHandler.IsConnected) _tcpHandler?.CloseConnectionAsync();
                        break;
                    case "ToggleSessionData":
                        Properties.Settings.Default._KeepMemory = toolStripMenuSetting_keepSessionData.Checked;
                        Properties.Settings.Default.Save();
                        break;
                    case "OpenDeltaURL":
                        if (name != null) UtilityBase.OpenURL(name);
                        break;
                    case "OpenGitURL":
                        if (name != null) UtilityBase.OpenURL(name);
                        break;
                    default:
                        MessageBox.Show($"Tag: {tag},  not recognized");
                        break;
                }
            }
        }
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if there is an ongoing TCP connection
            if (_tcpHandler != null && _tcpHandler.IsConnected)
            {
                // Show a loading indicator or disable form elements if necessary
                Cursor = Cursors.WaitCursor;

                // Wait for the connection to close asynchronously
                await _tcpHandler.CloseConnectionAsync();

                // Ensure the connection is fully closed before proceeding
                if (_tcpHandler.IsConnected)
                {
                    // Optionally, log a message or show an error if the connection is not closed successfully
                    MessageBox.Show("Failed to close the connection before closing the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;  // Prevent the form from closing if the connection could not be closed
                    return;
                }
            }

            // Proceed with the form closing after the connection is closed
            Cursor = Cursors.Default;  // Reset the cursor after the operation
        }

        private async void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Check if there is an ongoing TCP connection
            if (_tcpHandler != null && _tcpHandler.IsConnected)
            {
                // Show a loading indicator or disable form elements if necessary
                Cursor = Cursors.WaitCursor;

                // Wait for the connection to close asynchronously
                await _tcpHandler.CloseConnectionAsync();

                // Ensure the connection is fully closed before proceeding
                if (_tcpHandler.IsConnected)
                {
                    // Optionally, log a message or show an error if the connection is not closed successfully
                    MessageBox.Show("Failed to close the connection before closing the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Proceed with the form closing after the connection is closed
            Cursor = Cursors.Default;  // Reset the cursor after the operation
        }
    }
}
