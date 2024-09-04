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
        private int _chargeState = 0;

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
        private double _batteryvoltage = 0;
        private double _batteryAmps = 0;


        public Form1()
        {
            InitializeComponent();
            InitializeTcpClient();
            InitializeUpdateTimer();
        }

        private void InitializeUpdateTimer()
        {
            var updateTimer = new Timer
            {
                Interval = 500 // 500 milliseconds = 0.5 seconds
            };
            updateTimer.Tick += async (sender, e) => await UpdateLoop();
            updateTimer.Start();
        }

        private async Task UpdateLoop()
        {
            double voltage = await MeasureOutputVoltage();
            double current = await MeasureOutputCurrent();
            double power = await MeasureOutputPower();

            VoltageDisplay.Text = voltage.ToString();
            AmperageDisplay.Text = current.ToString();
            WattageDisplay.Text = power.ToString();
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

        #region Getinfo

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
        #endregion
        #region SetInfo

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

        #endregion

        private double ParseResponseToDouble(string response)
        {
            return double.TryParse(response, out double result) ? result : double.NaN;
        }

        #endregion



        #region Functions

        private static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-').ToArray());
        }

        private void CalculateWith_cRating()
        {
            double amps = _ratedCapacity * _cRating;
            double watts = amps * _ratedVoltage;
            _ratedPower = watts;
            SaveSettings(_ratedVoltage, amps, watts, -amps, -watts);
            //MessageBox.Show("applied data" + _ratedVoltage + "V " + amps + "A " + watts + "W");
        }




        private void UpdateFromBatteryLabelData(object sender, EventArgs e)
        {
            _ratedVoltage = ParseInput(RatedBatteryVoltageUI.Text);
            _ratedCapacity = ParseInput(RatedBatteryVoltageUI.Text);
            _cRating = ParseInput(RatedBatteryVoltageUI.Text);
            CalculateWith_cRating();
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

        private double ParseInput(string input)
        {
            if (double.TryParse(RemoveNonNumeric(input), out double result))
            {
                return result;
            }
            else
            {
                MessageBox.Show($"Invalid input: {input}");
                return 0;  // or handle appropriately
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


        private void SaveSettings(Double V, double A, Double W, Double N_A, Double N_W)
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
            await SetOutputCurrent(_appliedCurrent);
            await SetOutputCurrent(_negativeAppliedCurrent);
            await SetOutputPower(_appliedPower);
            await SetOutputPower(_negativeAppliedPower);
        }
        private async void SetPositiveValues()
        {
            await SetOutputCurrent(_appliedCurrent);
            await SetOutputPower(_appliedPower);
            MessageBox.Show("Set positive values");
        }

        private async void SetNegagtiveValues()
        {
            await SetOutputCurrent(_negativeAppliedCurrent);
            await SetOutputPower(_negativeAppliedPower);
            MessageBox.Show("Set negative values");
        }

        //private void ToggleOutputState(object sender, EventArgs e)
        //{
        //    if (_started == true)
        //    {
        //        _started = false;
        //        ChargeButton.Enabled = true;
        //        Charge30Button.Enabled = true;
        //        DischargeButton.Enabled = true;
        //        EditValueButton.Enabled = false;
        //        ApplyBatteryDataButton.Enabled = false;

        //        StartStopButton.Text = "Stop";
        //        StartStopButton.BackColor = Color.Red;
        //        ToggleOutputValues();
        //    }
        //    else if (_started == false)
        //    {
        //        _started = true;
        //        ChargeButton.Enabled = false;
        //        Charge30Button.Enabled = false;
        //        DischargeButton.Enabled = false;
        //        EditValueButton.Enabled = true;
        //        ApplyBatteryDataButton.Enabled = true;

        //        StartStopButton.Text = "Start";
        //        StartStopButton.BackColor = Color.Green;
        //        ToggleOutputValues();
        //    }
        //}

        //private async void ToggleOutputValues()
        //{
        //    if (!_started)
        //    {
        //        await SetOutputCurrent(0);
        //        await SetOutputCurrentNegative(0);
        //        await SetOutputPower(0);
        //        await SetOutputPowerNegative(0);
        //    }
        //    else
        //    {
        //        switch (_chargeState)
        //        {
        //            case 1:
        //                await SetOutputCurrent(_appliedAmps);
        //                await SetOutputPower(_appliedAmps);
        //                break;
        //            case 2:
        //                await SetOutputCurrentNegative(_appliedAmps);
        //                await SetOutputPowerNegative(_appliedAmps);
        //                break;
        //            case 3:

        //                break;
        //        }
        //    }
        //}


        #endregion

        #region Buttons

        private void ChargeButton_Click(object sender, EventArgs e)
        {
            //_chargeState = 1;
            //ChargeButton.BackColor = Color.Yellow;
            //DischargeButton.BackColor = Color.White;
            //Charge30Button.BackColor = Color.White;

        }

        private void DischargeButton_Click(object sender, EventArgs e)
        {
            //_chargeState = 2;
            //DischargeButton.BackColor = Color.Yellow;
            //Charge30Button.BackColor = Color.White;
            //ChargeButton.BackColor = Color.White;
        }

        private void Charge30Button_Click(object sender, EventArgs e)
        {
            //_chargeState = 3;
            //Charge30Button.BackColor = Color.Yellow;
            //DischargeButton.BackColor = Color.White;
            //ChargeButton.BackColor = Color.White;
        }

        #endregion
    }
}
