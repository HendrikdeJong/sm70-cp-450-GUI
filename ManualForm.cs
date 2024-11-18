using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sm70_cp_450_GUI
{
    public partial class ManualForm : Form
    {

        private LogManager? logManager;
        private TcpConnectionHandler? _tcpHandler;
        private CommandManager? _commandManager;
        public Dictionary<string, Action<string>> _commandToUIActions;

        public ManualForm()
        {
            InitializeComponent();
             _commandToUIActions = new Dictionary<string, Action<string>>();
            _commandManager = CommandManager.Instance;
            logManager = LogManager.Instance;
            _tcpHandler = TcpConnectionHandler.Instance;
            TcpConnectionHandler.Instance.OnConnectionEstablished += InitializeUIActions;
            TcpConnectionHandler.Instance.OnConnectionLost += HandleConnectionLost;
        }

        private void InitializeUIActions()
        {
            // UI actions associated with commands
            _commandToUIActions = new Dictionary<string, Action<string>>
            {
                { "MEASure:VOLtage?", (response) => {VoltageDisplay.Text = response + " V"; }},
                { "MEASure:CURrent?", (response) => {AmperageDisplay.Text = response + " A";}},
                { "MEASure:POWer?", (response) => {WattageDisplay.Text = response + " W";}},
                { "SOURce:VOLtage?", (response) => Label_MachineAppliedVoltage_UI.Text = response + " V" },
                { "SOURce:CURrent?", (response) => Label_MachineAppliedCurrentPlus_UI.Text = response + " A" },
                { "SOURce:POWer?", (response) => Label_MachineAppliedPowerPlus_UI.Text = response + " W" },
                { "SOURce:CURrent:NEGative?", (response) => Label_MachineAppliedCurrentMin_UI.Text = response + " A" },
                { "SOURce:POWer:NEGative?", (response) => Label_MachineAppliedPowerMin_UI.Text = response + " W" },
                { "SYSTem:REMote:CV?", (response) => Label_Remote_CV_UI.Text = response},
                { "SYSTem:REMote:CC?", (response) => Label_Remote_CC_UI.Text = response},
                { "SYSTem:REMote:CP?", (response) => Label_Remote_CP_UI.Text = response}
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
            _commandToUIActions.Clear();
        }

        private void SetValuesToMachine()
        {
            MessageBox.Show(
                $"trying to set Settings to: " +
                $"Voltage: {InputField_StoredValueVoltage.Text} V, " +
                $"Current: {InputField_StoredValueCurrentPlus.Text} A, -{InputField_StoredValueCurrentMin.Text}A, " +
                $"Power: {InputField_StoredValuePowerPlus.Text} W, -{InputField_StoredValuePowerMin.Text}W,"
            );

            _commandManager?.SetOutputVoltage(UtilityBase.ParseInput(InputField_StoredValueVoltage.Text));
            _commandManager?.SetOutputCurrent(UtilityBase.ParseInput(InputField_StoredValueCurrentPlus.Text));
            _commandManager?.SetOutputCurrentNegative(UtilityBase.ParseInput(InputField_StoredValueCurrentMin.Text));
            _commandManager?.SetOutputPower(UtilityBase.ParseInput(InputField_StoredValuePowerPlus.Text));
            _commandManager?.SetOutputPowerNegative(UtilityBase.ParseInput(InputField_StoredValuePowerMin.Text));
        }

        private void ComboBoxHandler(object sender, EventArgs e)
        {
            string CV = Label_Remote_CV_UI.Text;
            string CC = Label_Remote_CC_UI.Text;
            string CP = Label_Remote_CP_UI.Text;

            if (sender is System.Windows.Forms.ComboBox comboBox)
            {
                if (comboBox.Text != "Front" && comboBox.Text != "Web" && comboBox.Text != "Sequencer" && comboBox.Text != "Ethernet") return;
                switch (comboBox.Name)
                {
                    case "CV_ComboBox":
                        if(comboBox.Text != CV) _commandManager?.
                                (comboBox.Text); MessageBox.Show($"{comboBox.Name}: set to {comboBox.Text}");
                        break;
                    case "CC_ComboBox":
                        if (comboBox.Text != CC) _commandManager?.SetSystemRemoteSetting_CC(comboBox.Text); MessageBox.Show($"{comboBox.Name}: set to {comboBox.Text}");
                        break;
                    case "CP_ComboBox":
                        if (comboBox.Text != CP) _commandManager?.SetSystemRemoteSetting_CP(comboBox.Text); MessageBox.Show($"{comboBox.Name}: set to {comboBox.Text}");
                        break;
                    default:
                        MessageBox.Show($"ComboBox: {comboBox.Name},  not recognized");
                        break;
                }
            }
            //Front
            //Web
            //Sequencer
            //Ethernet
        }

        private void ButtonHandler(object sender, EventArgs e)
        {
            string? tag = null;
            string? name = null;

            if (sender is Control control)
            {
                tag = control.Tag as string;
                name = control.Name;
            }


            if (tag != null)
            {
                switch (tag)
                {   
                    case "SetValues_btn":
                        SetValuesToMachine();
                        break;
                    case "Output ON":
                        _commandManager?.SetOutputState(true);
                        break;
                    case "Output OFF":
                        _commandManager?.SetOutputState(false);
                        break;
                    default:
                        MessageBox.Show($"Tag: {tag},  not recognized");
                        break;
                }
            }
        }
    }
}
