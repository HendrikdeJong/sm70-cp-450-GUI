using System.Diagnostics;

namespace sm70_cp_450_GUI
{
    public partial class UpdatedForm : Form
    {
        private readonly LogManager? _logManager;
        private readonly CommandManager? _commandManager;
        private readonly MainForm? _mainForm;
        public Dictionary<string, Action<string>> _commandToUIActions;

        private bool inputsFilledIn;
        private bool OutputActive;

        private double Capacity = 0;
        private double MaxWatt = 0;
        private double BulkVoltage = 0;
        private double MinimumVoltage = 0;
        private double maxCurrent = 0;
        private double cRating = 0;
        private double wantedBatteryPercentage = 0;

        private double TriggerOffsetCurrent = 0;

        public double ReadVoltage = 0;
        public double ReadCurrent = 0;


        private double accumulatedCharge = 0;


        private Stopwatch triggerStopwatch;
        private Stopwatch coulombCountStopwatch;
        private TimeSpan totalDischargeTime = TimeSpan.Zero;
        private double dischargeSOC = 0;

        private double TriggerThresholdPercent = 0; 
        private TimeSpan TriggerThresholdTime = TimeSpan.Zero;

        public double CapacityPercent = 0;
        public float timer = 0;

        public UpdatedForm()
        {
            InitializeComponent();
            _commandManager = CommandManager.Instance;
            _logManager = LogManager.Instance;
            _mainForm = MainForm.Instance;
        }

        private void ReadValues()
        {
            if (_mainForm == null) return;
            ReadVoltage = _mainForm.currentVoltage;
            ReadCurrent = _mainForm.currentCurrent;
            Label_LiveVoltage.Text = "Voltage: " + ReadVoltage.ToString();
            Label_LiveCurrent.Text = "Current: " + ReadCurrent.ToString();
            Label_Status.Text = "Status: " + CurrentStep;

            label1.Text = "TriggerOffsetCurrent: " + TriggerOffsetCurrent.ToString() + "A";
            label2.Text = "accumulatedCharge: " + accumulatedCharge.ToString();
            label3.Text = "totalDischargeTime:" + totalDischargeTime.ToString() + "s";
            label4.Text = "triggerTime: " + triggerStopwatch?.Elapsed.Seconds.ToString() + "Sec";
        }


        private void SaveValues()
        {
            TriggerThresholdPercent = UtilityBase.ParseInput(Input_TriggerThreshold.Text);
            TriggerThresholdTime = TimeSpan.FromSeconds(UtilityBase.ParseInput(Input_TriggerTime.Text));

            Capacity = UtilityBase.ParseInput(Input_Capacity.Text);
            MaxWatt = UtilityBase.ParseInput(Input_Watt.Text);
            BulkVoltage = UtilityBase.ParseInput(Input_BulkVoltage.Text);
            MinimumVoltage = UtilityBase.ParseInput(Input_CutoffVoltage.Text);
            maxCurrent = UtilityBase.ParseInput(Input_MaxAmps.Text);
            cRating = UtilityBase.ParseInput(Input_CRating.Text);
            wantedBatteryPercentage = UtilityBase.ParseInput(Input_Procent.Text);

            inputsFilledIn = Capacity != 0 && BulkVoltage != 0 && MinimumVoltage != 0 && maxCurrent != 0 && wantedBatteryPercentage != 0;

            if (inputsFilledIn)
            {
                checkBox3.Checked = true;
                CapacityPercent = Capacity * wantedBatteryPercentage;
                TriggerOffsetCurrent = (TriggerThresholdPercent / 100 * maxCurrent);

                // Configure ProgressBar
                ProgressBar_Trigger.Minimum = 0; // Min value is 0 seconds
                ProgressBar_Trigger.Maximum = (int)TriggerThresholdTime.TotalSeconds; // Max value is threshold time in seconds
                ProgressBar_Trigger.Value = 0; // Start at 0

                Input_Capacity.Text = Capacity.ToString();
                Input_Watt.Text = MaxWatt.ToString();
                Input_BulkVoltage.Text = BulkVoltage.ToString();
                Input_CutoffVoltage.Text = MinimumVoltage.ToString();
                Input_MaxAmps.Text = maxCurrent.ToString();
                Input_Procent.Text = wantedBatteryPercentage.ToString();
                Input_TriggerThreshold.Text = TriggerThresholdPercent.ToString();
                Input_TriggerTime.Text = TriggerThresholdTime.ToString() + "s";

                _commandManager?.SetOutputCurrent(maxCurrent);
                _commandManager?.SetOutputCurrentNegative(-maxCurrent);
                _commandManager?.SetOutputPower(MaxWatt);
                _commandManager?.SetOutputPowerNegative(-MaxWatt);
            }
        }


        private void TimedFunction(object sender, EventArgs e)
        {
            ReadValues();
            TriggerManager();
        }
        private enum SequenceSteps
        {
            Charging,
            Discharging,
        }
        private SequenceSteps CurrentStep = SequenceSteps.Charging;

        private void TriggerManager()
        {
            if (!inputsFilledIn || !OutputActive) return;

            switch (CurrentStep)
            {
                case SequenceSteps.Charging:
                    HandleCharging();
                    break;

                case SequenceSteps.Discharging:
                    HandleDischarging();
                    break;

                default:
                    _logManager?.AddDebugLogMessage("Unknown sequence step.");
                    break;
            }
        }



