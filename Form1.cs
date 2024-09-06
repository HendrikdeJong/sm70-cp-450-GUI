using System.Net.Sockets;
using System.Text;
using Timer = System.Windows.Forms.Timer;

namespace sm70_cp_450_GUI
{
    public partial class Form1 : Form
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

        private double _appliedVoltage = 0;
        private double _appliedCurrent = 0;
        private double _appliedPower = 0;

        private double _negativeAppliedCurrent = 0;
        private double _negativeAppliedPower = 0;

        private double _highestBatteryvoltage = 0;

        private string _remoteStatus_CV;
        private string _remoteStatus_CC;
        private string _remoteStatus_CP;

        public Form1()
        {
            InitializeComponent();
            InitializeTcpClient();
            InitializeUpdateTimer();
            InitializeSettings();
        }

        private async void InitializeSettings()
        {
            await SetSystemRemoteSetting_CV("Remote");
            await SetSystemRemoteSetting_CC("Remote");
            await SetSystemRemoteSetting_CP("Remote");
        }

        private void InitializeUpdateTimer()
        {
            var updateTimer = new Timer
            {
                Interval = 500 // 100 milliseconds = 0.1 seconds
            };
            updateTimer.Tick += (sender, e) => UpdateLoop();
            updateTimer.Start();
        }

        private void UpdateLoop()
        {
            LockButtons();
            UpdateUI();
        }

        private async void UpdateUI()
        {
            double voltage = await MeasureOutputVoltage();
            double current = await MeasureOutputCurrent();
            double power = await MeasureOutputPower();
            double status = await PowerSinkOutput();



            VoltageDisplay.Text = (voltage / 10000).ToString();
            AmperageDisplay.Text = (current / 1000).ToString();
            WattageDisplay.Text = (power).ToString();

            StatusCurrentOperation_UI.Text = _SelectedProgram.ToString();

            StartStopButton.Enabled = _SelectedProgram != AvailablePrograms.None;

            if (voltage > _highestBatteryvoltage) _highestBatteryvoltage = voltage;

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

        private async Task<string> SendQueryAsync(string query)
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                //MessageBox.Show("TCP connection is not open.");
                return null;
            }

            try
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(query);
                await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length);
                await _networkStream.FlushAsync();
                return await ReceiveMessageAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending query: " + ex.Message);
                return null;
            }
        }

        private async Task<string> ReceiveMessageAsync()
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                MessageBox.Show("Network stream is not available.");
                return null;
            }

            try
            {
                var buffer = new byte[1024];
                var stringBuilder = new StringBuilder();
                int bytesRead;
                do
                {
                    bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length);
                    stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                } while (_networkStream.DataAvailable);

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving message: " + ex.Message);
                return null;
            }
        }

        #endregion

        #region Query Methods


        public async Task<double> maxOutputVoltage()
        {
            string response = await SendQueryAsync("SOURce:VOLtage:MAXimum? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> maxOutputCurrent()
        {
            string response = await SendQueryAsync("SOURce:CURrent:MAXimum? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> maxOutputCurrentNegative()
        {
            string response = await SendQueryAsync("SOURce:CURrent:NEGative:MAXimum? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> maxOutputPower()
        {
            string response = await SendQueryAsync("SOURce:POWer:MAXimum? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> maxNegativeOutputPower()
        {
            string response = await SendQueryAsync("SOURce:POWer:NEGative:MAXimum? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> OutputVoltage()
        {
            string response = await SendQueryAsync("SOURce:VOLtage? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> OutputCurrent()
        {
            string response = await SendQueryAsync("SOURce:CURrent? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> OutputCurrentNegative()
        {
            string response = await SendQueryAsync("SOURce:CURrent:NEGative? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> OutputPower()
        {
            string response = await SendQueryAsync("SOURce:POWer? \n");
            return ParseResponseToDouble(response);
        }
        public async Task<double> OutputPowerNegative()
        {
            string response = await SendQueryAsync("SOURce:POWer:NEGative? \n");
            return ParseResponseToDouble(response);
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

        public async Task<double> Output()
        {
            string response = await SendQueryAsync("OUTPut? \n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> PowerSinkOutput()
        {
            string response = await SendQueryAsync("SYSTem:POWersink output? \n");
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

        //public async Task<string> ReadErrorLog()
        //{
        //    string response = Consolelog + await SendQueryAsync("SYSTem:Error?\n");
        //    return response;
        //}





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

        public async Task<double> SetOutput(bool state)
        {
            string response = await SendQueryAsync($"OUTPut {state}\n");
            return ParseResponseToDouble(response);
        }

        public async Task<double> SetPowersinkOutput(bool state)
        {
            string response = await SendQueryAsync($"SYSTem:POWersink {state}\n");
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
            AppliedVolts_UI.ReadOnly = !_EditingValues;
            AppliedChargeAmps_UI.ReadOnly = !_EditingValues;
            AppliedChargeWatts_UI.ReadOnly = !_EditingValues;
            AppliedDischargeAmps_UI.ReadOnly = !_EditingValues;
            AppliedDischargeWatts_UI.ReadOnly = !_EditingValues;

            if (_EditingValues == true)
            {
                EditValueButton.Text = "Save And Update Values";
                UpdateFromManualOveride();
            }
            else
            {
                EditValueButton.Text = "Edit Values";
                UpdateFromManualOveride();
            }
        }
        private void UpdateFromManualOveride()
        {
            _appliedVoltage = ParseInput(AppliedVolts_UI.Text);
            _appliedCurrent = ParseInput(AppliedChargeAmps_UI.Text);
            _appliedPower = ParseInput(AppliedChargeWatts_UI.Text);

            _negativeAppliedCurrent = ParseInput(AppliedDischargeAmps_UI.Text);
            _negativeAppliedPower = ParseInput(AppliedDischargeWatts_UI.Text);

            SaveSettings(_appliedVoltage, _appliedCurrent, _appliedPower, _negativeAppliedCurrent, _negativeAppliedPower);
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
            _appliedVoltage = V;
            _appliedCurrent = A;
            _appliedPower = W;
            _negativeAppliedCurrent = N_A;
            _negativeAppliedPower = N_W;

            AppliedVolts_UI.Text = _appliedVoltage.ToString() + " V";
            AppliedChargeAmps_UI.Text = _appliedCurrent.ToString() + " A";
            AppliedChargeWatts_UI.Text = _appliedPower.ToString() + " W";

            AppliedDischargeAmps_UI.Text = "-" + Math.Abs(_negativeAppliedCurrent).ToString() + " A";
            AppliedDischargeWatts_UI.Text = "-" + Math.Abs(_negativeAppliedPower).ToString() + " W";
            SetSettings();
        }
        private async void SetSettings()
        {
            await SetOutputVoltage(_appliedVoltage);
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

                        await SetOutputVoltage(_appliedVoltage);
                        await SetOutputCurrent(.5);
                        break;
                    case AvailablePrograms.Charging:
                        await SetOutputCurrent(_appliedCurrent);
                        await SetOutputPower(_appliedPower);
                        break;
                    case AvailablePrograms.Discharging:
                        await SetOutputCurrentNegative(_negativeAppliedCurrent);
                        await SetOutputPowerNegative(_negativeAppliedPower);
                        break;
                    case AvailablePrograms.DischargeTo30Procent:
                        if (!_discharged)
                        {
                            await SetOutputCurrentNegative(_negativeAppliedCurrent);
                            await SetOutputPowerNegative(_negativeAppliedPower);
                        }
                        else if (_discharged)
                        {
                            await SetOutputCurrent(_appliedCurrent);
                            await SetOutputPower(_appliedPower);
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
