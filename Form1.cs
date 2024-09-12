using sm70_cp_450_GUI.Properties;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private TcpConnectionHandler _tcpConnectionHandler;
        private bool _started = false;
        private bool DischargeTo30Bool = false;
        private bool _EditingValues = false;
        private AvailablePrograms _SelectedProgram = AvailablePrograms.None;

        //console log
        private Dictionary<string, (int Count, DateTime LastOccurred)> _errorMessages = new Dictionary<string, (int Count, DateTime LastOccurred)>();
        private Dictionary<string, (int Count, DateTime LastOccurred)> _infoMessages = new Dictionary<string, (int Count, DateTime LastOccurred)>();

        private bool _showAll = false;

        private double _ratedVoltage = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._ratedVoltage : 0;
        private double _ratedCapacity = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._ratedCapacity : 0;
        private double _cRating = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._cRating : 0;
        private double _ratedPower = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._ratedPower : 0;

        List<BatteryMetrics> batteryData = new List<BatteryMetrics>();
        private TimeSpan _timeToDischarge30Percent;
        double currentVoltage = 0;
        double currentCurrent = 0;
        double currentPower = 0;


        public class BatteryMetrics
        {
            public DateTime Time { get; set; }
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double Power { get; set; }
        }

        private TimeSpan _timeSinceLastSave = TimeSpan.Zero;
        private Stopwatch _stopwatch = new Stopwatch();
        private TimeSpan _maxChargingTime;

        private double _StoredVoltageSetting = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._StoredVoltageSetting : 0;
        private double _StoredCurrent = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._StoredCurrent : 0;
        private double _StoredPower = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._StoredPower : 0;
        private double _StoredNegativeCurrent = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._StoredNegativeCurrent : 0;
        private double _StoredNegativePower = Properties.Settings.Default._KeepMemory ? Properties.Settings.Default._StoredNegativePower : 0;

        // Queues for queries and commands
        private ConcurrentQueue<string> _commandQueue = new ConcurrentQueue<string>();
        private ConcurrentQueue<string> _queryQueue = new ConcurrentQueue<string>();
        private HashSet<string> _pendingQueries = new HashSet<string>();
        private HashSet<string> _pendingCommands = new HashSet<string>();

        private bool _isProcessingQueryQueue = false;
        private bool _isProcessingCommandQueue = false;


        // UI dictionary
        private Dictionary<string, Action<string>> _commandToUIActions;

        private enum AvailablePrograms
        {
            None,
            Connecting_Battery,
            Charging,
            Discharging,
        }

        public MainForm()
        {
            InitializeComponent();
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

                { "SYSTem:TIMe?", (response) => Label_Time_UI.Text = response},
            };



            InitializeTimers();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Show();
            toolStripMenuSetting_keepmemory.Checked = Properties.Settings.Default._KeepMemory;
            string ServerIp = Properties.Settings.Default._IpAddres;
            int ServerPort = int.Parse(Properties.Settings.Default._Port);
            _tcpConnectionHandler = new TcpConnectionHandler(ServerIp, ServerPort);

            MessageBox.Show("Attempting to establish TCP connection. Please wait...");
            bool connectionEstablished = await _tcpConnectionHandler.InitializeTcpClient();

            if (connectionEstablished)
            {
                InitializeTimers();
                InitializeSettings();
            }
            else
            {
                MessageBox.Show("Failed to establish TCP connection.");
            }
        }

        private void InitializeTimers()
        {
            var updateTimer = new Timer
            {
                Interval = 1000
            };
            updateTimer.Tick += (sender, e) =>
            {
                AddConsoleError("[INFO] update timer tick: ");
                Request_Measure_Voltage();
                Request_Measure_Current();
                Request_Measure_Power();

                Request_Source_Voltage();
                Request_Source_Current();
                Request_Source_Power();
                Request_Source_Current_Negative();
                Request_Source_Power_Negative();

                RequestRemoteSetting_CV();
                RequestRemoteSetting_CC();
                RequestRemoteSetting_CP();

                StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();

                RequestTime();
                LockButtons();

                // Always update the elapsed time display
                if (_stopwatch.IsRunning)
                {
                    _timeSinceLastSave = _timeSinceLastSave.Add(TimeSpan.FromSeconds(1)); // Increment by 1 second

                    if (_timeSinceLastSave.TotalSeconds >= 5)  // Check if 5 seconds have passed
                    {
                        CollectBatteryMetrics();  // Save data
                        _timeSinceLastSave = TimeSpan.Zero;  // Reset the timer
                    }
                    TimeSpan elapsed = _stopwatch.Elapsed;
                    Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                }

                // Monitor the battery during discharging
                if (DischargeTo30Bool)
                {
                    MonitorDischargeTo30Percent();
                }
            };
            updateTimer.Start();

        }


        private void MonitorDischargeTo30Percent()
        {
            if (_started && _stopwatch.IsRunning)
            {
                TimeSpan elapsed = _stopwatch.Elapsed;
                Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";

                // Check if the elapsed time is greater than or equal to the time to reach 30%
                if (elapsed >= _timeToDischarge30Percent)
                {
                    ToggleStartStopButton(null, EventArgs.Empty);

                    // Notify the user that discharging has completed
                    MessageBox.Show("Battery has been discharged to approximately 30% capacity, please export csv for the datasheet");
                }
            }
        }

        private void InitializeSettings()
        {
            SetSystemRemoteSetting_CV("Remote");
            SetSystemRemoteSetting_CC("Remote");
            SetSystemRemoteSetting_CP("Remote");
        }


        #region Socket

        // Enqueue a query (response expected)
        private void EnqueueQuery(string query)
        {
            if (!_tcpConnectionHandler.IsConnected)
            {
                AddConsoleError($"[ERROR] Cannot enqueue query: TCP connection is not initialized, query: {query}");
                return; // Prevent adding to the queue if TCP is not initialized
            }
            if (!_pendingQueries.Contains(query))
            {
                _queryQueue.Enqueue(query);
                _pendingQueries.Add(query);
                ProcessQueryQueue();
            }
        }

        private async void ProcessQueryQueue()
        {
            if (_isProcessingQueryQueue) return;
            _isProcessingQueryQueue = true;
            AddConsoleError("[INFO] Starting to process query queue.");

            while (_queryQueue.TryDequeue(out string query))
            {
                AddConsoleError($"[INFO] Processing query: {query}");
                _pendingQueries.Remove(query);

                string response = await _tcpConnectionHandler.SendQueryAsync(query);

                if (response != null)
                {
                    AddConsoleError($"[INFO] Response received: {response}");
                    if (_commandToUIActions.ContainsKey(query))
                    {
                        AddConsoleError($"[INFO] Executing UI action for query: {query}");
                        _commandToUIActions[query](response);
                    }
                    else
                    {
                        AddConsoleError($"[WARN] No UI action found for query: {query}");
                    }
                }
                else
                {
                    AddConsoleError("[ERROR] No response for query.");
                }
            }

            AddConsoleError("[INFO] Finished processing query queue.");
            _isProcessingQueryQueue = false;
        }





        // Enqueue a command (no response expected)
        private void EnqueueCommand(string command)
        {
            if (!_tcpConnectionHandler.IsConnected)
            {
                AddConsoleError("[ERROR] Cannot enqueue command: TCP connection is not initialized.");
                return; // Prevent adding to the queue if TCP is not initialized
            }
            if (!_pendingCommands.Contains(command))
            {
                _commandQueue.Enqueue(command);
                _pendingCommands.Add(command);
                ProcessCommandQueue();
            }
        }

        // Process the command queue
        private async void ProcessCommandQueue()
        {
            if (_isProcessingCommandQueue) return;  // Prevent reentry if already processing
            _isProcessingCommandQueue = true;

            while (_commandQueue.TryDequeue(out string command))
            {
                try
                {
                    bool commandSent = await SendCommandAsync(command);  // Directly call SendCommandAsync
                    if (commandSent)
                    {
                        _pendingCommands.Remove(command);
                    }
                    else
                    {
                        AddConsoleError($"[ERROR] Failed to process command: {command}");
                    }
                }
                catch (Exception ex)
                {
                    AddConsoleError($"[ERROR] Exception while processing command: {ex.Message}");
                }
            }

            _isProcessingCommandQueue = false;  // Mark the end of processing
        }

        private async Task<bool> SendCommandAsync(string command)
        {
            return await _tcpConnectionHandler.SendCommandAsync(command);
        }



        // UI commands
        private void Request_Measure_Voltage() => EnqueueQuery("MEASure:VOLtage?");
        private void Request_Measure_Current() => EnqueueQuery("MEASure:CURrent?");
        private void Request_Measure_Power() => EnqueueQuery("MEASure:POWer?");
        private void Request_Source_Voltage() => EnqueueQuery("SOURce:VOLtage?");
        private void Request_Source_Current() => EnqueueQuery("SOURce:CURrent?");
        private void Request_Source_Current_Negative() => EnqueueQuery("SOURce:CURrent:NEGative?");
        private void Request_Source_Power() => EnqueueQuery("SOURce:POWer?");
        private void Request_Source_Power_Negative() => EnqueueQuery("SOURce:POWer:NEGative?");
        private void RequestRemoteSetting_CV() => EnqueueQuery("SYSTem:REMote:CV?");
        private void RequestRemoteSetting_CC() => EnqueueQuery("SYSTem:REMote:CC?");
        private void RequestRemoteSetting_CP() => EnqueueQuery("SYSTem:REMote:CP?");
        private void RequestTime() => EnqueueQuery("SYSTem:TIMe?");







        private void SetSystemRemoteSetting_CV(string state)
        {
            EnqueueCommand($"SYSTem:REMote:CV {state}");
        }

        private void SetSystemRemoteSetting_CC(string state)
        {
            EnqueueCommand($"SYSTem:REMote:CC {state}");
        }

        private void SetSystemRemoteSetting_CP(string state)
        {
            EnqueueCommand($"SYSTem:REMote:CP {state}");
        }

        private void SetOutputVoltage(double outputVoltage)
        {
            EnqueueCommand($"SOURce:VOLtage {outputVoltage}");
        }

        private void SetOutputCurrent(double outputCurrent)
        {
            EnqueueCommand($"SOURce:CURrent {outputCurrent}");
        }

        private void SetOutputCurrentNegative(double outputCurrentNegative)
        {
            EnqueueCommand($"SOURce:CURrent:NEGative {outputCurrentNegative}");
        }

        private void SetOutputPower(double outputPower)
        {
            EnqueueCommand($"SOURce:POWer {outputPower}");
        }

        private void SetOutputPowerNegative(double outputPowerNegative)
        {
            EnqueueCommand($"SOURce:POWer:NEGative {outputPowerNegative}");
        }

        private void toggleOutput()
        {
            if (_started)
            {
                EnqueueCommand("OUTPut ON\n");
                _stopwatch.Start();  // Start the stopwatch
            }
            else
            {
                EnqueueCommand("OUTPut OFF\n");
                _stopwatch.Stop();   // Stop the stopwatch
            }
        }

        #endregion




        private void AddConsoleError(string errorMessage)
        {
            DateTime currentTime = DateTime.Now;

            // Determine the type of message (error, info, warning)
            if (errorMessage.Contains("[ERROR]"))
            {
                // Update error messages
                if (_errorMessages.ContainsKey(errorMessage))
                {
                    _errorMessages[errorMessage] = (_errorMessages[errorMessage].Count + 1, currentTime);
                }
                else
                {
                    _errorMessages[errorMessage] = (1, currentTime);
                }
                UpdateErrorTab();  // Only show errors in the console
            }

            // Always log all messages (errors, info, warnings) for exporting
            if (_infoMessages.ContainsKey(errorMessage))
            {
                _infoMessages[errorMessage] = (_infoMessages[errorMessage].Count + 1, currentTime);
            }
            else
            {
                _infoMessages[errorMessage] = (1, currentTime);
            }
        }

        // Update the error messages in the Error Tab (Console)
        private void UpdateErrorTab()
        {
            var sb = new StringBuilder();
            var sortedErrors = _errorMessages.OrderByDescending(e => e.Value.LastOccurred);

            foreach (var error in sortedErrors)
            {
                string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                sb.AppendLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
            }

            // Display only errors in the Console (Error Tab)
            Console_Simple_Textbox_UI.Text = sb.ToString();
        }

        void CollectBatteryMetrics()
        {
            var metrics = new BatteryMetrics
            {
                Time = DateTime.Now,
                Voltage = currentVoltage,
                Current = currentCurrent,
                Power = currentPower
            };
            batteryData.Add(metrics);
        }



        // Manual Editing Toggle
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

        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',').ToArray());
        }

        private double ParseInput(string input)
        {
            if (double.TryParse(RemoveNonNumeric(input), out double result)) return result;
            return 0;
        }

        private void SaveSettings(double V, double A, double W, double N_A, double N_W)
        {
            _StoredVoltageSetting = V;
            _StoredCurrent = A;
            _StoredPower = W;
            _StoredNegativeCurrent = N_A;
            _StoredNegativePower = N_W;

            Properties.Settings.Default._StoredVoltageSetting = V;
            Properties.Settings.Default._StoredCurrent = A;
            Properties.Settings.Default._StoredPower = W;
            Properties.Settings.Default._StoredNegativeCurrent = N_A;
            Properties.Settings.Default._StoredNegativePower = N_W;

            Properties.Settings.Default._cRating = _cRating;
            Properties.Settings.Default._ratedVoltage = _ratedVoltage;
            Properties.Settings.Default._ratedCapacity = _ratedCapacity;
            Properties.Settings.Default._ratedPower = _ratedPower;

            InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
            InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
            InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
            InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
            InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";
            SetSettings();
        }

        private void SetSettings()
        {
            SetOutputVoltage(_StoredVoltageSetting);
            SetOutputCurrent(0);
            SetOutputPower(0);
            SetOutputCurrentNegative(0);
            SetOutputPowerNegative(0);

            if (_started)
            {
                switch (_SelectedProgram)
                {
                    case AvailablePrograms.Connecting_Battery:
                        SetOutputVoltage(_StoredVoltageSetting);
                        SetOutputCurrent(2);
                        break;
                    case AvailablePrograms.Charging:
                        SetOutputCurrent(_StoredCurrent);
                        SetOutputPower(_StoredPower);
                        break;
                    case AvailablePrograms.Discharging:
                        SetOutputCurrentNegative(_StoredNegativeCurrent);
                        SetOutputPowerNegative(_StoredNegativePower);
                        break;
                }
            }
        }

        private void UpdateFromBatteryLabelData(object sender, EventArgs e)
        {
            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryAmperageUI.Text);
            _cRating = ParseInput(C_Rating_UI.Text);
            CalculateWithCRating();
        }

        private void CalculateWithCRating()
        {
            double amps = _ratedCapacity * _cRating;  // How much current can be applied safely
            double watts = amps * _ratedVoltage;      // Power in watts
            _ratedPower = watts;

            SaveSettings(_ratedVoltage, amps, watts, -amps, -watts);

            // Calculate max charging time in hours, then convert to TimeSpan
            double maxChargingHours = _ratedCapacity / amps;
            _maxChargingTime = TimeSpan.FromHours(maxChargingHours);
        }

        // Function to calculate time to discharge to 30%
        private void CalculateDischargeTimeTo30Percent()
        {
            // Ensure _ratedCapacity and _cRating are not zero or negative
            if (_ratedCapacity <= 0 || _cRating <= 0)
            {
                MessageBox.Show("Invalid rated capacity or C-rating. Please check your battery settings.");
                return;
            }

            // Assuming you're discharging at _cRating * _ratedCapacity amps
            double dischargeCurrent = _ratedCapacity * _cRating;

            // Prevent division by zero
            if (dischargeCurrent <= 0)
            {
                MessageBox.Show("Discharge current is zero or invalid. Cannot calculate discharge time.");
                return;
            }

            // Full discharge time in hours
            double fullDischargeTimeHours = _ratedCapacity / dischargeCurrent;

            // Check for invalid result (NaN)
            if (double.IsNaN(fullDischargeTimeHours) || fullDischargeTimeHours <= 0)
            {
                MessageBox.Show("Calculated discharge time is invalid.");
                return;
            }

            // Time to discharge to 30% (70% of the full discharge time)
            _timeToDischarge30Percent = TimeSpan.FromHours(fullDischargeTimeHours * 0.70);
        }





        #region buttons

        private void LockButtons()
        {
            ChargeButton.Enabled = Charge30Button.Enabled = DischargeButton.Enabled = BatteryConnectButton.Enabled = !_started;
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Save as .txt file
                Title = "Save Factory Settings",
                FileName = "factory_settings.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var writer = new StreamWriter(filePath))
                {
                    // Save the settings in comma-separated format (CSV-like)
                    writer.WriteLine($"{_StoredVoltageSetting},{_StoredCurrent},{_StoredPower},{_StoredNegativeCurrent},{_StoredNegativePower}");
                }

                MessageBox.Show("Settings successfully saved to " + filePath);
            }
            else
            {
                MessageBox.Show("Save operation was canceled.");
            }
        }
        private void LoadSettings(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Load from .txt file
                Title = "Load Factory Settings"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // Split the values by comma
                        var values = line.Split(',');

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

                            MessageBox.Show("Settings successfully loaded from " + filePath);
                        }
                        else
                        {
                            MessageBox.Show("Error: Incorrect format in the settings file.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Load operation was canceled.");
            }
        }
        private void ExportToCsv(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Save Battery Data",
                FileName = "battery_data.csv"
            };

            // Show the dialog and check if the user clicks OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path selected by the user
                string filePath = saveFileDialog.FileName;

                // Write the CSV file
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                    foreach (var data in batteryData)
                    {
                        writer.WriteLine($"{data.Time},{data.Voltage},{data.Current},{data.Power}");  // Data rows
                    }
                }

                //MessageBox.Show("Data successfully saved to " + filePath);
            }
            else
            {
                MessageBox.Show("Save operation was canceled.");
            }
        }

        private void ExportLogToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Log file format
                Title = "Save Log File",
                FileName = "log.txt"  // Default file name
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Error Log:");
                    foreach (var error in _errorMessages.OrderByDescending(e => e.Value.LastOccurred))
                    {
                        string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
                    }

                    writer.WriteLine("\nInfo/Warning Log:");
                    foreach (var info in _infoMessages.OrderByDescending(i => i.Value.LastOccurred))
                    {
                        string formattedTime = info.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{formattedTime} - {info.Key} (Count: {info.Value.Count})");
                    }
                }

                //MessageBox.Show("Log file successfully saved to " + filePath);
            }
            else
            {
                MessageBox.Show("Save operation was canceled.");
            }
        }

        private void ToggleStartStopButton(object? sender, EventArgs? e)
        {
            _started = !_started;
            StartStopButton.BackColor = _started ? Color.Red : Color.Green;
            StartStopButton.Text = _started ? "Stop" : "Start";
            toggleOutput();
            SetSettings();

        }

        private void ChargeButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(ChargeButton);
            _SelectedProgram = AvailablePrograms.Charging;
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";
            batteryData.Clear();
            DischargeTo30Bool = false;
        }

        private void DischargeButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(DischargeButton);
            _SelectedProgram = AvailablePrograms.Discharging;
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";
            batteryData.Clear();
            DischargeTo30Bool = false;
        }

        private void DischargeTo30Button_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(Charge30Button);
            DischargeTo30Bool = true;
            _SelectedProgram = AvailablePrograms.Discharging;
            // Reset the stopwatch
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";
            batteryData.Clear();


            // Calculate the time to discharge to 30%
            CalculateDischargeTimeTo30Percent();
        }

        private void BatteryConnectButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(BatteryConnectButton);
            _SelectedProgram = AvailablePrograms.Connecting_Battery;
            DischargeTo30Bool = false;
            ToggleStartStopButton(sender, e);
        }

        private void UpdateButtonColors(System.Windows.Forms.Button clickedButton)
        {
            BatteryConnectButton.BackColor = SystemColors.Control;
            ChargeButton.BackColor = SystemColors.Control;
            DischargeButton.BackColor = SystemColors.Control;
            Charge30Button.BackColor = SystemColors.Control;

            clickedButton.BackColor = Color.Yellow;
        }

        #endregion

        private void toolStripMenuSetting_keepmemory_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default._KeepMemory = toolStripMenuSetting_keepmemory.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
