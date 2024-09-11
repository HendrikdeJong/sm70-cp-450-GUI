namespace sm70_cp_450_GUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            LiveInfoData = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            Label_MachineAppliedVoltage_UI = new Label();
            Label_Remote_CV_UI = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            InputField_StoredValueVoltage = new TextBox();
            Button_Toggle_ValueEditor = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            InputField_StoredValuePowerMin = new TextBox();
            InputField_StoredValuePowerPlus = new TextBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            Label_MachineAppliedPowerPlus_UI = new Label();
            Label_Remote_CP_UI = new Label();
            Label_MachineAppliedPowerMin_UI = new Label();
            WattageDisplay = new Label();
            VoltageDisplay = new Label();
            AmperageDisplay = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            Label_MachineAppliedCurrentPlus_UI = new Label();
            Label_Remote_CC_UI = new Label();
            Label_MachineAppliedCurrentMin_UI = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            InputField_StoredValueCurrentMin = new TextBox();
            InputField_StoredValueCurrentPlus = new TextBox();
            OperationsBox_UI = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            BatteryConnectButton = new Button();
            StartStopButton = new Button();
            Charge30Button = new Button();
            ChargeButton = new Button();
            DischargeButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox2 = new GroupBox();
            ApplyBatteryDataButton = new Button();
            C_Rating_UI = new TextBox();
            RatedBatteryVoltageUI = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            RatedBatteryAmperageUI = new TextBox();
            settingsBox_UI = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            Label_Elapsed_Time_UI = new TextBox();
            label4 = new Label();
            ConsoleBox = new GroupBox();
            tabControl1 = new TabControl();
            Simple = new TabPage();
            Console_Simple_Textbox_UI = new RichTextBox();
            Advanced = new TabPage();
            Console_Advanced_Textbox_UI = new RichTextBox();
            Label_Time_UI = new TextBox();
            label3 = new Label();
            Name1 = new Label();
            StatusCurrentOperation_UI = new TextBox();
            label7 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            OperationsBox_UI.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox2.SuspendLayout();
            settingsBox_UI.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ConsoleBox.SuspendLayout();
            tabControl1.SuspendLayout();
            Simple.SuspendLayout();
            Advanced.SuspendLayout();
            SuspendLayout();
            // 
            // LiveInfoData
            // 
            LiveInfoData.Controls.Add(tableLayoutPanel2);
            LiveInfoData.Dock = DockStyle.Top;
            LiveInfoData.Location = new Point(0, 0);
            LiveInfoData.Name = "LiveInfoData";
            LiveInfoData.Size = new Size(821, 211);
            LiveInfoData.TabIndex = 5;
            LiveInfoData.TabStop = false;
            LiveInfoData.Text = "Info";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel8, 0, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel7, 2, 2);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 2, 1);
            tableLayoutPanel2.Controls.Add(WattageDisplay, 2, 0);
            tableLayoutPanel2.Controls.Add(VoltageDisplay, 0, 0);
            tableLayoutPanel2.Controls.Add(AmperageDisplay, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 1, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new Size(815, 183);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.AutoSize = true;
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(Label_MachineAppliedVoltage_UI, 1, 0);
            tableLayoutPanel9.Controls.Add(Label_Remote_CV_UI, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 48);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(265, 58);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // Label_MachineAppliedVoltage_UI
            // 
            Label_MachineAppliedVoltage_UI.AutoSize = true;
            Label_MachineAppliedVoltage_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedVoltage_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedVoltage_UI.Location = new Point(135, 0);
            Label_MachineAppliedVoltage_UI.Name = "Label_MachineAppliedVoltage_UI";
            Label_MachineAppliedVoltage_UI.Size = new Size(127, 29);
            Label_MachineAppliedVoltage_UI.TabIndex = 13;
            Label_MachineAppliedVoltage_UI.Text = "0 V";
            Label_MachineAppliedVoltage_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Remote_CV_UI
            // 
            Label_Remote_CV_UI.AutoSize = true;
            Label_Remote_CV_UI.Dock = DockStyle.Fill;
            Label_Remote_CV_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Remote_CV_UI.Location = new Point(3, 0);
            Label_Remote_CV_UI.Name = "Label_Remote_CV_UI";
            Label_Remote_CV_UI.Size = new Size(126, 29);
            Label_Remote_CV_UI.TabIndex = 12;
            Label_Remote_CV_UI.Text = "Front";
            Label_Remote_CV_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(InputField_StoredValueVoltage, 0, 0);
            tableLayoutPanel8.Controls.Add(Button_Toggle_ValueEditor, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 112);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(265, 68);
            tableLayoutPanel8.TabIndex = 12;
            // 
            // InputField_StoredValueVoltage
            // 
            InputField_StoredValueVoltage.Dock = DockStyle.Fill;
            InputField_StoredValueVoltage.Location = new Point(3, 3);
            InputField_StoredValueVoltage.Name = "InputField_StoredValueVoltage";
            InputField_StoredValueVoltage.PlaceholderText = "0 A";
            InputField_StoredValueVoltage.ReadOnly = true;
            InputField_StoredValueVoltage.Size = new Size(259, 29);
            InputField_StoredValueVoltage.TabIndex = 0;
            InputField_StoredValueVoltage.Tag = "";
            InputField_StoredValueVoltage.TextAlign = HorizontalAlignment.Center;
            // 
            // Button_Toggle_ValueEditor
            // 
            Button_Toggle_ValueEditor.AutoSize = true;
            Button_Toggle_ValueEditor.Dock = DockStyle.Fill;
            Button_Toggle_ValueEditor.Location = new Point(3, 37);
            Button_Toggle_ValueEditor.Name = "Button_Toggle_ValueEditor";
            Button_Toggle_ValueEditor.Size = new Size(259, 28);
            Button_Toggle_ValueEditor.TabIndex = 1;
            Button_Toggle_ValueEditor.Text = "Edit values";
            Button_Toggle_ValueEditor.UseVisualStyleBackColor = true;
            Button_Toggle_ValueEditor.Click += ToggleManualEditing;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerMin, 0, 1);
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerPlus, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(545, 112);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(267, 68);
            tableLayoutPanel7.TabIndex = 11;
            // 
            // InputField_StoredValuePowerMin
            // 
            InputField_StoredValuePowerMin.Dock = DockStyle.Fill;
            InputField_StoredValuePowerMin.Location = new Point(3, 37);
            InputField_StoredValuePowerMin.Name = "InputField_StoredValuePowerMin";
            InputField_StoredValuePowerMin.PlaceholderText = "0 W";
            InputField_StoredValuePowerMin.ReadOnly = true;
            InputField_StoredValuePowerMin.Size = new Size(261, 29);
            InputField_StoredValuePowerMin.TabIndex = 2;
            InputField_StoredValuePowerMin.Tag = "";
            InputField_StoredValuePowerMin.TextAlign = HorizontalAlignment.Center;
            // 
            // InputField_StoredValuePowerPlus
            // 
            InputField_StoredValuePowerPlus.Dock = DockStyle.Fill;
            InputField_StoredValuePowerPlus.Location = new Point(3, 3);
            InputField_StoredValuePowerPlus.Name = "InputField_StoredValuePowerPlus";
            InputField_StoredValuePowerPlus.PlaceholderText = "0 W";
            InputField_StoredValuePowerPlus.ReadOnly = true;
            InputField_StoredValuePowerPlus.Size = new Size(261, 29);
            InputField_StoredValuePowerPlus.TabIndex = 1;
            InputField_StoredValuePowerPlus.Tag = "";
            InputField_StoredValuePowerPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(Label_MachineAppliedPowerPlus_UI, 1, 0);
            tableLayoutPanel5.Controls.Add(Label_Remote_CP_UI, 0, 0);
            tableLayoutPanel5.Controls.Add(Label_MachineAppliedPowerMin_UI, 1, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(545, 48);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(267, 58);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // Label_MachineAppliedPowerPlus_UI
            // 
            Label_MachineAppliedPowerPlus_UI.AutoSize = true;
            Label_MachineAppliedPowerPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerPlus_UI.Location = new Point(136, 0);
            Label_MachineAppliedPowerPlus_UI.Name = "Label_MachineAppliedPowerPlus_UI";
            Label_MachineAppliedPowerPlus_UI.Size = new Size(128, 29);
            Label_MachineAppliedPowerPlus_UI.TabIndex = 11;
            Label_MachineAppliedPowerPlus_UI.Text = "0 W";
            Label_MachineAppliedPowerPlus_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Remote_CP_UI
            // 
            Label_Remote_CP_UI.AutoSize = true;
            Label_Remote_CP_UI.Dock = DockStyle.Fill;
            Label_Remote_CP_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Remote_CP_UI.Location = new Point(3, 0);
            Label_Remote_CP_UI.Name = "Label_Remote_CP_UI";
            Label_Remote_CP_UI.Size = new Size(127, 29);
            Label_Remote_CP_UI.TabIndex = 10;
            Label_Remote_CP_UI.Text = "Front";
            Label_Remote_CP_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedPowerMin_UI
            // 
            Label_MachineAppliedPowerMin_UI.AutoSize = true;
            Label_MachineAppliedPowerMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerMin_UI.Location = new Point(136, 29);
            Label_MachineAppliedPowerMin_UI.Name = "Label_MachineAppliedPowerMin_UI";
            Label_MachineAppliedPowerMin_UI.Size = new Size(128, 29);
            Label_MachineAppliedPowerMin_UI.TabIndex = 9;
            Label_MachineAppliedPowerMin_UI.Text = "-0 W";
            Label_MachineAppliedPowerMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WattageDisplay
            // 
            WattageDisplay.AutoSize = true;
            WattageDisplay.Dock = DockStyle.Fill;
            WattageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            WattageDisplay.Location = new Point(546, 0);
            WattageDisplay.Margin = new Padding(4, 0, 4, 0);
            WattageDisplay.Name = "WattageDisplay";
            WattageDisplay.Size = new Size(265, 45);
            WattageDisplay.TabIndex = 2;
            WattageDisplay.Text = "0.0 W";
            WattageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VoltageDisplay
            // 
            VoltageDisplay.AutoSize = true;
            VoltageDisplay.Dock = DockStyle.Fill;
            VoltageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            VoltageDisplay.Location = new Point(4, 0);
            VoltageDisplay.Margin = new Padding(4, 0, 4, 0);
            VoltageDisplay.Name = "VoltageDisplay";
            VoltageDisplay.Size = new Size(263, 45);
            VoltageDisplay.TabIndex = 0;
            VoltageDisplay.Text = "0.0 V";
            VoltageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AmperageDisplay
            // 
            AmperageDisplay.AutoSize = true;
            AmperageDisplay.Dock = DockStyle.Fill;
            AmperageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            AmperageDisplay.Location = new Point(275, 0);
            AmperageDisplay.Margin = new Padding(4, 0, 4, 0);
            AmperageDisplay.Name = "AmperageDisplay";
            AmperageDisplay.Size = new Size(263, 45);
            AmperageDisplay.TabIndex = 1;
            AmperageDisplay.Text = "0.0 A";
            AmperageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(Label_MachineAppliedCurrentPlus_UI, 1, 0);
            tableLayoutPanel3.Controls.Add(Label_Remote_CC_UI, 0, 0);
            tableLayoutPanel3.Controls.Add(Label_MachineAppliedCurrentMin_UI, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(274, 48);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(265, 58);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // Label_MachineAppliedCurrentPlus_UI
            // 
            Label_MachineAppliedCurrentPlus_UI.AutoSize = true;
            Label_MachineAppliedCurrentPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentPlus_UI.Location = new Point(135, 0);
            Label_MachineAppliedCurrentPlus_UI.Name = "Label_MachineAppliedCurrentPlus_UI";
            Label_MachineAppliedCurrentPlus_UI.Size = new Size(127, 29);
            Label_MachineAppliedCurrentPlus_UI.TabIndex = 10;
            Label_MachineAppliedCurrentPlus_UI.Text = "0 A";
            Label_MachineAppliedCurrentPlus_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Remote_CC_UI
            // 
            Label_Remote_CC_UI.AutoSize = true;
            Label_Remote_CC_UI.Dock = DockStyle.Fill;
            Label_Remote_CC_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Remote_CC_UI.Location = new Point(3, 0);
            Label_Remote_CC_UI.Name = "Label_Remote_CC_UI";
            Label_Remote_CC_UI.Size = new Size(126, 29);
            Label_Remote_CC_UI.TabIndex = 9;
            Label_Remote_CC_UI.Text = "Front";
            Label_Remote_CC_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedCurrentMin_UI
            // 
            Label_MachineAppliedCurrentMin_UI.AutoSize = true;
            Label_MachineAppliedCurrentMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentMin_UI.Location = new Point(135, 29);
            Label_MachineAppliedCurrentMin_UI.Name = "Label_MachineAppliedCurrentMin_UI";
            Label_MachineAppliedCurrentMin_UI.Size = new Size(127, 29);
            Label_MachineAppliedCurrentMin_UI.TabIndex = 8;
            Label_MachineAppliedCurrentMin_UI.Text = "-0 A";
            Label_MachineAppliedCurrentMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.Controls.Add(InputField_StoredValueCurrentMin, 0, 1);
            tableLayoutPanel6.Controls.Add(InputField_StoredValueCurrentPlus, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(274, 112);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(265, 68);
            tableLayoutPanel6.TabIndex = 10;
            // 
            // InputField_StoredValueCurrentMin
            // 
            InputField_StoredValueCurrentMin.Dock = DockStyle.Fill;
            InputField_StoredValueCurrentMin.Location = new Point(3, 37);
            InputField_StoredValueCurrentMin.Name = "InputField_StoredValueCurrentMin";
            InputField_StoredValueCurrentMin.PlaceholderText = "0 A";
            InputField_StoredValueCurrentMin.ReadOnly = true;
            InputField_StoredValueCurrentMin.Size = new Size(259, 29);
            InputField_StoredValueCurrentMin.TabIndex = 1;
            InputField_StoredValueCurrentMin.Tag = "";
            InputField_StoredValueCurrentMin.TextAlign = HorizontalAlignment.Center;
            // 
            // InputField_StoredValueCurrentPlus
            // 
            InputField_StoredValueCurrentPlus.Dock = DockStyle.Fill;
            InputField_StoredValueCurrentPlus.Location = new Point(3, 3);
            InputField_StoredValueCurrentPlus.Name = "InputField_StoredValueCurrentPlus";
            InputField_StoredValueCurrentPlus.PlaceholderText = "0 A";
            InputField_StoredValueCurrentPlus.ReadOnly = true;
            InputField_StoredValueCurrentPlus.Size = new Size(259, 29);
            InputField_StoredValueCurrentPlus.TabIndex = 0;
            InputField_StoredValueCurrentPlus.Tag = "";
            InputField_StoredValueCurrentPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // OperationsBox_UI
            // 
            OperationsBox_UI.Controls.Add(tableLayoutPanel4);
            OperationsBox_UI.Location = new Point(3, 195);
            OperationsBox_UI.Name = "OperationsBox_UI";
            OperationsBox_UI.Size = new Size(492, 225);
            OperationsBox_UI.TabIndex = 8;
            OperationsBox_UI.TabStop = false;
            OperationsBox_UI.Text = "Operations";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.Controls.Add(BatteryConnectButton, 0, 1);
            tableLayoutPanel4.Controls.Add(StartStopButton, 2, 1);
            tableLayoutPanel4.Controls.Add(Charge30Button, 2, 0);
            tableLayoutPanel4.Controls.Add(ChargeButton, 0, 0);
            tableLayoutPanel4.Controls.Add(DischargeButton, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 25);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(486, 197);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // BatteryConnectButton
            // 
            BatteryConnectButton.BackColor = Color.White;
            BatteryConnectButton.Dock = DockStyle.Fill;
            BatteryConnectButton.Location = new Point(3, 101);
            BatteryConnectButton.Name = "BatteryConnectButton";
            BatteryConnectButton.Size = new Size(155, 93);
            BatteryConnectButton.TabIndex = 12;
            BatteryConnectButton.Text = "Connect Battery";
            BatteryConnectButton.UseVisualStyleBackColor = false;
            BatteryConnectButton.Click += BatteryConnectButton_Click;
            // 
            // StartStopButton
            // 
            StartStopButton.AutoSize = true;
            StartStopButton.BackColor = Color.Chartreuse;
            StartStopButton.Dock = DockStyle.Fill;
            StartStopButton.Location = new Point(326, 101);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(157, 93);
            StartStopButton.TabIndex = 11;
            StartStopButton.Text = "Start";
            StartStopButton.UseVisualStyleBackColor = false;
            StartStopButton.Click += ToggleStartStopButton;
            // 
            // Charge30Button
            // 
            Charge30Button.BackColor = Color.White;
            Charge30Button.Dock = DockStyle.Fill;
            Charge30Button.Enabled = false;
            Charge30Button.Location = new Point(326, 3);
            Charge30Button.Name = "Charge30Button";
            Charge30Button.Size = new Size(157, 92);
            Charge30Button.TabIndex = 2;
            Charge30Button.Text = "Discharge to 30%";
            Charge30Button.UseVisualStyleBackColor = false;
            Charge30Button.Click += Charge30Button_Click;
            // 
            // ChargeButton
            // 
            ChargeButton.BackColor = Color.White;
            ChargeButton.Dock = DockStyle.Fill;
            ChargeButton.Location = new Point(3, 3);
            ChargeButton.Name = "ChargeButton";
            ChargeButton.Size = new Size(155, 92);
            ChargeButton.TabIndex = 0;
            ChargeButton.Text = "Charge";
            ChargeButton.UseVisualStyleBackColor = false;
            ChargeButton.Click += ChargeButton_Click;
            // 
            // DischargeButton
            // 
            DischargeButton.BackColor = Color.White;
            DischargeButton.Dock = DockStyle.Fill;
            DischargeButton.Location = new Point(164, 3);
            DischargeButton.Name = "DischargeButton";
            DischargeButton.Size = new Size(156, 92);
            DischargeButton.TabIndex = 1;
            DischargeButton.Text = "Discharge";
            DischargeButton.UseVisualStyleBackColor = false;
            DischargeButton.Click += DischargeButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ApplyBatteryDataButton);
            groupBox2.Controls.Add(C_Rating_UI);
            groupBox2.Controls.Add(RatedBatteryVoltageUI);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(RatedBatteryAmperageUI);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(492, 186);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Factory Information";
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Location = new Point(16, 140);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(470, 36);
            ApplyBatteryDataButton.TabIndex = 11;
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            ApplyBatteryDataButton.Click += UpdateFromBatteryLabelData;
            // 
            // C_Rating_UI
            // 
            C_Rating_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            C_Rating_UI.Location = new Point(366, 105);
            C_Rating_UI.Name = "C_Rating_UI";
            C_Rating_UI.PlaceholderText = "C1";
            C_Rating_UI.Size = new Size(120, 29);
            C_Rating_UI.TabIndex = 10;
            // 
            // RatedBatteryVoltageUI
            // 
            RatedBatteryVoltageUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RatedBatteryVoltageUI.Location = new Point(366, 35);
            RatedBatteryVoltageUI.Name = "RatedBatteryVoltageUI";
            RatedBatteryVoltageUI.PlaceholderText = "Voltage";
            RatedBatteryVoltageUI.Size = new Size(120, 29);
            RatedBatteryVoltageUI.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 6;
            label1.Text = "Rated Voltage";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 102);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 9;
            label6.Text = "C Rating";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 8;
            label2.Text = "Rated capacity";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RatedBatteryAmperageUI
            // 
            RatedBatteryAmperageUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RatedBatteryAmperageUI.Location = new Point(366, 70);
            RatedBatteryAmperageUI.Name = "RatedBatteryAmperageUI";
            RatedBatteryAmperageUI.PlaceholderText = "Amps / Hour";
            RatedBatteryAmperageUI.Size = new Size(120, 29);
            RatedBatteryAmperageUI.TabIndex = 7;
            // 
            // settingsBox_UI
            // 
            settingsBox_UI.Controls.Add(flowLayoutPanel1);
            settingsBox_UI.Dock = DockStyle.Right;
            settingsBox_UI.Location = new Point(317, 211);
            settingsBox_UI.Name = "settingsBox_UI";
            settingsBox_UI.Size = new Size(504, 457);
            settingsBox_UI.TabIndex = 9;
            settingsBox_UI.TabStop = false;
            settingsBox_UI.Text = "Settings";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Controls.Add(OperationsBox_UI);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(498, 429);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Label_Elapsed_Time_UI);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(ConsoleBox);
            groupBox1.Controls.Add(Label_Time_UI);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Name1);
            groupBox1.Controls.Add(StatusCurrentOperation_UI);
            groupBox1.Controls.Add(label7);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 211);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(317, 457);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // Label_Elapsed_Time_UI
            // 
            Label_Elapsed_Time_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Elapsed_Time_UI.Location = new Point(172, 166);
            Label_Elapsed_Time_UI.Margin = new Padding(0);
            Label_Elapsed_Time_UI.Name = "Label_Elapsed_Time_UI";
            Label_Elapsed_Time_UI.ReadOnly = true;
            Label_Elapsed_Time_UI.Size = new Size(136, 36);
            Label_Elapsed_Time_UI.TabIndex = 24;
            Label_Elapsed_Time_UI.Text = "00:00:00";
            Label_Elapsed_Time_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Location = new Point(6, 166);
            label4.Name = "label4";
            label4.Size = new Size(151, 36);
            label4.TabIndex = 23;
            label4.Text = "Time Elapsed:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ConsoleBox
            // 
            ConsoleBox.Controls.Add(tabControl1);
            ConsoleBox.Dock = DockStyle.Bottom;
            ConsoleBox.Location = new Point(3, 245);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.Size = new Size(311, 209);
            ConsoleBox.TabIndex = 22;
            ConsoleBox.TabStop = false;
            ConsoleBox.Text = "Console";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Simple);
            tabControl1.Controls.Add(Advanced);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 25);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(305, 181);
            tabControl1.TabIndex = 0;
            // 
            // Simple
            // 
            Simple.Controls.Add(Console_Simple_Textbox_UI);
            Simple.Location = new Point(4, 30);
            Simple.Margin = new Padding(0);
            Simple.Name = "Simple";
            Simple.Size = new Size(297, 147);
            Simple.TabIndex = 0;
            Simple.Text = "Simple / only errors";
            Simple.UseVisualStyleBackColor = true;
            // 
            // Console_Simple_Textbox_UI
            // 
            Console_Simple_Textbox_UI.BackColor = SystemColors.ControlLight;
            Console_Simple_Textbox_UI.Dock = DockStyle.Fill;
            Console_Simple_Textbox_UI.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Console_Simple_Textbox_UI.ForeColor = SystemColors.ActiveCaptionText;
            Console_Simple_Textbox_UI.Location = new Point(0, 0);
            Console_Simple_Textbox_UI.Name = "Console_Simple_Textbox_UI";
            Console_Simple_Textbox_UI.ReadOnly = true;
            Console_Simple_Textbox_UI.ScrollBars = RichTextBoxScrollBars.Vertical;
            Console_Simple_Textbox_UI.Size = new Size(297, 147);
            Console_Simple_Textbox_UI.TabIndex = 4;
            Console_Simple_Textbox_UI.Text = "";
            // 
            // Advanced
            // 
            Advanced.Controls.Add(Console_Advanced_Textbox_UI);
            Advanced.Location = new Point(4, 24);
            Advanced.Margin = new Padding(0);
            Advanced.Name = "Advanced";
            Advanced.Size = new Size(297, 159);
            Advanced.TabIndex = 1;
            Advanced.Text = "Advanced / Debug";
            Advanced.UseVisualStyleBackColor = true;
            // 
            // Console_Advanced_Textbox_UI
            // 
            Console_Advanced_Textbox_UI.BackColor = SystemColors.ControlLight;
            Console_Advanced_Textbox_UI.Dock = DockStyle.Fill;
            Console_Advanced_Textbox_UI.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Console_Advanced_Textbox_UI.ForeColor = SystemColors.ActiveCaptionText;
            Console_Advanced_Textbox_UI.Location = new Point(0, 0);
            Console_Advanced_Textbox_UI.Name = "Console_Advanced_Textbox_UI";
            Console_Advanced_Textbox_UI.ReadOnly = true;
            Console_Advanced_Textbox_UI.ScrollBars = RichTextBoxScrollBars.Vertical;
            Console_Advanced_Textbox_UI.Size = new Size(297, 159);
            Console_Advanced_Textbox_UI.TabIndex = 5;
            Console_Advanced_Textbox_UI.Text = "";
            // 
            // Label_Time_UI
            // 
            Label_Time_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Time_UI.Location = new Point(172, 73);
            Label_Time_UI.Margin = new Padding(0);
            Label_Time_UI.Name = "Label_Time_UI";
            Label_Time_UI.ReadOnly = true;
            Label_Time_UI.Size = new Size(136, 36);
            Label_Time_UI.TabIndex = 20;
            Label_Time_UI.Text = "Not connected";
            Label_Time_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Location = new Point(6, 73);
            label3.Name = "label3";
            label3.Size = new Size(151, 36);
            label3.TabIndex = 19;
            label3.Text = "Online:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Name1
            // 
            Name1.AutoSize = true;
            Name1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Name1.Location = new Point(3, 25);
            Name1.Name = "Name1";
            Name1.Size = new Size(184, 37);
            Name1.TabIndex = 18;
            Name1.Text = "SM70-CP-450";
            // 
            // StatusCurrentOperation_UI
            // 
            StatusCurrentOperation_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            StatusCurrentOperation_UI.Location = new Point(172, 115);
            StatusCurrentOperation_UI.Margin = new Padding(0);
            StatusCurrentOperation_UI.Name = "StatusCurrentOperation_UI";
            StatusCurrentOperation_UI.ReadOnly = true;
            StatusCurrentOperation_UI.Size = new Size(136, 36);
            StatusCurrentOperation_UI.TabIndex = 17;
            StatusCurrentOperation_UI.Text = "None";
            StatusCurrentOperation_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.Location = new Point(6, 115);
            label7.Name = "label7";
            label7.Size = new Size(151, 36);
            label7.TabIndex = 16;
            label7.Text = "Current Operation:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 668);
            Controls.Add(groupBox1);
            Controls.Add(settingsBox_UI);
            Controls.Add(LiveInfoData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Whisper Power - Sm15k Controller";
            LiveInfoData.ResumeLayout(false);
            LiveInfoData.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            OperationsBox_UI.ResumeLayout(false);
            OperationsBox_UI.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            settingsBox_UI.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ConsoleBox.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            Simple.ResumeLayout(false);
            Advanced.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox LiveInfoData;
        private GroupBox OperationsBox_UI;
        private TableLayoutPanel tableLayoutPanel4;
        private Button Charge30Button;
        private Button ChargeButton;
        private Button DischargeButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button StartStopButton;
        private GroupBox groupBox2;
        private Button ApplyBatteryDataButton;
        private TextBox C_Rating_UI;
        private TextBox RatedBatteryVoltageUI;
        private Label label1;
        private Label label6;
        private Label label2;
        private TextBox RatedBatteryAmperageUI;
        private Button BatteryConnectButton;
        private GroupBox settingsBox_UI;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label WattageDisplay;
        private Label VoltageDisplay;
        private Label AmperageDisplay;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox InputField_StoredValueCurrentPlus;
        private TextBox InputField_StoredValuePowerMin;
        private TextBox InputField_StoredValuePowerPlus;
        private TextBox InputField_StoredValueCurrentMin;
        private Label Label_MachineAppliedPowerPlus_UI;
        private Label Label_Remote_CP_UI;
        private Label Label_MachineAppliedPowerMin_UI;
        private Label Label_MachineAppliedCurrentPlus_UI;
        private Label Label_Remote_CC_UI;
        private Label Label_MachineAppliedCurrentMin_UI;
        private TableLayoutPanel tableLayoutPanel8;
        private TextBox InputField_StoredValueVoltage;
        private Button Button_Toggle_ValueEditor;
        private TableLayoutPanel tableLayoutPanel9;
        private Label Label_MachineAppliedVoltage_UI;
        private Label Label_Remote_CV_UI;
        private GroupBox groupBox1;
        private TextBox Label_Time_UI;
        private Label label3;
        private Label Name1;
        private TextBox StatusCurrentOperation_UI;
        private Label label7;
        private ContextMenuStrip contextMenuStrip1;
        private GroupBox ConsoleBox;
        private TabControl tabControl1;
        private TabPage Simple;
        private RichTextBox Console_Simple_Textbox_UI;
        private TabPage Advanced;
        private RichTextBox Console_Advanced_Textbox_UI;
        private TextBox Label_Elapsed_Time_UI;
        private Label label4;
    }
}