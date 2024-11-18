using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private double BulkVoltage = 0;
        private double MinimumVoltage = 0;
        private double maxCurrent = 0;
        private double cRating = 0;
        private double wantedBatteryPercentage = 0;

        public double ReadVoltage = 0;
        public double ReadCurrent = 0;

        private double accumulatedCharge = 0;

        private DateTime? chargeStartTime; 
        private DateTime? thresholdStartTime = null;
        private TimeSpan totalChargeTime;
        private double thresholdPercentage = 0; 
        private double thresholdTime = 0;

        public double CapacityPercent = 0;
        public float timer = 0;

        public UpdatedForm()
        {
            InitializeComponent();
            _commandManager = CommandManager.Instance;
            _logManager = LogManager.Instance;
            _mainForm = MainForm.Instance;

            _commandToUIActions = new Dictionary<string, Action<string>>();
        }

        private void ReadValues()
        {
            if (_mainForm == null) return;
            ReadVoltage = _mainForm.currentVoltage;
            ReadCurrent = _mainForm.currentCurrent;
            Label_LiveVoltage.Text = "Voltage: " + ReadVoltage.ToString();
            Label_LiveCurrent.Text = "Current: " + ReadCurrent.ToString();
        }


        private void SaveValues()
        {
            thresholdPercentage = UtilityBase.ParseInput(Input_ThresholdPercentage.Text);
            thresholdTime = UtilityBase.ParseInput(Input_ThresholdTime.Text);

            Capacity = UtilityBase.ParseInput(Input_Capacity.Text);
            BulkVoltage = UtilityBase.ParseInput(Input_BulkVoltage.Text);
            MinimumVoltage = UtilityBase.ParseInput(Input_CutoffVoltage.Text);
            maxCurrent = UtilityBase.ParseInput(Input_MaxAmps.Text);
            cRating = UtilityBase.ParseInput(Input_CRating.Text);
            wantedBatteryPercentage = UtilityBase.ParseInput(Input_Procent.Text);

            inputsFilledIn = Capacity != 0 && BulkVoltage != 0 && MinimumVoltage != 0 && maxCurrent != 0 && wantedBatteryPercentage != 0;
            if (inputsFilledIn)
            {
                CapacityPercent = Capacity * wantedBatteryPercentage;

                Label_Capacity.Text = "Capacity: " + Capacity.ToString();
                Label_BulkVolt.Text = "Bulk voltage: " + BulkVoltage.ToString();
                Label_MinVolt.Text = "Minimum voltage: " + MinimumVoltage.ToString();
                Label_MaxCurr.Text = "Max current: " + maxCurrent.ToString();
                Label_Procent.Text = "Percent to achieve: " + wantedBatteryPercentage.ToString();
                Label_ThresholdPercentage.Text = "Threshold Percentage: " + thresholdPercentage.ToString();
                Label_ThresholdTime.Text = "Threshold Time: " + thresholdTime.ToString() + "s";
            }
        }

        private void TimedFunction(object sender, EventArgs e)
        {
            ReadValues();
            ProcessSequenceStep();
        }


        private void ProcessSequenceStep()
        {
            if (!inputsFilledIn || !OutputActive) return;

            if (Rad_Btn_Discharge.Checked)
            {
                chargeStartTime = null;

                // Discharge logic
                if (ReadVoltage <= MinimumVoltage && OutputActive)
                {
                    _logManager?.AddDebugLogMessage("Transition to Charge: Minimum voltage reached.");
                    Rad_Btn_Discharge.Checked = false;
                    Rad_Btn_Charge.Checked = true;
                }
                else
                {
                    _commandManager?.SetOutputVoltage(MinimumVoltage);
                    _commandManager?.SetOutputCurrent(0);
                    _commandManager?.SetOutputCurrentNegative(maxCurrent);

                    if (ReadCurrent <= thresholdPercentage / 100 * maxCurrent)
                    {
                        if (thresholdStartTime == null)
                        {
                            thresholdStartTime = DateTime.Now;
                            _logManager?.AddDebugLogMessage($"Threshold timer started. Current: {ReadCurrent}, Threshold: {thresholdPercentage / 100 * maxCurrent}");
                        }

                        TimeSpan thresholdElapsed = DateTime.Now - thresholdStartTime.Value;

                        if (thresholdElapsed.TotalSeconds >= thresholdTime)
                        {
                            _logManager?.AddDebugLogMessage($"Battery empty condition met. Switching to charge mode. Threshold duration: {thresholdElapsed.TotalSeconds} seconds.");
                            Rad_Btn_Discharge.Checked = false;
                            Rad_Btn_Charge.Checked = true;

                            thresholdStartTime = null;
                        }
                    }
                    else
                    {
                        if (thresholdStartTime != null)
                        {
                            _logManager?.AddDebugLogMessage($"Threshold timer reset. Current: {ReadCurrent}, Threshold: {thresholdPercentage / 100 * maxCurrent}");
                        }
                        thresholdStartTime = null;
                    }
                }
            }

            if (Rad_Btn_Charge.Checked)
            {
                if (chargeStartTime == null)
                {
                    chargeStartTime = DateTime.Now;
                }

                TimeSpan elapsed = DateTime.Now - chargeStartTime.Value;

                totalChargeTime += elapsed;

                chargeStartTime = DateTime.Now;

                accumulatedCharge += (ReadCurrent * elapsed.TotalHours);

                double currentSOC = accumulatedCharge / Capacity * 100;

                if (currentSOC >= wantedBatteryPercentage)
                {
                    HandleCommand("Stop");
                }
                else
                {
                    _commandManager?.SetOutputVoltage(BulkVoltage);
                    _commandManager?.SetOutputCurrent(maxCurrent);
                    _commandManager?.SetOutputCurrentNegative(0);
                }
            }
        }



        private void HandleCommand(string command)
        {
            switch (command.ToLower())
            {
                case "stop":
                    OutputActive = false;
                    _commandManager?.SetOutputState(false);

                    // Reset charge timing fields
                    chargeStartTime = null;
                    MessageBox.Show($"Charging stopped. Total charge time: {totalChargeTime.TotalMinutes} minutes.");
                    break;

                case "start":
                    OutputActive = true;
                    _commandManager?.SetOutputState(true);
                    MessageBox.Show($"Charging started.");
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
                case "Button_Pause":
                    HandleCommand("Pause");
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
