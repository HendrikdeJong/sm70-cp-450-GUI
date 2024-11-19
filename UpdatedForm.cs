using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                CapacityPercent = Capacity * wantedBatteryPercentage;
                TriggerOffsetCurrent = (TriggerThresholdPercent / 100 * maxCurrent);

                Input_Capacity.Text = Capacity.ToString();
                Input_Watt.Text = MaxWatt.ToString();
                Input_BulkVoltage.Text = BulkVoltage.ToString();
                Input_CutoffVoltage.Text = MinimumVoltage.ToString();
                Input_MaxAmps.Text = maxCurrent.ToString();
                Input_Procent.Text = wantedBatteryPercentage.ToString();
                Input_TriggerThreshold.Text = TriggerThresholdPercent.ToString();
                Input_TriggerTime.Text = TriggerThresholdTime.ToString() + "s";

                label1.Text = "TriggerOffsetCurr: " + TriggerOffsetCurrent.ToString() + "A";
                label2.Text = "accumulatedCharge: " + accumulatedCharge.ToString();
                label3.Text = "totalDischargeTime:" + totalDischargeTime.ToString() + "s";




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
            Charging_CC,
            Charging_CV,
            Discharging,
        }
        private SequenceSteps CurrentStep = SequenceSteps.Charging_CC;

        private void TriggerManager()
        {
            if (!inputsFilledIn || !OutputActive) return;

            switch (CurrentStep)
            {
                case SequenceSteps.Charging_CC:
                    HandleCharging_CC();
                    break;

                case SequenceSteps.Charging_CV:
                    HandleCharging_CV();
                    break;

                case SequenceSteps.Discharging:
                    HandleDischarging();
                    break;

                default:
                    _logManager?.AddDebugLogMessage("Unknown sequence step.");
                    break;
            }
        }

        private void HandleCharging_CV()
        {
            _commandManager?.SetOutputVoltage(BulkVoltage);
           
        }

        private void HandleCharging_CC()
        {
            _commandManager?.SetOutputVoltage(BulkVoltage);
            if (ReadCurrent >= maxCurrent - TriggerOffsetCurrent)
            {
                if (triggerStopwatch == null)
                {
                    triggerStopwatch = Stopwatch.StartNew();
                }

                if (triggerStopwatch.Elapsed >= TriggerThresholdTime)
                {
                    CurrentStep = SequenceSteps.Discharging;
                    _logManager?.AddDebugLogMessage("Battery fully charged. Switching to discharge mode.");

                    // Initialize Coulomb counting
                    accumulatedCharge = Capacity; // Start from 100% SOC
                    dischargeSOC = 100;

                    coulombCountStopwatch?.Reset();
                    coulombCountStopwatch = Stopwatch.StartNew();
                }
            }
            else
            {
                triggerStopwatch?.Reset();
            }
        }


        private void HandleDischarging()
        {
            _commandManager?.SetOutputVoltage(MinimumVoltage);

            // Stop if target SOC is reached
            if (dischargeSOC <= wantedBatteryPercentage)
            {
                coulombCountStopwatch?.Stop();
                totalDischargeTime += coulombCountStopwatch?.Elapsed ?? TimeSpan.Zero; // Add remaining stopwatch time
                _logManager?.AddDebugLogMessage($"Target SOC {wantedBatteryPercentage}% reached. Total discharge time: {totalDischargeTime.TotalMinutes:F2} minutes.");
                HandleCommand("Stop");
                return;
            }

            // Start stopwatch if not already running
            if (coulombCountStopwatch == null)
            {
                coulombCountStopwatch = Stopwatch.StartNew();
            }

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
                    MessageBox.Show($"Charging stopped. Total charge time: {totalDischargeTime.TotalMinutes} minutes.");
                    break;

                case "start":
                    OutputActive = true;
                    _commandManager?.SetOutputState(true);
                    break;

                case "reset":
                    CurrentStep = SequenceSteps.Charging_CC;
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