        private void HandleCharging()
        {
            _commandManager?.SetOutputVoltage(BulkVoltage);

            if (ReadVoltage >= BulkVoltage) // Constant voltage phase
            {
                checkBox4.Checked = true; // Indicate voltage threshold met

                if (ReadCurrent <= TriggerOffsetCurrent) // Check if current is below threshold
                {
                    checkBox5.Checked = true; // Indicate current below threshold

                    if (triggerStopwatch == null)
                    {
                        triggerStopwatch = new Stopwatch();
                    }

                    if (!triggerStopwatch.IsRunning)
                    {
                        triggerStopwatch.Start();
                        _logManager?.AddDebugLogMessage($"Current below threshold. Timer started. Current: {ReadCurrent:F2} A, Threshold: {TriggerOffsetCurrent:F2} A.");
                    }

                    // Update ProgressBar
                    ProgressBar_Trigger.Value = Math.Min((int)triggerStopwatch.Elapsed.TotalSeconds, ProgressBar_Trigger.Maximum);

                    // If the current remains below the threshold for the specified duration
                    if (triggerStopwatch.Elapsed >= TriggerThresholdTime)
                    {
                        CurrentStep = SequenceSteps.Discharging; // Transition to Discharging
                        MessageBox.Show("Battery fully charged. Switching to discharge mode.");
                        _logManager?.AddDebugLogMessage($"Battery fully charged. Current: {ReadCurrent:F2} A, Timer: {triggerStopwatch.Elapsed.TotalSeconds:F2} seconds.");

                        // Initialize Coulomb counting
                        accumulatedCharge = Capacity; // Full SOC
                        dischargeSOC = 100;

                        // Reset ProgressBar and stopwatch
                        ProgressBar_Trigger.Value = 0;
                        triggerStopwatch.Reset();

                        // Start Coulomb counting timer
                        coulombCountStopwatch?.Reset();
                        coulombCountStopwatch = Stopwatch.StartNew();
                    }
                }
                else
                {
                    checkBox5.Checked = false;

                    // Reset ProgressBar and stopwatch if current rises above the threshold
                    if (triggerStopwatch != null && triggerStopwatch.IsRunning)
                    {
                        ProgressBar_Trigger.Value = 0;
                        triggerStopwatch.Reset();
                        _logManager?.AddDebugLogMessage($"Current above threshold. Timer reset. Current: {ReadCurrent:F2} A, Threshold: {TriggerOffsetCurrent:F2} A.");
                    }
                }
            }
            else
            {
                checkBox4.Checked = false; // Indicate voltage threshold not met
            }
        }




        private void HandleDischarging()
        {
            _commandManager?.SetOutputVoltage(MinimumVoltage);

            // Stop if target SOC is reached
            if (dischargeSOC <= wantedBatteryPercentage)
            {
                coulombCountStopwatch?.Stop();
                checkBox2.Checked = true;
                totalDischargeTime += coulombCountStopwatch?.Elapsed ?? TimeSpan.Zero; // Add remaining stopwatch time
                _logManager?.AddDebugLogMessage($"Target SOC {wantedBatteryPercentage}% reached. Total discharge time: {totalDischargeTime.TotalMinutes:F2} minutes.");
                _commandManager?.SetOutputCurrent(0);
                _commandManager?.SetOutputCurrentNegative(-0);
                _commandManager?.SetOutputPower(0);
                _commandManager?.SetOutputPowerNegative(-0);
                HandleCommand("Stop");
                return;
            }

            // Start stopwatch if not already running
            coulombCountStopwatch ??= Stopwatch.StartNew();

            // Calculate elapsed time for this interval in hours
            double elapsedHours = coulombCountStopwatch.Elapsed.TotalHours;

            // Update accumulated charge and SOC
            accumulatedCharge = Math.Max(0, accumulatedCharge - (Math.Abs(ReadCurrent) * elapsedHours));
            dischargeSOC = (accumulatedCharge / Capacity) * 100;

            // Log SOC and progress
            label5.Text = $"SOC: {dischargeSOC:F2}%";
            _logManager?.AddDebugLogMessage($"Discharging: Voltage={ReadVoltage:F2}, Current={ReadCurrent:F2}, SOC={dischargeSOC:F2}%, Elapsed Time: {totalDischargeTime.TotalMinutes:F2} minutes.");

            // Update total discharge time
            totalDischargeTime += coulombCountStopwatch.Elapsed;

            // Restart stopwatch for next interval
            coulombCountStopwatch.Restart();
        }




        private void HandleCommand(string command)
        {
            switch (command.ToLower())
            {
                case "stop":
                    OutputActive = false;
                    _commandManager?.SetOutputState(false);
                    ProgressBar_Trigger.Value = 0; // Reset ProgressBar
                    MessageBox.Show($"Charging stopped. Total charge time: {totalDischargeTime.TotalMinutes} minutes.");
                    break;

                case "start":
                    OutputActive = true;
                    _commandManager?.SetOutputState(true);
                    break;

                case "reset":
                    CurrentStep = SequenceSteps.Charging;
                    break;

                default:
                    _logManager?.AddDebugLogMessage($"Command '{command}' not recognized.");
                    break;
            }
        }


        private void ButtonHandler(object sender, EventArgs e)
        {

            string? name = null;

            if (sender is Control control)
            {
                name = control.Name;
            }
            switch (name)
            {
                case "Button_Save":
                    SaveValues();
                    break;
                case "Button_Stop":
                    HandleCommand("Stop");
                    break;
                case "Button_Reset":
                    HandleCommand("Reset");
                    break;
                case "Button_Start":
                    HandleCommand("Start");

                    break;

                default:
                    MessageBox.Show($"name: {name},  not recognized");
                    break;
            }
        }
    }
}
