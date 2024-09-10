using System.ComponentModel.Design;
using System.Net.Sockets;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private Dictionary<string, int> _errorMessages = new Dictionary<string, int>();
        private SemaphoreSlim _commandQueueSemaphore = new SemaphoreSlim(1, 1); // Ensures sequential command execution
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private const string ServerIp = "169.254.0.102";
        private const int ServerPort = 8462;


        private bool _tcpInitialized = false;
        private bool _updatingMachineValues = false;
        private bool _updatingUI = false;
        private bool _EditingValues = false;
        private bool _started = false;
        private bool _discharged = false;

        private AvailablePrograms _SelectedProgram = AvailablePrograms.None;

        private enum AvailablePrograms
        {
            None,
            Connecting_Battery,
            Charging,
            Discharging,
            DischargeTo30Percent
        }

        private double _ratedVoltage = 0;  // Voltage on label of battery
        private double _ratedCapacity = 0; // Amp/Hours on label of battery
        private double _cRating = 0; // C rating on label of battery
        private double _ratedPower = 0; 

        private double _StoredVoltageSetting = 0;
        private double _StoredCurrent = 0;
        private double _StoredPower = 0;

        private double _StoredNegativeCurrent = 0;
        private double _StoredNegativePower = 0;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
            
            InitializeTimers();
            InitializeSettings();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Show();

            // Attempt to establish the TCP connection
            MessageBox.Show("Attempting to establish TCP connection. Please wait...");

            // Await the initialization of TCP connection
            bool connectionEstablished = await InitializeTcpClient();

            if (connectionEstablished)
            {
                // Proceed with timer and settings initialization if TCP connection is successful
                InitializeTimers();
                await InitializeSettings(); // Ensure settings initialization is awaited if it has async operations
            }
            else
            {
                // Handle the case where TCP connection fails
            }
        }

        private async Task InitializeSettings()
        {
            await SetSystemRemoteSetting_CV("Remote");
            await SetSystemRemoteSetting_CC("Remote");
            await SetSystemRemoteSetting_CP("Remote");
            await SystemRemoteSetting_CV();
            await SystemRemoteSetting_CC();
            await SystemRemoteSetting_CP();
        }

        private void InitializeTimers()
        {
            var updateTimer = new Timer
            {
                Interval = 500 // 500 milliseconds = 0.5 seconds
            };
            updateTimer.Tick += (sender, e) => UpdateLoop();
            updateTimer.Start();

            var SystemDisplay = new Timer
            {
                Interval = 5000 // 5000 milliseconds = 5 seconds
            };
            SystemDisplay.Tick += (sender, e) => GetValuesFromMachine();
            SystemDisplay.Start();
        }



        private async void UpdateLoop()
        {
            await _commandQueueSemaphore.WaitAsync();
            try
            {
                LockButtons();
                await UpdateUI();
                await UpdateConsoleErrors(); // Check for system errors and warnings
            }
            finally
            {
                _commandQueueSemaphore.Release();
            }
        }


        private async Task UpdateUI()
        {
            var voltageTask = MeasureOutputVoltage();
            var currentTask = MeasureOutputCurrent();
            var powerTask = MeasureOutputPower();

            await Task.WhenAll(voltageTask, currentTask, powerTask);

            VoltageDisplay.Text = (await voltageTask / 10000).ToString() + " V";
            AmperageDisplay.Text = (await currentTask / 1000).ToString() + " A";
            WattageDisplay.Text = (await powerTask).ToString() + " W";

            StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();
        }


        private async void GetValuesFromMachine()
        {
            if (_updatingMachineValues) return;  // Prevent overlapping updates
            _updatingMachineValues = true;

            try
            {
                Label_MachineAppliedVoltage_UI.Text = await OutputVoltage();
                Label_MachineAppliedCurrentPlus_UI.Text = await OutputPower();
                Label_MachineAppliedPowerPlus_UI.Text = await OutputPower();

                Label_MachineAppliedCurrentMin_UI.Text = await OutputCurrentNegative();
                Label_MachineAppliedPowerMin_UI.Text = await OutputPowerNegative();

                Label_Remote_CV_UI.Text = await SystemRemoteSetting_CV();
                Label_Remote_CC_UI.Text = await SystemRemoteSetting_CC();
                Label_Remote_CP_UI.Text = await SystemRemoteSetting_CP();
            }
            finally
            {
                _updatingMachineValues = false;
            }
        }


        private double ParseResponseToDouble(string response)
        {
            return double.TryParse(response, out double result) ? result : double.NaN;
        }

        #region TCP Socket

        private async Task<bool> InitializeTcpClient()
        {
            _tcpClient = new TcpClient();
            try
            {
                // Attempt to connect asynchronously
                await _tcpClient.ConnectAsync(ServerIp, ServerPort);
                _networkStream = _tcpClient.GetStream();
                _tcpInitialized = true;
                MessageBox.Show("TCP connection established.");
                AddConsoleError("TCP connection established");
                return true; // Indicate successful connection
            }
            catch (Exception ex)
            {
                // Notify the user of the failure
                AddConsoleError("TCP connection failed: " + ex.Message);
                MessageBox.Show("TCP connection failed: " + ex.Message);
                _tcpInitialized = false;
                return false; // Indicate failed connection
            }
        }

        private async Task<string> SendQueryAsync(string query, int timeoutMilliseconds = 10000)
        {
            if (!_tcpInitialized)
            {
                AddConsoleError($"TCP connection is not yet established: {_tcpInitialized}");
                return null;  // Return null if TCP is not initialized
            }

            // Attempt to acquire the semaphore within a specified timeout
            if (await _commandQueueSemaphore.WaitAsync(TimeSpan.FromSeconds(2)))
            {
                try
                {
                    if (_networkStream == null || !_tcpClient.Connected)
                    {
                        AddConsoleError($"TCP connection is not open or network stream is invalid: tcp connected: {_tcpClient?.Connected ?? false}, Network stream: {_networkStream != null}");
                        return null;
                    }

                    using (var cts = new CancellationTokenSource(timeoutMilliseconds))
                    {
                        // Sending the query
                        byte[] messageBuffer = Encoding.UTF8.GetBytes(query + "\n");
                        AddConsoleError($"Sending query: '{query}'");
                        await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length, cts.Token);
                        await _networkStream.FlushAsync(cts.Token); // Ensure the data is sent out
                        AddConsoleError("Query sent successfully.");

                        _commandQueueSemaphore.Release(); // Release semaphore here, so it is immediately available for new queries

                        // Reading the response (done outside of semaphore)
                        var buffer = new byte[1024];
                        var stringBuilder = new StringBuilder();
                        int bytesRead = 0;

                        do
                        {
                            bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                            if (bytesRead > 0)
                            {
                                stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                            }
                            AddConsoleError($"Received {bytesRead} bytes.");
                        } while (_networkStream.DataAvailable && !cts.Token.IsCancellationRequested);

                        var response = stringBuilder.ToString().Trim();
                        AddConsoleError($"Response received: '{response}'");
                        return response;
                    }
                }
                catch (TaskCanceledException)
                {
                    AddConsoleError("Operation timed out.");
                    _commandQueueSemaphore.Release(); // Ensure release of semaphore even on timeout
                    return null;
                }
                catch (Exception ex)
                {
                    AddConsoleError("Error sending query: " + ex.Message);
                    _commandQueueSemaphore.Release(); // Ensure release of semaphore even on exception
                    return null;
                }
            }
            else
            {
                AddConsoleError("Failed to acquire semaphore within the timeout period.");
                return null;
            }
        }



        private async Task<bool> SendCommandAsync(string command, int timeoutMilliseconds = 10000)
        {
            AddConsoleError($"[Info] Attempting to send command: {command.Trim()}");

            if (!_tcpInitialized)
            {
                AddConsoleError($"[Error] TCP connection is not yet established: {_tcpInitialized}");
                return false;
            }

            await _commandQueueSemaphore.WaitAsync();
            AddConsoleError("[Info] Entered semaphore.");

            try
            {
                if (_networkStream == null)
                {
                    AddConsoleError("[Error] Network stream is null.");
                    return false;
                }
                if (!_tcpClient.Connected)
                {
                    AddConsoleError("[Error] TCP client is not connected.");
                    return false;
                }
                if (!_networkStream.CanWrite)
                {
                    AddConsoleError("[Error] Network stream cannot write.");
                    return false;
                }

                AddConsoleError("[Info] Network stream and TCP connection are valid.");

                // Send the command
                using (var cts = new CancellationTokenSource(timeoutMilliseconds))
                {
                    try
                    {
                        byte[] messageBuffer = Encoding.UTF8.GetBytes(command + "\n");
                        await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length, cts.Token);
                        await _networkStream.FlushAsync(cts.Token); // Ensure the data is sent out

                        AddConsoleError($"[Info] Command '{command.Trim()}' sent successfully.");
                        return true; // Indicate successful sending
                    }
                    catch (TaskCanceledException)
                    {
                        AddConsoleError("[Error] Command operation timed out.");
                    }
                    catch (Exception ex)
                    {
                        AddConsoleError($"[Error] Exception occurred while sending command: {ex.Message}");
                    }

                    return false; // Indicate failure
                }
            }
            finally
            {
                _commandQueueSemaphore.Release();
                AddConsoleError("[Info] Semaphore released.");
            }
        }



        #endregion

        #region Query Methods


        //public async Task<double> MaxOutputVoltage()
        //{
        //    string response = await SendQueryAsync("SOURce:VOLtage:MAXimum? \n");
        //    return ParseResponseToDouble(response);
        //}

        //public async Task<double> MaxOutputCurrent()
        //{
        //    string response = await SendQueryAsync("SOURce:CURrent:MAXimum? \n");
        //    return ParseResponseToDouble(response);
        //}

        //public async Task<double> MaxOutputCurrentNegative()
        //{
        //    string response = await SendQueryAsync("SOURce:CURrent:NEGative:MAXimum? \n");
        //    return ParseResponseToDouble(response);
        //}

        //public async Task<double> MaxOutputPower()
        //{
        //    string response = await SendQueryAsync("SOURce:POWer:MAXimum? \n");
        //    return ParseResponseToDouble(response);
        //}
        //public async Task<double> MaxNegativeOutputPower()
        //{
        //    string response = await SendQueryAsync("SOURce:POWer:NEGative:MAXimum? \n");
        //    return ParseResponseToDouble(response);
        //}

        private async Task<string> QuerySystemError()
        {
            return await SendQueryAsync("SYSTem:ERRor? \n");
        }

        private async Task<string> QuerySystemWarning()
        {
            return await SendQueryAsync("SYSTem:WARning? \n");
        }

        public async Task<string> OutputVoltage()
        {
            string response = await SendQueryAsync("SOURce:VOLtage? \n");
            return response;
        }

        //public async Task<string> OutputCurrent()
        //{
        //    string response = await SendQueryAsync("SOURce:CURrent? \n");
        //    return response;
        //}
        public async Task<string> OutputCurrentNegative()
        {
            string response = await SendQueryAsync("SOURce:CURrent:NEGative? \n");
            return response;
        }
        public async Task<string> OutputPower()
        {
            string response = await SendQueryAsync("SOURce:POWer? \n");
            return response;
        }
        public async Task<string> OutputPowerNegative()
        {
            string response = await SendQueryAsync("SOURce:POWer:NEGative? \n");
            return response;
        }

        public async Task<double> MeasureOutputVoltage()
        {
            string response = await SendQueryAsync("MEASure:VOLtage? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> MeasureOutputCurrent()
        {
            string response = await SendQueryAsync("MEASure:CURrent? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> MeasureOutputPower()
        {
            string response = await SendQueryAsync("MEASure:POWer? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<string> SystemRemoteSetting_CV()
        {
            string response = await SendQueryAsync("SYSTem:REMote:CV? \n");
            return response;
        }

        public async Task<string> SystemRemoteSetting_CC()
        {
            string response = await SendQueryAsync("SYSTem:REMote:CC? \n");
            return response;
        }

        public async Task<string> SystemRemoteSetting_CP()
        {
            string response = await SendQueryAsync("SYSTem:REMote:CP? \n");
            return response;
        }



        public async Task<bool> SetOutputVoltage(double OutputVoltage)
        {
            return await SendCommandAsync($"SOURce:VOltage {OutputVoltage.ToString()}\n");
            
        }
        public async Task<bool> SetOutputCurrent(double OutputCurrent)
        {
            return await SendCommandAsync($"SOURce:CURrent {OutputCurrent.ToString()}\n");
            
        }
        public async Task<bool> SetOutputCurrentNegative(double OutputCurrentNegative)
        {
            return await SendCommandAsync($"SOURce:CURrent:NEGative {OutputCurrentNegative.ToString()}\n");
            
        }
        public async Task<bool> SetOutputPower(double OutputPower)
        {
            return await SendCommandAsync($"SOURce:POWer {OutputPower.ToString()}\n");
            
        }
        public async Task<bool> SetOutputPowerNegative(double OutputPowerNegative)
        {
            return await SendCommandAsync($"SOURce:POWer:NEGative {OutputPowerNegative.ToString()}\n");
            
        }


        public async Task<bool> SetSystemRemoteSetting_CV(string state)
        {
            return await SendCommandAsync($"SYSTem:REMote:CV {state}\n");
            
        }
        public async Task<bool> SetSystemRemoteSetting_CC(string state)
        {
            return await SendCommandAsync($"SYSTem:REMote:CC {state}\n");
            
        }
        public async Task<bool> SetSystemRemoteSetting_CP(string state)
        {
            return await SendCommandAsync($"SYSTem:REMote:CP {state}\n");
            
        }
        #endregion

        #region Functions

        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',').ToArray());
        }


        private double ParseInput(string input)
        {
            if (double.TryParse(RemoveNonNumeric(input), out double result))
            {
                return result;
            }
            else
            {
                //MessageBox.Show($"Invalid input: {input}");
                return 0;
            }
        }

        private async Task UpdateConsoleErrors()
        {
            var errorResponse = await QuerySystemError();
            var warningResponse = await QuerySystemWarning();

            // Process and add errors to console
            if (!string.IsNullOrEmpty(errorResponse))
            {
                AddConsoleError($"System Error: {errorResponse}");
            }

            // Process and add warnings to console
            if (!string.IsNullOrEmpty(warningResponse))
            {
                AddConsoleError($"System Warning: {warningResponse}");
            }
        }

        private void AddConsoleError(string errorMessage)
        {
            
            // Update the error count dictionary
            if (_errorMessages.ContainsKey(errorMessage))
            {
                _errorMessages[errorMessage]++;
            }
            else
            {
                _errorMessages[errorMessage] = 1;
            }

            // Build the full error log with counts
            var sb = new StringBuilder();
            foreach (var error in _errorMessages)
            {
                sb.AppendLine($"{error.Key} (Count: {error.Value})");
            }

            // Apply color to the output
            Console_ErrorTextbox_UI.Text = sb.ToString();
        }


        #endregion

        #region outputvalues

        private void ToggleManualEditing(object sender, EventArgs e)
        {
            _EditingValues = !_EditingValues;
            InputField_StoredValueVoltage.ReadOnly = !_EditingValues;
            InputField_StoredValueCurrentPlus.ReadOnly = !_EditingValues;
            InputField_StoredValuePowerPlus.ReadOnly = !_EditingValues;

            InputField_StoredValueCurrentMin.ReadOnly = !_EditingValues;
            InputField_StoredValuePowerMin.ReadOnly = !_EditingValues;

            if (_EditingValues == true)
            {
                Button_Toggle_ValueEditor.Text = "Save And Update Values";
                UpdateFromManualOverride();
            }
            else
            {
                Button_Toggle_ValueEditor.Text = "Edit Values";
                UpdateFromManualOverride();
            }
        }
        private void UpdateFromManualOverride()
        {
            _StoredVoltageSetting = ParseInput(InputField_StoredValueVoltage.Text);
            _StoredCurrent = ParseInput(InputField_StoredValueCurrentPlus.Text);
            _StoredPower = ParseInput(InputField_StoredValuePowerPlus.Text);

            _StoredNegativeCurrent = ParseInput(InputField_StoredValueCurrentMin.Text);
            _StoredNegativePower = ParseInput(InputField_StoredValuePowerMin.Text);

            SaveSettings(_StoredVoltageSetting, _StoredCurrent, _StoredPower, _StoredNegativeCurrent, _StoredNegativePower);
        }
        private void UpdateFromBatteryLabelData(object sender, EventArgs e)
        {
            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryAmperageUI.Text);
            _cRating = ParseInput(C_Rating_UI.Text);
            CalculateWith_cRating();
        }
        private void CalculateWith_cRating()
        {
            double amps = _ratedCapacity * _cRating;
            double watts = amps * _ratedVoltage;
            _ratedPower = watts;
            SaveSettings(_ratedVoltage, amps, watts, -amps, -watts);
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
        private async void SetSettings()
        {
            await SetOutputVoltage(_StoredVoltageSetting);
            await SetOutputCurrent(0);
            await SetOutputPower(0);
            await SetOutputCurrentNegative(0);
            await SetOutputPowerNegative(0);

            if (_started)
            {
                switch (_SelectedProgram)
                {
                    case AvailablePrograms.None:
                        break;
                    case AvailablePrograms.Connecting_Battery:

                        await SetOutputVoltage(_StoredVoltageSetting);
                        await SetOutputCurrent(2);
                        break;
                    case AvailablePrograms.Charging:
                        await SetOutputCurrent(_StoredCurrent);
                        await SetOutputPower(_StoredPower);
                        break;
                    case AvailablePrograms.Discharging:
                        await SetOutputCurrentNegative(_StoredNegativeCurrent);
                        await SetOutputPowerNegative(_StoredNegativePower);
                        break;
                    case AvailablePrograms.DischargeTo30Percent:
                        if (!_discharged)
                        {
                            await SetOutputCurrentNegative(_StoredNegativeCurrent);
                            await SetOutputPowerNegative(_StoredNegativePower);
                        }
                        else if (_discharged)
                        {
                            await SetOutputCurrent(_StoredCurrent);
                            await SetOutputPower(_StoredPower);
                        }
                        break;
                }
            }

        }


        #endregion

        #region Buttons

        private async void toggleOutput()
        {
            if (_started) await SendCommandAsync("OUTPut ON\n");
            else await SendCommandAsync("OUTPut OFF\n");

        }

        private void LockButtons()
        {
            ChargeButton.Enabled = Charge30Button.Enabled = DischargeButton.Enabled = BatteryConnectButton.Enabled = !_started;
        }

        private void UpdateButtonColors(Button clickedButton)
        {
            // Reset all button colors
            BatteryConnectButton.BackColor = SystemColors.Control;
            ChargeButton.BackColor = SystemColors.Control;
            DischargeButton.BackColor = SystemColors.Control;
            Charge30Button.BackColor = SystemColors.Control;

            // Set the clicked button's color to Yellow
            clickedButton.BackColor = Color.Yellow;
        }



        private void ToggleStartStopButton(object sender, EventArgs e)
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
        }

        private void DischargeButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(DischargeButton);
            _SelectedProgram = AvailablePrograms.Discharging;
        }

        private void Charge30Button_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(Charge30Button);
            _SelectedProgram = AvailablePrograms.DischargeTo30Percent;
        }
        private void BatteryConnectButton_Click(object sender, EventArgs e)
        {
            UpdateButtonColors(BatteryConnectButton);
            _SelectedProgram = AvailablePrograms.Connecting_Battery;

            ToggleStartStopButton(sender, e);
        }
        #endregion

    }
}
