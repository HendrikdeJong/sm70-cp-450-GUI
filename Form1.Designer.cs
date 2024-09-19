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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            ConsoleBox = new GroupBox();
            toolStrip1 = new ToolStrip();
            ToggleConsole_Btn = new ToolStripButton();
            ConsoleClear_Btn = new ToolStripButton();
            Console_DownloadBtn = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            Console_Short_ErrorLabel = new ToolStripLabel();
            Console_Simple_Textbox_UI = new RichTextBox();
            StatusCurrentOperation_UI = new TextBox();
            label7 = new Label();
            label4 = new Label();
            Label_Elapsed_Time_UI = new TextBox();
            TotalTime_Label = new TextBox();
            label3 = new Label();
            Label_Total_Time_UI = new TextBox();
            label5 = new Label();
            FactoryInformationBox = new GroupBox();
            ApplyBatteryDataButton = new Button();
            C_Rating_UI = new TextBox();
            RatedBatteryVoltageUI = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            RatedBatteryAmperageUI = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenu_ImportSettings = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripMenuItem8 = new ToolStripMenuItem();
            RuntimeCSV_ToolstripItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripMenuItem2 = new ToolStripMenuItem();
            errorLogToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuISettings = new ToolStripMenuItem();
            toolStripMenuSetting_keepSessionData = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            Menu_SocketTab = new ToolStripMenuItem();
            SocketTab_Connect_Btn = new ToolStripMenuItem();
            SocketTab_Disconnect_Btn = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripMenuItem7 = new ToolStripMenuItem();
            LimitLabel_01 = new ToolStripTextBox();
            LimitLabel_02 = new ToolStripTextBox();
            LimitLabel_03 = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            LimitLabel_04 = new ToolStripTextBox();
            LimitLabel_05 = new ToolStripTextBox();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripTextBox2 = new ToolStripTextBox();
            toolStripTextBox3 = new ToolStripTextBox();
            toolStripMenuItem5 = new ToolStripMenuItem();
            MenuItem_Documentation = new ToolStripMenuItem();
            LinkToDeltaElectronica = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripTextBox1 = new ToolStripMenuItem();
            OperationsBox_UI = new GroupBox();
            BatteryHandleBox = new GroupBox();
            ControlPanel = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            TrackbarDischarge = new TrackBar();
            TrackbarCharge = new TrackBar();
            Operation_NoneORStop_Selection = new Button();
            Operation_DischargeTo30_selection = new Button();
            Operation_Output_Switch = new Button();
            Operation_Charge_selection = new Button();
            Operation_Discharge_selection = new Button();
            Operation_ConnectBattery_Override = new CheckBox();
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            groupBox1.SuspendLayout();
            ConsoleBox.SuspendLayout();
            toolStrip1.SuspendLayout();
            FactoryInformationBox.SuspendLayout();
            menuStrip1.SuspendLayout();
            OperationsBox_UI.SuspendLayout();
            BatteryHandleBox.SuspendLayout();
            ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackbarDischarge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TrackbarCharge).BeginInit();
            SuspendLayout();
            // 
            // LiveInfoData
            // 
            LiveInfoData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LiveInfoData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LiveInfoData.Controls.Add(tableLayoutPanel2);
            LiveInfoData.Location = new Point(12, 27);
            LiveInfoData.Name = "LiveInfoData";
            LiveInfoData.Size = new Size(883, 198);
            LiveInfoData.TabIndex = 5;
            LiveInfoData.TabStop = false;
            LiveInfoData.Text = "SM70-CP-450 Controller Status:";
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
            tableLayoutPanel2.Size = new Size(877, 170);
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
            tableLayoutPanel9.Location = new Point(3, 45);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(286, 53);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // Label_MachineAppliedVoltage_UI
            // 
            Label_MachineAppliedVoltage_UI.AutoSize = true;
            Label_MachineAppliedVoltage_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedVoltage_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedVoltage_UI.Location = new Point(146, 0);
            Label_MachineAppliedVoltage_UI.Name = "Label_MachineAppliedVoltage_UI";
            Label_MachineAppliedVoltage_UI.Size = new Size(137, 26);
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
            Label_Remote_CV_UI.Size = new Size(137, 26);
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
            tableLayoutPanel8.Location = new Point(3, 104);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(286, 63);
            tableLayoutPanel8.TabIndex = 12;
            // 
            // InputField_StoredValueVoltage
            // 
            InputField_StoredValueVoltage.Dock = DockStyle.Fill;
            InputField_StoredValueVoltage.Location = new Point(3, 3);
            InputField_StoredValueVoltage.Name = "InputField_StoredValueVoltage";
            InputField_StoredValueVoltage.PlaceholderText = "0 A";
            InputField_StoredValueVoltage.ReadOnly = true;
            InputField_StoredValueVoltage.Size = new Size(280, 29);
            InputField_StoredValueVoltage.TabIndex = 0;
            InputField_StoredValueVoltage.Tag = "";
            InputField_StoredValueVoltage.TextAlign = HorizontalAlignment.Center;
            // 
            // Button_Toggle_ValueEditor
            // 
            Button_Toggle_ValueEditor.AutoSize = true;
            Button_Toggle_ValueEditor.Dock = DockStyle.Fill;
            Button_Toggle_ValueEditor.Location = new Point(3, 34);
            Button_Toggle_ValueEditor.Name = "Button_Toggle_ValueEditor";
            Button_Toggle_ValueEditor.Size = new Size(280, 26);
            Button_Toggle_ValueEditor.TabIndex = 1;
            Button_Toggle_ValueEditor.Text = "Edit values";
            Button_Toggle_ValueEditor.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerMin, 0, 1);
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerPlus, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(587, 104);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(287, 63);
            tableLayoutPanel7.TabIndex = 11;
            // 
            // InputField_StoredValuePowerMin
            // 
            InputField_StoredValuePowerMin.Dock = DockStyle.Fill;
            InputField_StoredValuePowerMin.Location = new Point(3, 34);
            InputField_StoredValuePowerMin.Name = "InputField_StoredValuePowerMin";
            InputField_StoredValuePowerMin.PlaceholderText = "0 W";
            InputField_StoredValuePowerMin.ReadOnly = true;
            InputField_StoredValuePowerMin.Size = new Size(281, 29);
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
            InputField_StoredValuePowerPlus.Size = new Size(281, 29);
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
            tableLayoutPanel5.Location = new Point(587, 45);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(287, 53);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // Label_MachineAppliedPowerPlus_UI
            // 
            Label_MachineAppliedPowerPlus_UI.AutoSize = true;
            Label_MachineAppliedPowerPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerPlus_UI.Location = new Point(146, 0);
            Label_MachineAppliedPowerPlus_UI.Name = "Label_MachineAppliedPowerPlus_UI";
            Label_MachineAppliedPowerPlus_UI.Size = new Size(138, 26);
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
            Label_Remote_CP_UI.Size = new Size(137, 26);
            Label_Remote_CP_UI.TabIndex = 10;
            Label_Remote_CP_UI.Text = "Front";
            Label_Remote_CP_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedPowerMin_UI
            // 
            Label_MachineAppliedPowerMin_UI.AutoSize = true;
            Label_MachineAppliedPowerMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerMin_UI.Location = new Point(146, 26);
            Label_MachineAppliedPowerMin_UI.Name = "Label_MachineAppliedPowerMin_UI";
            Label_MachineAppliedPowerMin_UI.Size = new Size(138, 27);
            Label_MachineAppliedPowerMin_UI.TabIndex = 9;
            Label_MachineAppliedPowerMin_UI.Text = "-0 W";
            Label_MachineAppliedPowerMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WattageDisplay
            // 
            WattageDisplay.AutoSize = true;
            WattageDisplay.Dock = DockStyle.Fill;
            WattageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            WattageDisplay.Location = new Point(588, 0);
            WattageDisplay.Margin = new Padding(4, 0, 4, 0);
            WattageDisplay.Name = "WattageDisplay";
            WattageDisplay.Size = new Size(285, 42);
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
            VoltageDisplay.Size = new Size(284, 42);
            VoltageDisplay.TabIndex = 0;
            VoltageDisplay.Text = "0.0 V";
            VoltageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AmperageDisplay
            // 
            AmperageDisplay.AutoSize = true;
            AmperageDisplay.Dock = DockStyle.Fill;
            AmperageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            AmperageDisplay.Location = new Point(296, 0);
            AmperageDisplay.Margin = new Padding(4, 0, 4, 0);
            AmperageDisplay.Name = "AmperageDisplay";
            AmperageDisplay.Size = new Size(284, 42);
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
            tableLayoutPanel3.Location = new Point(295, 45);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(286, 53);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // Label_MachineAppliedCurrentPlus_UI
            // 
            Label_MachineAppliedCurrentPlus_UI.AutoSize = true;
            Label_MachineAppliedCurrentPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentPlus_UI.Location = new Point(146, 0);
            Label_MachineAppliedCurrentPlus_UI.Name = "Label_MachineAppliedCurrentPlus_UI";
            Label_MachineAppliedCurrentPlus_UI.Size = new Size(137, 26);
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
            Label_Remote_CC_UI.Size = new Size(137, 26);
            Label_Remote_CC_UI.TabIndex = 9;
            Label_Remote_CC_UI.Text = "Front";
            Label_Remote_CC_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedCurrentMin_UI
            // 
            Label_MachineAppliedCurrentMin_UI.AutoSize = true;
            Label_MachineAppliedCurrentMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentMin_UI.Location = new Point(146, 26);
            Label_MachineAppliedCurrentMin_UI.Name = "Label_MachineAppliedCurrentMin_UI";
            Label_MachineAppliedCurrentMin_UI.Size = new Size(137, 27);
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
            tableLayoutPanel6.Location = new Point(295, 104);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(286, 63);
            tableLayoutPanel6.TabIndex = 10;
            // 
            // InputField_StoredValueCurrentMin
            // 
            InputField_StoredValueCurrentMin.Dock = DockStyle.Fill;
            InputField_StoredValueCurrentMin.Location = new Point(3, 34);
            InputField_StoredValueCurrentMin.Name = "InputField_StoredValueCurrentMin";
            InputField_StoredValueCurrentMin.PlaceholderText = "0 A";
            InputField_StoredValueCurrentMin.ReadOnly = true;
            InputField_StoredValueCurrentMin.Size = new Size(280, 29);
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
            InputField_StoredValueCurrentPlus.Size = new Size(280, 29);
            InputField_StoredValueCurrentPlus.TabIndex = 0;
            InputField_StoredValueCurrentPlus.Tag = "";
            InputField_StoredValueCurrentPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBox1.Controls.Add(ConsoleBox);
            groupBox1.Controls.Add(StatusCurrentOperation_UI);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(Label_Elapsed_Time_UI);
            groupBox1.Controls.Add(TotalTime_Label);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(Label_Total_Time_UI);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(12, 231);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(438, 474);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // ConsoleBox
            // 
            ConsoleBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConsoleBox.Controls.Add(toolStrip1);
            ConsoleBox.Controls.Add(Console_Simple_Textbox_UI);
            ConsoleBox.Dock = DockStyle.Bottom;
            ConsoleBox.Location = new Point(3, 421);
            ConsoleBox.MaximumSize = new Size(450, 267);
            ConsoleBox.MinimumSize = new Size(300, 50);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.Size = new Size(432, 50);
            ConsoleBox.TabIndex = 22;
            ConsoleBox.TabStop = false;
            ConsoleBox.Text = "Console";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToggleConsole_Btn, ConsoleClear_Btn, Console_DownloadBtn, toolStripSeparator4, Console_Short_ErrorLabel });
            toolStrip1.Location = new Point(3, 22);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(426, 25);
            toolStrip1.TabIndex = 27;
            toolStrip1.Text = "toolStrip1";
            // 
            // ToggleConsole_Btn
            // 
            ToggleConsole_Btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ToggleConsole_Btn.Image = Properties.Resources.Console;
            ToggleConsole_Btn.ImageTransparentColor = Color.Magenta;
            ToggleConsole_Btn.Name = "ToggleConsole_Btn";
            ToggleConsole_Btn.Size = new Size(23, 22);
            ToggleConsole_Btn.Tag = "ToggleConsole";
            ToggleConsole_Btn.Text = "Close Console";
            ToggleConsole_Btn.Click += ButtonHandler;
            // 
            // ConsoleClear_Btn
            // 
            ConsoleClear_Btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ConsoleClear_Btn.Image = Properties.Resources.CleanData;
            ConsoleClear_Btn.ImageTransparentColor = Color.Magenta;
            ConsoleClear_Btn.Name = "ConsoleClear_Btn";
            ConsoleClear_Btn.Size = new Size(23, 22);
            ConsoleClear_Btn.Tag = "ClearConsole";
            ConsoleClear_Btn.Text = "Clear console";
            ConsoleClear_Btn.Click += ButtonHandler;
            // 
            // Console_DownloadBtn
            // 
            Console_DownloadBtn.DisplayStyle = ToolStripItemDisplayStyle.Image;
            Console_DownloadBtn.Image = Properties.Resources.Save;
            Console_DownloadBtn.ImageTransparentColor = Color.Magenta;
            Console_DownloadBtn.Name = "Console_DownloadBtn";
            Console_DownloadBtn.Size = new Size(23, 22);
            Console_DownloadBtn.Tag = "SaveLOG";
            Console_DownloadBtn.Text = "Download Log";
            Console_DownloadBtn.Click += ButtonHandler;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // Console_Short_ErrorLabel
            // 
            Console_Short_ErrorLabel.ForeColor = Color.DarkRed;
            Console_Short_ErrorLabel.Name = "Console_Short_ErrorLabel";
            Console_Short_ErrorLabel.Overflow = ToolStripItemOverflow.Never;
            Console_Short_ErrorLabel.RightToLeft = RightToLeft.No;
            Console_Short_ErrorLabel.Size = new Size(259, 22);
            Console_Short_ErrorLabel.Text = "this is where error should appear if there are any";
            // 
            // Console_Simple_Textbox_UI
            // 
            Console_Simple_Textbox_UI.BackColor = SystemColors.ControlLight;
            Console_Simple_Textbox_UI.Dock = DockStyle.Fill;
            Console_Simple_Textbox_UI.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Console_Simple_Textbox_UI.ForeColor = SystemColors.ActiveCaptionText;
            Console_Simple_Textbox_UI.Location = new Point(3, 25);
            Console_Simple_Textbox_UI.Name = "Console_Simple_Textbox_UI";
            Console_Simple_Textbox_UI.ReadOnly = true;
            Console_Simple_Textbox_UI.ScrollBars = RichTextBoxScrollBars.Vertical;
            Console_Simple_Textbox_UI.Size = new Size(426, 22);
            Console_Simple_Textbox_UI.TabIndex = 5;
            Console_Simple_Textbox_UI.TabStop = false;
            Console_Simple_Textbox_UI.Text = "";
            // 
            // StatusCurrentOperation_UI
            // 
            StatusCurrentOperation_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StatusCurrentOperation_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            StatusCurrentOperation_UI.Location = new Point(152, 25);
            StatusCurrentOperation_UI.Margin = new Padding(0);
            StatusCurrentOperation_UI.Name = "StatusCurrentOperation_UI";
            StatusCurrentOperation_UI.ReadOnly = true;
            StatusCurrentOperation_UI.Size = new Size(144, 36);
            StatusCurrentOperation_UI.TabIndex = 17;
            StatusCurrentOperation_UI.Text = "None";
            StatusCurrentOperation_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.Location = new Point(6, 25);
            label7.Name = "label7";
            label7.Size = new Size(142, 36);
            label7.TabIndex = 16;
            label7.Text = "Current Operation:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(6, 68);
            label4.Name = "label4";
            label4.Size = new Size(142, 36);
            label4.TabIndex = 23;
            label4.Text = "Time Elapsed:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_Elapsed_Time_UI
            // 
            Label_Elapsed_Time_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_Elapsed_Time_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Elapsed_Time_UI.Location = new Point(152, 66);
            Label_Elapsed_Time_UI.Margin = new Padding(0);
            Label_Elapsed_Time_UI.Name = "Label_Elapsed_Time_UI";
            Label_Elapsed_Time_UI.ReadOnly = true;
            Label_Elapsed_Time_UI.Size = new Size(144, 36);
            Label_Elapsed_Time_UI.TabIndex = 24;
            Label_Elapsed_Time_UI.Text = "00:00:00";
            Label_Elapsed_Time_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // TotalTime_Label
            // 
            TotalTime_Label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TotalTime_Label.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            TotalTime_Label.Location = new Point(152, 156);
            TotalTime_Label.Margin = new Padding(0);
            TotalTime_Label.Name = "TotalTime_Label";
            TotalTime_Label.ReadOnly = true;
            TotalTime_Label.Size = new Size(144, 36);
            TotalTime_Label.TabIndex = 26;
            TotalTime_Label.Text = "00:00:00";
            TotalTime_Label.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.Location = new Point(6, 156);
            label3.Name = "label3";
            label3.Size = new Size(142, 36);
            label3.TabIndex = 25;
            label3.Text = "Total Time:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_Total_Time_UI
            // 
            Label_Total_Time_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_Total_Time_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Total_Time_UI.Location = new Point(152, 107);
            Label_Total_Time_UI.Margin = new Padding(0);
            Label_Total_Time_UI.Name = "Label_Total_Time_UI";
            Label_Total_Time_UI.ReadOnly = true;
            Label_Total_Time_UI.Size = new Size(144, 36);
            Label_Total_Time_UI.TabIndex = 26;
            Label_Total_Time_UI.Text = "00:00:00";
            Label_Total_Time_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.Location = new Point(6, 107);
            label5.Name = "label5";
            label5.Size = new Size(142, 36);
            label5.TabIndex = 25;
            label5.Text = "Estimated Time:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FactoryInformationBox
            // 
            FactoryInformationBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FactoryInformationBox.Controls.Add(ApplyBatteryDataButton);
            FactoryInformationBox.Controls.Add(C_Rating_UI);
            FactoryInformationBox.Controls.Add(RatedBatteryVoltageUI);
            FactoryInformationBox.Controls.Add(label1);
            FactoryInformationBox.Controls.Add(label6);
            FactoryInformationBox.Controls.Add(label2);
            FactoryInformationBox.Controls.Add(RatedBatteryAmperageUI);
            FactoryInformationBox.Dock = DockStyle.Top;
            FactoryInformationBox.Location = new Point(3, 25);
            FactoryInformationBox.Name = "FactoryInformationBox";
            FactoryInformationBox.Size = new Size(433, 173);
            FactoryInformationBox.TabIndex = 18;
            FactoryInformationBox.TabStop = false;
            FactoryInformationBox.Text = "Factory Information";
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ApplyBatteryDataButton.Location = new Point(6, 131);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(421, 36);
            ApplyBatteryDataButton.TabIndex = 11;
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            // 
            // C_Rating_UI
            // 
            C_Rating_UI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            C_Rating_UI.Location = new Point(307, 98);
            C_Rating_UI.Name = "C_Rating_UI";
            C_Rating_UI.PlaceholderText = "C1";
            C_Rating_UI.Size = new Size(120, 29);
            C_Rating_UI.TabIndex = 10;
            // 
            // RatedBatteryVoltageUI
            // 
            RatedBatteryVoltageUI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            RatedBatteryVoltageUI.Location = new Point(307, 28);
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
            RatedBatteryAmperageUI.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            RatedBatteryAmperageUI.Location = new Point(307, 63);
            RatedBatteryAmperageUI.Name = "RatedBatteryAmperageUI";
            RatedBatteryAmperageUI.PlaceholderText = "Amps / Hour";
            RatedBatteryAmperageUI.Size = new Size(120, 29);
            RatedBatteryAmperageUI.TabIndex = 7;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolsToolStripMenuItem, toolStripMenuItem5 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(907, 24);
            menuStrip1.TabIndex = 17;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenu_ImportSettings, toolStripMenuItem3, toolStripSeparator6, toolStripMenuItem8, RuntimeCSV_ToolstripItem, toolStripSeparator5, toolStripMenuItem2, errorLogToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "&File";
            // 
            // ToolStripMenu_ImportSettings
            // 
            ToolStripMenu_ImportSettings.Image = Properties.Resources.ImportSettings;
            ToolStripMenu_ImportSettings.Name = "ToolStripMenu_ImportSettings";
            ToolStripMenu_ImportSettings.Size = new Size(186, 22);
            ToolStripMenu_ImportSettings.Text = "Import Settings";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Image = Properties.Resources.ExportSettings;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(186, 22);
            toolStripMenuItem3.Text = "Export Settings";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(183, 6);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Image = Properties.Resources.Save;
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(186, 22);
            toolStripMenuItem8.Tag = "SaveCSV";
            toolStripMenuItem8.Text = "Save Runtime CSV";
            toolStripMenuItem8.Click += ButtonHandler;
            // 
            // RuntimeCSV_ToolstripItem
            // 
            RuntimeCSV_ToolstripItem.Image = Properties.Resources.SaveAs;
            RuntimeCSV_ToolstripItem.Name = "RuntimeCSV_ToolstripItem";
            RuntimeCSV_ToolstripItem.Size = new Size(186, 22);
            RuntimeCSV_ToolstripItem.Tag = "SaveAsCSV";
            RuntimeCSV_ToolstripItem.Text = "Save Runtime CSV As";
            RuntimeCSV_ToolstripItem.Click += ButtonHandler;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(183, 6);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Image = Properties.Resources.Save;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(186, 22);
            toolStripMenuItem2.Tag = "SaveLOG";
            toolStripMenuItem2.Text = "Save ErrorLog";
            toolStripMenuItem2.Click += ButtonHandler;
            // 
            // errorLogToolStripMenuItem
            // 
            errorLogToolStripMenuItem.Image = Properties.Resources.SaveAs;
            errorLogToolStripMenuItem.Name = "errorLogToolStripMenuItem";
            errorLogToolStripMenuItem.Size = new Size(186, 22);
            errorLogToolStripMenuItem.Tag = "SaveAsLOG";
            errorLogToolStripMenuItem.Text = "Save ErrorLog As";
            errorLogToolStripMenuItem.Click += ButtonHandler;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuISettings, Menu_SocketTab, toolStripSeparator7, toolStripMenuItem7, toolStripMenuItem6 });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(44, 20);
            toolsToolStripMenuItem.Text = "&View";
            // 
            // toolStripMenuISettings
            // 
            toolStripMenuISettings.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuSetting_keepSessionData, toolStripSeparator3, toolStripMenuItem4, toolStripMenuItem9 });
            toolStripMenuISettings.Image = Properties.Resources.SettingsGroup;
            toolStripMenuISettings.Name = "toolStripMenuISettings";
            toolStripMenuISettings.Size = new Size(174, 22);
            toolStripMenuISettings.Text = "Settings";
            // 
            // toolStripMenuSetting_keepSessionData
            // 
            toolStripMenuSetting_keepSessionData.CheckOnClick = true;
            toolStripMenuSetting_keepSessionData.Image = Properties.Resources.Settings;
            toolStripMenuSetting_keepSessionData.Name = "toolStripMenuSetting_keepSessionData";
            toolStripMenuSetting_keepSessionData.Size = new Size(220, 22);
            toolStripMenuSetting_keepSessionData.Tag = "ToggleSessionData";
            toolStripMenuSetting_keepSessionData.Text = "Auto save input data";
            toolStripMenuSetting_keepSessionData.Click += ButtonHandler;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(217, 6);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Image = Properties.Resources.FolderOpened;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(220, 22);
            toolStripMenuItem4.Text = "Set Default CSV file location";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Image = Properties.Resources.FolderOpened;
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(220, 22);
            toolStripMenuItem9.Text = "Set Default Log file location";
            // 
            // Menu_SocketTab
            // 
            Menu_SocketTab.DropDownItems.AddRange(new ToolStripItem[] { SocketTab_Connect_Btn, SocketTab_Disconnect_Btn });
            Menu_SocketTab.Image = Properties.Resources.RemoteServer;
            Menu_SocketTab.Name = "Menu_SocketTab";
            Menu_SocketTab.Size = new Size(174, 22);
            Menu_SocketTab.Text = "Socket Connection";
            // 
            // SocketTab_Connect_Btn
            // 
            SocketTab_Connect_Btn.Image = Properties.Resources.ConnectToRemoteServer;
            SocketTab_Connect_Btn.Name = "SocketTab_Connect_Btn";
            SocketTab_Connect_Btn.Size = new Size(168, 22);
            SocketTab_Connect_Btn.Tag = "TryConnectSocket";
            SocketTab_Connect_Btn.Text = "connect to sm15k";
            SocketTab_Connect_Btn.Click += ButtonHandler;
            // 
            // SocketTab_Disconnect_Btn
            // 
            SocketTab_Disconnect_Btn.Image = Properties.Resources.Disconnect;
            SocketTab_Disconnect_Btn.Name = "SocketTab_Disconnect_Btn";
            SocketTab_Disconnect_Btn.Size = new Size(168, 22);
            SocketTab_Disconnect_Btn.Tag = "DisconnectSocket";
            SocketTab_Disconnect_Btn.Text = "Close Connection";
            SocketTab_Disconnect_Btn.Click += ButtonHandler;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(171, 6);
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.DropDownItems.AddRange(new ToolStripItem[] { LimitLabel_01, LimitLabel_02, LimitLabel_03, toolStripSeparator1, LimitLabel_04, LimitLabel_05 });
            toolStripMenuItem7.Image = Properties.Resources.Memory;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(174, 22);
            toolStripMenuItem7.Text = "Machine Limits";
            // 
            // LimitLabel_01
            // 
            LimitLabel_01.Name = "LimitLabel_01";
            LimitLabel_01.ReadOnly = true;
            LimitLabel_01.Size = new Size(100, 23);
            // 
            // LimitLabel_02
            // 
            LimitLabel_02.Name = "LimitLabel_02";
            LimitLabel_02.ReadOnly = true;
            LimitLabel_02.Size = new Size(100, 23);
            // 
            // LimitLabel_03
            // 
            LimitLabel_03.Name = "LimitLabel_03";
            LimitLabel_03.ReadOnly = true;
            LimitLabel_03.Size = new Size(100, 23);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(157, 6);
            // 
            // LimitLabel_04
            // 
            LimitLabel_04.Name = "LimitLabel_04";
            LimitLabel_04.ReadOnly = true;
            LimitLabel_04.Size = new Size(100, 23);
            // 
            // LimitLabel_05
            // 
            LimitLabel_05.Name = "LimitLabel_05";
            LimitLabel_05.ReadOnly = true;
            LimitLabel_05.Size = new Size(100, 23);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox2, toolStripTextBox3 });
            toolStripMenuItem6.Image = Properties.Resources.Key;
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(174, 22);
            toolStripMenuItem6.Text = "Ip Configuration";
            // 
            // toolStripTextBox2
            // 
            toolStripTextBox2.Name = "toolStripTextBox2";
            toolStripTextBox2.ReadOnly = true;
            toolStripTextBox2.Size = new Size(100, 23);
            toolStripTextBox2.Text = "IP: 169.254.0.102";
            // 
            // toolStripTextBox3
            // 
            toolStripTextBox3.Name = "toolStripTextBox3";
            toolStripTextBox3.ReadOnly = true;
            toolStripTextBox3.Size = new Size(100, 23);
            toolStripTextBox3.Text = "Port: 8462";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { MenuItem_Documentation });
            toolStripMenuItem5.ImageScaling = ToolStripItemImageScaling.None;
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(44, 20);
            toolStripMenuItem5.Text = "&Help";
            // 
            // MenuItem_Documentation
            // 
            MenuItem_Documentation.DropDownItems.AddRange(new ToolStripItem[] { LinkToDeltaElectronica, toolStripSeparator2, toolStripTextBox1 });
            MenuItem_Documentation.Image = Properties.Resources.StatusInformation;
            MenuItem_Documentation.Name = "MenuItem_Documentation";
            MenuItem_Documentation.Size = new Size(157, 22);
            MenuItem_Documentation.Text = "Documentation";
            // 
            // LinkToDeltaElectronica
            // 
            LinkToDeltaElectronica.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            LinkToDeltaElectronica.ForeColor = Color.Blue;
            LinkToDeltaElectronica.Image = Properties.Resources.StatusHelp;
            LinkToDeltaElectronica.Name = "LinkToDeltaElectronica";
            LinkToDeltaElectronica.Size = new Size(359, 22);
            LinkToDeltaElectronica.Tag = "OpenDeltaURL";
            LinkToDeltaElectronica.Text = "Delta elektronika Sm15k series ";
            LinkToDeltaElectronica.Click += ButtonHandler;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(356, 6);
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            toolStripTextBox1.ForeColor = Color.Blue;
            toolStripTextBox1.Image = Properties.Resources.SourceControlSites;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(359, 22);
            toolStripTextBox1.Tag = "OpenGitURL";
            toolStripTextBox1.Text = "https://github.com/HendrikdeJong/sm70-cp-450-GUI";
            toolStripTextBox1.Click += ButtonHandler;
            // 
            // OperationsBox_UI
            // 
            OperationsBox_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OperationsBox_UI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OperationsBox_UI.Controls.Add(BatteryHandleBox);
            OperationsBox_UI.Controls.Add(FactoryInformationBox);
            OperationsBox_UI.Location = new Point(456, 231);
            OperationsBox_UI.Name = "OperationsBox_UI";
            OperationsBox_UI.Size = new Size(439, 471);
            OperationsBox_UI.TabIndex = 18;
            OperationsBox_UI.TabStop = false;
            OperationsBox_UI.Text = "Operations";
            // 
            // BatteryHandleBox
            // 
            BatteryHandleBox.Controls.Add(ControlPanel);
            BatteryHandleBox.Controls.Add(Operation_ConnectBattery_Override);
            BatteryHandleBox.Location = new Point(9, 210);
            BatteryHandleBox.Name = "BatteryHandleBox";
            BatteryHandleBox.Size = new Size(421, 261);
            BatteryHandleBox.TabIndex = 19;
            BatteryHandleBox.TabStop = false;
            BatteryHandleBox.Text = "Please connect battery";
            // 
            // ControlPanel
            // 
            ControlPanel.Controls.Add(label9);
            ControlPanel.Controls.Add(label8);
            ControlPanel.Controls.Add(TrackbarDischarge);
            ControlPanel.Controls.Add(TrackbarCharge);
            ControlPanel.Controls.Add(Operation_NoneORStop_Selection);
            ControlPanel.Controls.Add(Operation_DischargeTo30_selection);
            ControlPanel.Controls.Add(Operation_Output_Switch);
            ControlPanel.Controls.Add(Operation_Charge_selection);
            ControlPanel.Controls.Add(Operation_Discharge_selection);
            ControlPanel.Dock = DockStyle.Bottom;
            ControlPanel.Location = new Point(3, 59);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(415, 199);
            ControlPanel.TabIndex = 19;
            ControlPanel.TabStop = false;
            ControlPanel.Text = "Controls";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(0, 89);
            label9.Name = "label9";
            label9.Size = new Size(114, 21);
            label9.TabIndex = 28;
            label9.Text = "Discharge to %";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 25);
            label8.Name = "label8";
            label8.Size = new Size(95, 21);
            label8.TabIndex = 28;
            label8.Text = "Charge to %";
            // 
            // TrackbarDischarge
            // 
            TrackbarDischarge.LargeChange = 30;
            TrackbarDischarge.Location = new Point(0, 113);
            TrackbarDischarge.Maximum = 100;
            TrackbarDischarge.Minimum = 10;
            TrackbarDischarge.Name = "TrackbarDischarge";
            TrackbarDischarge.Size = new Size(122, 45);
            TrackbarDischarge.SmallChange = 10;
            TrackbarDischarge.TabIndex = 0;
            TrackbarDischarge.TickFrequency = 10;
            TrackbarDischarge.Value = 100;
            // 
            // TrackbarCharge
            // 
            TrackbarCharge.LargeChange = 30;
            TrackbarCharge.Location = new Point(0, 49);
            TrackbarCharge.Maximum = 100;
            TrackbarCharge.Minimum = 10;
            TrackbarCharge.Name = "TrackbarCharge";
            TrackbarCharge.Size = new Size(122, 45);
            TrackbarCharge.SmallChange = 10;
            TrackbarCharge.TabIndex = 0;
            TrackbarCharge.TickFrequency = 10;
            TrackbarCharge.Value = 10;
            // 
            // Operation_NoneORStop_Selection
            // 
            Operation_NoneORStop_Selection.Location = new Point(270, 28);
            Operation_NoneORStop_Selection.Name = "Operation_NoneORStop_Selection";
            Operation_NoneORStop_Selection.Size = new Size(139, 30);
            Operation_NoneORStop_Selection.TabIndex = 27;
            Operation_NoneORStop_Selection.Tag = "SetStateIdle";
            Operation_NoneORStop_Selection.Text = "Idle";
            Operation_NoneORStop_Selection.UseVisualStyleBackColor = true;
            Operation_NoneORStop_Selection.Click += ButtonHandler;
            // 
            // Operation_DischargeTo30_selection
            // 
            Operation_DischargeTo30_selection.Location = new Point(270, 137);
            Operation_DischargeTo30_selection.Name = "Operation_DischargeTo30_selection";
            Operation_DischargeTo30_selection.Size = new Size(139, 30);
            Operation_DischargeTo30_selection.TabIndex = 27;
            Operation_DischargeTo30_selection.Tag = "SetStateConnectingBattery";
            Operation_DischargeTo30_selection.Text = "ConnectingBattery";
            Operation_DischargeTo30_selection.UseVisualStyleBackColor = true;
            Operation_DischargeTo30_selection.Click += ButtonHandler;
            // 
            // Operation_Output_Switch
            // 
            Operation_Output_Switch.Location = new Point(149, 28);
            Operation_Output_Switch.Name = "Operation_Output_Switch";
            Operation_Output_Switch.Size = new Size(115, 30);
            Operation_Output_Switch.TabIndex = 27;
            Operation_Output_Switch.Text = "Start";
            Operation_Output_Switch.UseVisualStyleBackColor = true;
            // 
            // Operation_Charge_selection
            // 
            Operation_Charge_selection.Location = new Point(270, 64);
            Operation_Charge_selection.Name = "Operation_Charge_selection";
            Operation_Charge_selection.Size = new Size(139, 30);
            Operation_Charge_selection.TabIndex = 27;
            Operation_Charge_selection.Tag = "SetStateCharge";
            Operation_Charge_selection.Text = "Charge";
            Operation_Charge_selection.UseVisualStyleBackColor = true;
            Operation_Charge_selection.Click += ButtonHandler;
            // 
            // Operation_Discharge_selection
            // 
            Operation_Discharge_selection.Location = new Point(270, 101);
            Operation_Discharge_selection.Name = "Operation_Discharge_selection";
            Operation_Discharge_selection.Size = new Size(139, 30);
            Operation_Discharge_selection.TabIndex = 27;
            Operation_Discharge_selection.Tag = "SetStateDischarge";
            Operation_Discharge_selection.Text = "Discharge";
            Operation_Discharge_selection.UseVisualStyleBackColor = true;
            Operation_Discharge_selection.Click += ButtonHandler;
            // 
            // Operation_ConnectBattery_Override
            // 
            Operation_ConnectBattery_Override.AutoSize = true;
            Operation_ConnectBattery_Override.Location = new Point(6, 28);
            Operation_ConnectBattery_Override.Name = "Operation_ConnectBattery_Override";
            Operation_ConnectBattery_Override.Size = new Size(272, 25);
            Operation_ConnectBattery_Override.TabIndex = 28;
            Operation_ConnectBattery_Override.Text = "Confirm Battery Battery connection";
            Operation_ConnectBattery_Override.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 714);
            Controls.Add(OperationsBox_UI);
            Controls.Add(groupBox1);
            Controls.Add(LiveInfoData);
            Controls.Add(menuStrip1);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ConsoleBox.ResumeLayout(false);
            ConsoleBox.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            FactoryInformationBox.ResumeLayout(false);
            FactoryInformationBox.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            OperationsBox_UI.ResumeLayout(false);
            BatteryHandleBox.ResumeLayout(false);
            BatteryHandleBox.PerformLayout();
            ControlPanel.ResumeLayout(false);
            ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackbarDischarge).EndInit();
            ((System.ComponentModel.ISupportInitialize)TrackbarCharge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox LiveInfoData;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private TextBox StatusCurrentOperation_UI;
        private Label label7;
        private GroupBox ConsoleBox;
        private TextBox Label_Elapsed_Time_UI;
        private Label label4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private RichTextBox Console_Simple_Textbox_UI;
        private ToolStripMenuItem ToolStripMenu_SaveSettings;
        private ToolStripMenuItem ToolStripMenu_ImportSettings;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem MenuItem_Documentation;
        private ToolStripMenuItem LinkToDeltaElectronica;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuISettings;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem Menu_SocketTab;
        private ToolStripMenuItem SocketTab_Connect_Btn;
        private ToolStripMenuItem SocketTab_Disconnect_Btn;
        private ToolStripMenuItem toolStripTextBox1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStrip toolStrip1;
        private ToolStripButton ToggleConsole_Btn;
        private ToolStripButton ConsoleClear_Btn;
        private ToolStripButton Console_DownloadBtn;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripLabel Console_Short_ErrorLabel;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem RuntimeCSV_ToolstripItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem errorLogToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuSetting_keepSessionData;
        private TextBox RatedBatteryAmperageUI;
        private TrackBar TrackbarCharge;
        private Label label2;
        private Label label6;
        private Label label1;
        private TextBox RatedBatteryVoltageUI;
        private TextBox C_Rating_UI;
        private Button ApplyBatteryDataButton;
        private GroupBox FactoryInformationBox;
        private GroupBox OperationsBox_UI;
        private TextBox Label_Total_Time_UI;
        private Label label5;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripTextBox LimitLabel_01;
        private ToolStripTextBox LimitLabel_02;
        private ToolStripTextBox LimitLabel_03;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox LimitLabel_04;
        private ToolStripTextBox LimitLabel_05;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripTextBox toolStripTextBox3;
        private Button Operation_Output_Switch;
        private CheckBox Operation_ConnectBattery_Override;
        private Button Operation_DischargeTo30_selection;
        private Button Operation_Discharge_selection;
        private Button Operation_Charge_selection;
        private Button Operation_NoneORStop_Selection;
        private GroupBox BatteryHandleBox;
        private GroupBox ControlPanel;
        private TextBox TotalTime_Label;
        private Label label3;
        private Label label9;
        private Label label8;
        private TrackBar TrackbarDischarge;
    }
}