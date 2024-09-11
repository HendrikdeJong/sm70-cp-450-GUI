using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private const string ServerIp = "169.254.0.102";
        private const int ServerPort = 8462;
        private bool _tcpInitialized = false;
        private bool _started = false;
        private bool _discharged = false;
        private bool _EditingValues = false;
        private AvailablePrograms _SelectedProgram = AvailablePrograms.None;

        //console log
        private Dictionary<string, (int Count, DateTime LastOccurred)> _errorMessages = new Dictionary<string, (int Count, DateTime LastOccurred)>();
        private Dictionary<string, (int Count, DateTime LastOccurred)> _infoMessages = new Dictionary<string, (int Count, DateTime LastOccurred)>();

        private bool _showAll = false;

        private double _ratedVoltage = 0;
        private double _ratedCapacity = 0;
        private double _cRating = 0;
        private double _ratedPower = 0;

        private TimeSpan _timeToDischarge30Percent;

        private Stopwatch _stopwatch = new Stopwatch();
        private TimeSpan _maxChargingTime;

        private double _StoredVoltageSetting = 0;
        private double _StoredCurrent = 0;
        private double _StoredPower = 0;
        private double _StoredNegativeCurrent = 0;
        private double _StoredNegativePower = 0;

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
            DischargeTo30Percent
        }

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;

            // UI actions associated with commands
            _commandToUIActions = new Dictionary<string, Action<string>>
            {
                { "MEASure:VOLtage?", (response) => VoltageDisplay.Text = response + " V" },
                { "MEASure:CURrent?", (response) => AmperageDisplay.Text = response + " A" },
                { "MEASure:POWer?", (response) => WattageDisplay.Text = response + " W" },

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
            MessageBox.Show("Attempting to establish TCP connection. Please wait...");
            bool connectionEstablished = await InitializeTcpClient();

            if (connectionEstablished)
            {
                InitializeTimers();
                InitializeSettings();
            }
            else
            {
                MessageBox.Show("TCP connection failed.");
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

                RequestTime();

                LockButtons();

                // Always update the elapsed time display
                if (_stopwatch.IsRunning)
                {
                    TimeSpan elapsed = _stopwatch.Elapsed;
                    Label_Elapsed_Time_UI.Text = $"{elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}";
                }

                // Monitor the battery during discharging
                if (_SelectedProgram == AvailablePrograms.DischargeTo30Percent)
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
                    MessageBox.Show("Battery has been discharged to approximately 30% capacity.");
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


        private async Task<bool> InitializeTcpClient()
        {
            _tcpClient = new TcpClient();
            try
            {
                await _tcpClient.ConnectAsync(ServerIp, ServerPort);
                _networkStream = _tcpClient.GetStream();
                _tcpInitialized = true;
                MessageBox.Show("TCP connection established.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TCP connection failed: " + ex.Message);
                _tcpInitialized = false;
                return false;
            }
        }



        // Enqueue a query (response expected)
        private void EnqueueQuery(string query)
        {
            if (!_tcpInitialized)
            {
                AddConsoleError("[ERROR] Cannot enqueue query: TCP connection is not initialized.");
                return; // Prevent adding to the queue if TCP is not initialized
            }
            if (!_pendingQueries.Contains(query))
            {
                _queryQueue.Enqueue(query);
                _pendingQueries.Add(query);
                ProcessQueryQueue();
            }
        }

        // Process the query queue
        // Process the query queue
        private async void ProcessQueryQueue()
        {
            if (_isProcessingQueryQueue) return;
            _isProcessingQueryQueue = true;
            AddConsoleError("[INFO] Starting to process query queue.");

            while (_queryQueue.TryDequeue(out string query))
            {
                AddConsoleError($"[INFO] Processing query: {query}");
                _pendingQueries.Remove(query);

                string response = await SendQueryAsync(query);
                AddConsoleError("[INFO] Trying to get query response");

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
                    AddConsoleError($"[ERROR] No response for query: {query}");
                }
            }

            AddConsoleError("[INFO] Finished processing query queue.");
            _isProcessingQueryQueue = false;
        }


        // Send query to the device (expects a response)
        private async Task<string> SendQueryAsync(string query, int timeoutMilliseconds = 10000)
        {
            if (!_tcpInitialized)
            {
                AddConsoleError($"[ERROR] TCP connection is not yet established.");
                return null;
            }

            try
            {
                if (_networkStream == null || !_tcpClient.Connected)
                {
                    AddConsoleError("[ERROR] TCP connection is not open or network stream is invalid.");
                    return null;
                }

                using (var cts = new CancellationTokenSource(timeoutMilliseconds))
                {
                    byte[] messageBuffer = Encoding.UTF8.GetBytes(query + "\n");
                    //AddConsoleError($"[INFO] Sending query: {query}");
                    await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length, cts.Token);
                    await _networkStream.FlushAsync(cts.Token);

                    var buffer = new byte[1024];
                    var stringBuilder = new StringBuilder();
                    int bytesRead;
                    AddConsoleError($"[INFO] Waiting for response to query: {query}");

                    do
                    {
                        bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                        if (bytesRead > 0)
                        {
                            stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                            AddConsoleError($"[INFO] Received {bytesRead} bytes of data.");
                        }
                        else
                        {
                            AddConsoleError("[INFO] No more data available.");
                        }
                    } while (_networkStream.DataAvailable && !cts.Token.IsCancellationRequested);

                    string response = stringBuilder.ToString().Trim();
                    AddConsoleError($"[INFO] Complete response received: {response}");

                    return response;
                }
            }
            catch (Exception ex)
            {
                AddConsoleError($"[ERROR] Error sending query: {ex.Message}");
                return null;
            }
        }



        // Enqueue a command (no response expected)
        private void EnqueueCommand(string command)
        {
            if (!_tcpInitialized)
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
            if (_isProcessingCommandQueue) return;
            _isProcessingCommandQueue = true;

            while (_commandQueue.TryDequeue(out string command))
            {
                _pendingCommands.Remove(command);
                await SendCommandAsync(command);
            }

            _isProcessingCommandQueue = false;
        }

       

        // Send command to the device (no response expected)
        private async Task<bool> SendCommandAsync(string command)
        {
            if (!_tcpInitialized)
            {
                AddConsoleError($"TCP connection is not yet established.");
                return false;
            }

            try
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(command + "\n");
                await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length);
                await _networkStream.FlushAsync();

                return true;
            }
            catch (Exception ex)
            {
                AddConsoleError($"Error sending command: {ex.Message}");
                return false;
            }
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







        private  void SetSystemRemoteSetting_CV(string state)
        {
            EnqueueCommand($"SYSTem:REMote:CV {state}");
        }

        private  void SetSystemRemoteSetting_CC(string state)
        {
            EnqueueCommand($"SYSTem:REMote:CC {state}");
        }

        private  void SetSystemRemoteSetting_CP(string state)
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

        private  void SetOutputCurrentNegative(double outputCurrentNegative)
        {
            EnqueueCommand($"SOURce:CURrent:NEGative {outputCurrentNegative}");
        }

        private void SetOutputPower(double outputPower)
        {
            EnqueueCommand($"SOURce:POWer {outputPower}");
        }

        private  void SetOutputPowerNegative(double outputPowerNegative)
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
                UpdateErrorTab();
            }
            else
            {
                // Update info or warning messages
                if (_infoMessages.ContainsKey(errorMessage))
                {
                    _infoMessages[errorMessage] = (_infoMessages[errorMessage].Count + 1, currentTime);
                }
                else
                {
                    _infoMessages[errorMessage] = (1, currentTime);
                }
                UpdateInfoTab();
            }
        }

        // Update the error messages in the Error Tab
        private void UpdateErrorTab()
        {
            var sb = new StringBuilder();
            var sortedErrors = _errorMessages.OrderByDescending(e => e.Value.LastOccurred);

            foreach (var error in sortedErrors)
            {
                string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                sb.AppendLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
            }

            // Assume ErrorTab_TextBox is the textbox in the Error Tab
            Console_Simple_Textbox_UI.Text = sb.ToString();
        }

        // Update the info/warning messages in the Info Tab
        private void UpdateInfoTab()
        {
            var sb = new StringBuilder();
            var sortedInfos = _infoMessages.OrderByDescending(e => e.Value.LastOccurred);

            foreach (var info in sortedInfos)
            {
                string formattedTime = info.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                sb.AppendLine($"{formattedTime} - {info.Key} (Count: {info.Value.Count})");
            }

            // Assume InfoTab_TextBox is the textbox in the Info Tab
            Console_Advanced_Textbox_UI.Text = sb.ToString();
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
                    case AvailablePrograms.DischargeTo30Percent:
                        if (!_discharged)
                        {
                            SetOutputCurrentNegative(_StoredNegativeCurrent);
                            SetOutputPowerNegative(_StoredNegativePower);
                        }
                        else if (_discharged)
                        {
                            SetOutputCurrent(_StoredCurrent);
                            SetOutputPower(_StoredPower);
                        }
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






        // Button Handling

        private void LockButtons()
        {
            ChargeButton.Enabled = Charge30Button.Enabled = DischargeButton.Enabled = BatteryConnectButton.Enabled = !_started;
        }

        private void ToggleStartStopButton(object? sender, EventArgs? e)
        {
            _started = !_started;
            StartStopButton.BackColor = _started ? Color.Red : Color.Green;
            StartStopButton.Text = _started ? "Stop" : "Start";
            toggleOutput();
            SetSettings();
        }

        private void ToggleShowAllMessages(object sender, EventArgs e)
        {
            _showAll = !_showAll;  // Toggle between showing all messages and showing only errors
            AddConsoleError("");    // Refresh the error log display
        }

        private void ChargeButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(ChargeButton);
            _SelectedProgram = AvailablePrograms.Charging;
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";
        }

        private void DischargeButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(DischargeButton);
            _SelectedProgram = AvailablePrograms.Discharging;
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";
        }

        //private void Charge30Button_Click(object sender, EventArgs e)
        //{
        //    UpdateButtonColors(Charge30Button);
        //    _SelectedProgram = AvailablePrograms.DischargeTo30Percent;
        //    _stopwatch.Reset();
        //    Label_Elapsed_Time_UI.Text = "00:00:00";
        //}


        private void Charge30Button_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(Charge30Button);
            _SelectedProgram = AvailablePrograms.DischargeTo30Percent;

            // Reset the stopwatch
            _stopwatch.Reset();
            Label_Elapsed_Time_UI.Text = "00:00:00";

            // Calculate the time to discharge to 30%
            CalculateDischargeTimeTo30Percent();
        }

        private void BatteryConnectButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(BatteryConnectButton);
            _SelectedProgram = AvailablePrograms.Connecting_Battery;
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
    }
}
