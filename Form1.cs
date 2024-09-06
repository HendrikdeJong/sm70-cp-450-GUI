using System.Net.Sockets;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class MainForm : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private const string ServerIp = "169.254.0.102";
        private const int ServerPort = 8462;

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
            DischargeTo30Procent
        }

        private double _ratedVoltage = 0;  // Voltage on label of battery
        private double _ratedCapacity = 0; // Amp/Hours on label of battery
        private double _cRating = 0; // C rating on label of battery
        private double _ratedPower = 0; //wattage able to be used

        private double _StoredVoltageSetting = 0;
        private double _StoredCurrent = 0;
        private double _StoredPower = 0;

        private double _StoredNegativeCurrent = 0;
        private double _StoredNegativePower = 0;


        //private string _remoteStatus_CV;
        //private string _remoteStatus_CC;
        //private string _remoteStatus_CP;

        public MainForm()
        {
            InitializeComponent();
            InitializeTcpClient();
            InitializeTimers();
            InitializeSettings();
        }

        private async void InitializeSettings()
        {
            await SetSystemRemoteSetting_CV("Remote");
            await SetSystemRemoteSetting_CC("Remote");
            await SetSystemRemoteSetting_CP("Remote");
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

        private void UpdateLoop()
        {
            LockButtons();
            UpdateUI();
        }

        private bool _updatingUI = false;

        private async void UpdateUI()
        {
            if (_updatingUI) return;  // Prevent overlapping updates
            _updatingUI = true;

            try
            {
                var voltageTask = MeasureOutputVoltage();
                var currentTask = MeasureOutputCurrent();
                var powerTask = MeasureOutputPower();

                await Task.WhenAll(voltageTask, currentTask, powerTask);  // Wait for all tasks to complete

                VoltageDisplay.Text = (await voltageTask / 10000).ToString() + " V";
                AmperageDisplay.Text = (await currentTask / 1000).ToString() + " A";
                WattageDisplay.Text = (await powerTask).ToString() + " W";

                StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();
                StartStopButton.Enabled = _SelectedProgram != AvailablePrograms.None;
            }
            finally
            {
                _updatingUI = false;
            }
        }

        private bool _updatingMachineValues = false;

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

        private void InitializeTcpClient()
        {
            _tcpClient = new TcpClient();
            try
            {
                _tcpClient.Connect(ServerIp, ServerPort);
                _networkStream = _tcpClient.GetStream();
                MessageBox.Show("TCP connection established.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TCP connection failed: " + ex.Message);
            }
        }

        private async Task<string> SendQueryAsync(string query, int timeoutMilliseconds = 5000)
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                // Display error in the status strip
                StatusCurrentOperation_UI.Text = "TCP connection is not open.";
                return null;
            }

            using (var cts = new CancellationTokenSource(timeoutMilliseconds))
            {
                try
                {
                    byte[] messageBuffer = Encoding.UTF8.GetBytes(query);

                    var writeTask = _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length, cts.Token);
                    var flushTask = _networkStream.FlushAsync(cts.Token);
                    var receiveTask = ReceiveMessageAsync(cts.Token);

                    await Task.WhenAny(writeTask, Task.Delay(timeoutMilliseconds, cts.Token));

                    if (writeTask.IsCompleted)
                    {
                        await flushTask;  // Ensure flushing is done
                        await Task.WhenAny(receiveTask, Task.Delay(timeoutMilliseconds, cts.Token));

                        if (receiveTask.IsCompleted)
                        {
                            return await receiveTask;
                        }
                    }

                    // If we reach here, the operation has timed out
                    StatusCurrentOperation_UI.Text = "Timeout occurred during network communication.";
                }
                catch (TaskCanceledException)
                {
                    StatusCurrentOperation_UI.Text = "Operation timed out.";
                }
                catch (Exception ex)
                {
                    StatusCurrentOperation_UI.Text = "Error sending query: " + ex.Message;
                }

                return null;
            }
        }


        //public async Task<bool> SendCommandAsync(string command)
        //{
        //    if (_networkStream == null || !_tcpClient.Connected)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        byte[] commandBuffer = Encoding.UTF8.GetBytes(command);
        //        await _networkStream.WriteAsync(commandBuffer, 0, commandBuffer.Length);
        //        await _networkStream.FlushAsync();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error sending command: " + ex.Message);
        //        return false;
        //    }
        //}

        private async Task<string> ReceiveMessageAsync(CancellationToken cancellationToken)
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                // Display error in the status strip
                StatusCurrentOperation_UI.Text = "Network stream is not available.";
                return null;
            }

            try
            {
                var buffer = new byte[1024];
                var stringBuilder = new StringBuilder();
                int bytesRead;

                do
                {
                    // Use ReadAsync with the cancellationToken
                    bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                    stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                } while (_networkStream.DataAvailable && !cancellationToken.IsCancellationRequested);

                return stringBuilder.ToString();
            }
            catch (TaskCanceledException)
            {
                StatusCurrentOperation_UI.Text = "Message receiving operation was canceled.";
                return null;
            }
            catch (Exception ex)
            {
                StatusCurrentOperation_UI.Text = "Error receiving message: " + ex.Message;
                return null;
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


        public async Task<string> OutputVoltage()
        {
            string response = await SendQueryAsync("SOURce:VOLtage? \n");
            return response;
        }

        public async Task<string> OutputCurrent()
        {
            string response = await SendQueryAsync("SOURce:CURrent? \n");
            return response;
        }
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



        public async Task<double> SetOutputVoltage(double OutputVoltage)
        {
            string response = await SendQueryAsync($"SOURce:VOltage {OutputVoltage}\n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> SetOutputCurrent(double OutputCurrent)
        {
            string response = await SendQueryAsync($"SOURce:CURrent {OutputCurrent}\n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> SetOutputCurrentNegative(double OutputCurrentNegative)
        {
            string response = await SendQueryAsync($"SOURce:CURrent:NEGative {OutputCurrentNegative}\n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> SetOutputPower(double OutputPower)
        {
            string response = await SendQueryAsync($"SOURce:POWer {OutputPower}\n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> SetOutputPowerNegative(double OutputPowerNegative)
        {
            string response = await SendQueryAsync($"SOURce:POWer:NEGative {OutputPowerNegative}\n");
            return ParseResponseToDouble(response);
        }


        public async Task<string> SetSystemRemoteSetting_CV(string state)
        {
            string response = await SendQueryAsync($"SYSTem:REMote:CV {state}\n");
            return response;
        }
        public async Task<string> SetSystemRemoteSetting_CC(string state)
        {
            string response = await SendQueryAsync($"SYSTem:REMote:CV {state}\n");
            return response;
        }
        public async Task<string> SetSystemRemoteSetting_CP(string state)
        {
            string response = await SendQueryAsync($"SYSTem:REMote:CV {state}\n");
            return response;
        }
        #endregion




        #region Functions

        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',').ToArray());
        }

        private void CalculateWith_cRating()
        {
            double amps = _ratedCapacity * _cRating;
            double watts = amps * _ratedVoltage;
            _ratedPower = watts;
            SaveSettings(_ratedVoltage, amps, watts, -amps, -watts);
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
                UpdateFromManualOveride();
            }
            else
            {
                Button_Toggle_ValueEditor.Text = "Edit Values";
                UpdateFromManualOveride();
            }
        }
        private void UpdateFromManualOveride()
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
                        await SetOutputCurrent(.5);
                        break;
                    case AvailablePrograms.Charging:
                        await SetOutputCurrent(_StoredCurrent);
                        await SetOutputPower(_StoredPower);
                        break;
                    case AvailablePrograms.Discharging:
                        await SetOutputCurrentNegative(_StoredNegativeCurrent);
                        await SetOutputPowerNegative(_StoredNegativePower);
                        break;
                    case AvailablePrograms.DischargeTo30Procent:
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

        private async void toggleOutput()
        {
            if (_started) await SendQueryAsync("OUTPut ON\n");
            else await SendQueryAsync("OUTPut OFF\n");

        }
        #endregion

        #region Buttons


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
            _SelectedProgram = AvailablePrograms.DischargeTo30Procent;
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
