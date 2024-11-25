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
            Button_ValueEditor = new Button();
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
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ToolStripMenu_ImportSettings = new ToolStripMenuItem();
            ToolStripMenu_ExportSettings = new ToolStripMenuItem();
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
            openManualFormToolStripMenuItem = new ToolStripMenuItem();
            openSequencerToolStripMenuItem = new ToolStripMenuItem();
            OperationsBox_UI = new GroupBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            ComboBox_SettingConfigSelect = new ComboBox();
            button3 = new Button();
            tabControl1 = new TabControl();
            Tab_IdlePage = new TabPage();
            Tab_ChargePage = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            checkBox1 = new CheckBox();
            Label_TriggerActualTime = new Label();
            Tab_DischargePage = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            Label_AccumulatedCharge = new Label();
            Label_KnownSOC = new Label();
            ControlPanel = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            Operation_Start = new Button();
            ConsoleBox = new GroupBox();
            toolStrip1 = new ToolStrip();
            ToggleConsole_Btn = new ToolStripButton();
            ConsoleClear_Btn = new ToolStripButton();
            Console_DownloadBtn = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            Console_Short_ErrorLabel = new ToolStripLabel();
            Console_Simple_Textbox_UI = new RichTextBox();
            Textbox_Capacity = new TextBox();
            label2 = new Label();
            label6 = new Label();
            label1 = new Label();
            Textbox_BulkVoltage = new TextBox();
            Textbox_MaxCurrent = new TextBox();
            ApplyBatteryDataButton = new Button();
            Textbox_TriggerPercent = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            Textbox_CutoffVoltage = new TextBox();
            Textbox_TriggerTime = new TextBox();
            Textbox_ExpectedSoc = new TextBox();
            label7 = new Label();
            Label_Cap = new Label();
            Label_MaxCurr = new Label();
            Label_Volt = new Label();
            Label_trigger = new Label();
            Label_TriggerTime = new Label();
            Label_CutVolt = new Label();
            Label_Soc = new Label();
            FactoryInformationBox = new GroupBox();
            Label_MinCurr = new Label();
            Textbox_MinCurrent = new TextBox();
            label9 = new Label();
            Timer_Update = new System.Windows.Forms.Timer(components);
            Timer_LateUpdate = new System.Windows.Forms.Timer(components);
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            menuStrip1.SuspendLayout();
            OperationsBox_UI.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tabControl1.SuspendLayout();
            Tab_ChargePage.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            Tab_DischargePage.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ControlPanel.SuspendLayout();
            ConsoleBox.SuspendLayout();
            toolStrip1.SuspendLayout();
            FactoryInformationBox.SuspendLayout();
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
            tableLayoutPanel8.Controls.Add(Button_ValueEditor, 0, 1);
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
            InputField_StoredValueVoltage.PlaceholderText = "0 V+";
            InputField_StoredValueVoltage.Size = new Size(280, 29);
            InputField_StoredValueVoltage.TabIndex = 32;
            InputField_StoredValueVoltage.Tag = "";
            InputField_StoredValueVoltage.TextAlign = HorizontalAlignment.Center;
            // 
            // Button_ValueEditor
            // 
            Button_ValueEditor.AutoSize = true;
            Button_ValueEditor.Dock = DockStyle.Fill;
            Button_ValueEditor.Location = new Point(3, 34);
            Button_ValueEditor.Name = "Button_ValueEditor";
            Button_ValueEditor.Size = new Size(280, 26);
            Button_ValueEditor.TabIndex = 1;
            Button_ValueEditor.Tag = "ManualSetValues";
            Button_ValueEditor.Text = "Manually set values";
            Button_ValueEditor.UseVisualStyleBackColor = true;
            Button_ValueEditor.Click += ButtonHandler;
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
            InputField_StoredValuePowerMin.PlaceholderText = "0 W-";
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
            InputField_StoredValueCurrentMin.PlaceholderText = "0 A-";
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
            InputField_StoredValueCurrentPlus.Size = new Size(280, 29);
            InputField_StoredValueCurrentPlus.TabIndex = 0;
            InputField_StoredValueCurrentPlus.Tag = "";
            InputField_StoredValueCurrentPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolsToolStripMenuItem, toolStripMenuItem5, openManualFormToolStripMenuItem, openSequencerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(907, 24);
            menuStrip1.TabIndex = 17;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenu_ImportSettings, ToolStripMenu_ExportSettings, toolStripSeparator6, toolStripMenuItem8, RuntimeCSV_ToolstripItem, toolStripSeparator5, toolStripMenuItem2, errorLogToolStripMenuItem });
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
            // ToolStripMenu_ExportSettings
            // 
            ToolStripMenu_ExportSettings.Image = Properties.Resources.ExportSettings;
            ToolStripMenu_ExportSettings.Name = "ToolStripMenu_ExportSettings";
            ToolStripMenu_ExportSettings.Size = new Size(186, 22);
            ToolStripMenu_ExportSettings.Text = "Export Settings";
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
            // openManualFormToolStripMenuItem
            // 
            openManualFormToolStripMenuItem.Name = "openManualFormToolStripMenuItem";
            openManualFormToolStripMenuItem.Size = new Size(116, 20);
            openManualFormToolStripMenuItem.Tag = "OpenManualForm";
            openManualFormToolStripMenuItem.Text = "OpenManualForm";
            openManualFormToolStripMenuItem.Click += ButtonHandler;
            // 
            // openSequencerToolStripMenuItem
            // 
            openSequencerToolStripMenuItem.Enabled = false;
            openSequencerToolStripMenuItem.Name = "openSequencerToolStripMenuItem";
            openSequencerToolStripMenuItem.ShowShortcutKeys = false;
            openSequencerToolStripMenuItem.Size = new Size(103, 20);
            openSequencerToolStripMenuItem.Tag = "OpenSequencer";
            openSequencerToolStripMenuItem.Text = "OpenSequencer";
            openSequencerToolStripMenuItem.Click += ButtonHandler;
            // 
            // OperationsBox_UI
            // 
            OperationsBox_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            OperationsBox_UI.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            OperationsBox_UI.Controls.Add(flowLayoutPanel3);
            OperationsBox_UI.Controls.Add(tabControl1);
            OperationsBox_UI.Controls.Add(ControlPanel);
            OperationsBox_UI.Location = new Point(475, 231);
            OperationsBox_UI.Name = "OperationsBox_UI";
            OperationsBox_UI.Size = new Size(420, 471);
            OperationsBox_UI.TabIndex = 18;
            OperationsBox_UI.TabStop = false;
            OperationsBox_UI.Text = "Operations";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(ComboBox_SettingConfigSelect);
            flowLayoutPanel3.Controls.Add(button3);
            flowLayoutPanel3.Location = new Point(6, 313);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(405, 35);
            flowLayoutPanel3.TabIndex = 35;
            // 
            // ComboBox_SettingConfigSelect
            // 
            ComboBox_SettingConfigSelect.FormattingEnabled = true;
            ComboBox_SettingConfigSelect.Location = new Point(3, 3);
            ComboBox_SettingConfigSelect.Name = "ComboBox_SettingConfigSelect";
            ComboBox_SettingConfigSelect.Size = new Size(318, 29);
            ComboBox_SettingConfigSelect.TabIndex = 34;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(327, 3);
            button3.Name = "button3";
            button3.Size = new Size(75, 29);
            button3.TabIndex = 35;
            button3.Text = "Load config";
            button3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Tab_IdlePage);
            tabControl1.Controls.Add(Tab_ChargePage);
            tabControl1.Controls.Add(Tab_DischargePage);
            tabControl1.ItemSize = new Size(130, 32);
            tabControl1.Location = new Point(6, 29);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.No;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(408, 180);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 33;
            tabControl1.TabStop = false;
            // 
            // Tab_IdlePage
            // 
            Tab_IdlePage.Location = new Point(4, 36);
            Tab_IdlePage.Name = "Tab_IdlePage";
            Tab_IdlePage.Padding = new Padding(3);
            Tab_IdlePage.Size = new Size(400, 140);
            Tab_IdlePage.TabIndex = 0;
            Tab_IdlePage.Text = "Idle";
            Tab_IdlePage.UseVisualStyleBackColor = true;
            // 
            // Tab_ChargePage
            // 
            Tab_ChargePage.Controls.Add(flowLayoutPanel1);
            Tab_ChargePage.Location = new Point(4, 36);
            Tab_ChargePage.Name = "Tab_ChargePage";
            Tab_ChargePage.Padding = new Padding(3);
            Tab_ChargePage.Size = new Size(400, 140);
            Tab_ChargePage.TabIndex = 1;
            Tab_ChargePage.Text = "Charging";
            Tab_ChargePage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(checkBox1);
            flowLayoutPanel1.Controls.Add(Label_TriggerActualTime);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(394, 134);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.RightToLeft = RightToLeft.Yes;
            checkBox1.Size = new Size(137, 25);
            checkBox1.TabIndex = 26;
            checkBox1.TabStop = false;
            checkBox1.Text = "Trigger reached";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Label_TriggerActualTime
            // 
            Label_TriggerActualTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label_TriggerActualTime.AutoSize = true;
            Label_TriggerActualTime.Location = new Point(146, 7);
            Label_TriggerActualTime.Margin = new Padding(3);
            Label_TriggerActualTime.Name = "Label_TriggerActualTime";
            Label_TriggerActualTime.Size = new Size(51, 21);
            Label_TriggerActualTime.TabIndex = 27;
            Label_TriggerActualTime.Text = "Time: ";
            Label_TriggerActualTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Tab_DischargePage
            // 
            Tab_DischargePage.Controls.Add(flowLayoutPanel2);
            Tab_DischargePage.Location = new Point(4, 36);
            Tab_DischargePage.Name = "Tab_DischargePage";
            Tab_DischargePage.Padding = new Padding(3);
            Tab_DischargePage.Size = new Size(400, 140);
            Tab_DischargePage.TabIndex = 2;
            Tab_DischargePage.Text = "Discharging";
            Tab_DischargePage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(Label_AccumulatedCharge);
            flowLayoutPanel2.Controls.Add(Label_KnownSOC);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(394, 134);
            flowLayoutPanel2.TabIndex = 34;
            // 
            // Label_AccumulatedCharge
            // 
            Label_AccumulatedCharge.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label_AccumulatedCharge.AutoSize = true;
            Label_AccumulatedCharge.Location = new Point(3, 0);
            Label_AccumulatedCharge.Name = "Label_AccumulatedCharge";
            Label_AccumulatedCharge.Size = new Size(172, 21);
            Label_AccumulatedCharge.TabIndex = 28;
            Label_AccumulatedCharge.Text = "accumulatedCharge: ?A";
            Label_AccumulatedCharge.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_KnownSOC
            // 
            Label_KnownSOC.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Label_KnownSOC.AutoSize = true;
            Label_KnownSOC.Location = new Point(3, 21);
            Label_KnownSOC.Name = "Label_KnownSOC";
            Label_KnownSOC.Size = new Size(114, 21);
            Label_KnownSOC.TabIndex = 29;
            Label_KnownSOC.Text = "Known Soc: ?%";
            Label_KnownSOC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ControlPanel
            // 
            ControlPanel.Controls.Add(button2);
            ControlPanel.Controls.Add(button1);
            ControlPanel.Controls.Add(Operation_Start);
            ControlPanel.Dock = DockStyle.Bottom;
            ControlPanel.Location = new Point(3, 354);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(414, 114);
            ControlPanel.TabIndex = 20;
            ControlPanel.TabStop = false;
            ControlPanel.Text = "Controls";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(288, 48);
            button2.Name = "button2";
            button2.Size = new Size(139, 60);
            button2.TabIndex = 29;
            button2.Tag = "Stop";
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonHandler;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(148, 48);
            button1.Name = "button1";
            button1.Size = new Size(134, 60);
            button1.TabIndex = 28;
            button1.Tag = "Start";
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonHandler;
            // 
            // Operation_Start
            // 
            Operation_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Operation_Start.Location = new Point(3, 48);
            Operation_Start.Name = "Operation_Start";
            Operation_Start.Size = new Size(139, 60);
            Operation_Start.TabIndex = 27;
            Operation_Start.Tag = "Start";
            Operation_Start.Text = "Start";
            Operation_Start.UseVisualStyleBackColor = true;
            Operation_Start.Click += ButtonHandler;
            // 
            // ConsoleBox
            // 
            ConsoleBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConsoleBox.Controls.Add(toolStrip1);
            ConsoleBox.Controls.Add(Console_Simple_Textbox_UI);
            ConsoleBox.Dock = DockStyle.Bottom;
            ConsoleBox.Location = new Point(0, 664);
            ConsoleBox.MaximumSize = new Size(450, 267);
            ConsoleBox.MinimumSize = new Size(300, 50);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.Size = new Size(450, 50);
            ConsoleBox.TabIndex = 23;
            ConsoleBox.TabStop = false;
            ConsoleBox.Text = "Console";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Items.AddRange(new ToolStripItem[] { ToggleConsole_Btn, ConsoleClear_Btn, Console_DownloadBtn, toolStripSeparator4, Console_Short_ErrorLabel });
            toolStrip1.Location = new Point(3, 22);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(444, 25);
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
            Console_Simple_Textbox_UI.Size = new Size(444, 22);
            Console_Simple_Textbox_UI.TabIndex = 5;
            Console_Simple_Textbox_UI.TabStop = false;
            Console_Simple_Textbox_UI.Text = "";
            // 
            // Textbox_Capacity
            // 
            Textbox_Capacity.Location = new Point(210, 117);
            Textbox_Capacity.Name = "Textbox_Capacity";
            Textbox_Capacity.PlaceholderText = "Amps / Hour";
            Textbox_Capacity.Size = new Size(123, 29);
            Textbox_Capacity.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 120);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 8;
            label2.Text = "Rated capacity";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 154);
            label6.Name = "label6";
            label6.Size = new Size(144, 21);
            label6.TabIndex = 9;
            label6.Text = "Max charge current";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 50);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 6;
            label1.Text = "Rated Voltage";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_BulkVoltage
            // 
            Textbox_BulkVoltage.Location = new Point(210, 47);
            Textbox_BulkVoltage.Name = "Textbox_BulkVoltage";
            Textbox_BulkVoltage.PlaceholderText = "Voltage";
            Textbox_BulkVoltage.Size = new Size(123, 29);
            Textbox_BulkVoltage.TabIndex = 3;
            // 
            // Textbox_MaxCurrent
            // 
            Textbox_MaxCurrent.Location = new Point(210, 152);
            Textbox_MaxCurrent.Name = "Textbox_MaxCurrent";
            Textbox_MaxCurrent.PlaceholderText = "Max Current";
            Textbox_MaxCurrent.Size = new Size(123, 29);
            Textbox_MaxCurrent.TabIndex = 6;
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ApplyBatteryDataButton.Location = new Point(6, 339);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(421, 36);
            ApplyBatteryDataButton.TabIndex = 11;
            ApplyBatteryDataButton.Tag = "setData";
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            ApplyBatteryDataButton.Click += ButtonHandler;
            // 
            // Textbox_TriggerPercent
            // 
            Textbox_TriggerPercent.Location = new Point(210, 257);
            Textbox_TriggerPercent.Name = "Textbox_TriggerPercent";
            Textbox_TriggerPercent.PlaceholderText = "Trigger";
            Textbox_TriggerPercent.Size = new Size(123, 29);
            Textbox_TriggerPercent.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 260);
            label5.Name = "label5";
            label5.Size = new Size(149, 21);
            label5.TabIndex = 14;
            label5.Text = "Trigger Threshold %";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 294);
            label4.Name = "label4";
            label4.Size = new Size(170, 21);
            label4.TabIndex = 15;
            label4.Text = "Trigger Threshold Time";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 85);
            label3.Name = "label3";
            label3.Size = new Size(134, 21);
            label3.TabIndex = 13;
            label3.Text = "Minimum Voltage";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_CutoffVoltage
            // 
            Textbox_CutoffVoltage.Location = new Point(210, 82);
            Textbox_CutoffVoltage.Name = "Textbox_CutoffVoltage";
            Textbox_CutoffVoltage.PlaceholderText = "lowest Voltage";
            Textbox_CutoffVoltage.Size = new Size(123, 29);
            Textbox_CutoffVoltage.TabIndex = 4;
            // 
            // Textbox_TriggerTime
            // 
            Textbox_TriggerTime.Location = new Point(210, 292);
            Textbox_TriggerTime.Name = "Textbox_TriggerTime";
            Textbox_TriggerTime.PlaceholderText = "Trigger";
            Textbox_TriggerTime.Size = new Size(123, 29);
            Textbox_TriggerTime.TabIndex = 10;
            // 
            // Textbox_ExpectedSoc
            // 
            Textbox_ExpectedSoc.Location = new Point(210, 222);
            Textbox_ExpectedSoc.Name = "Textbox_ExpectedSoc";
            Textbox_ExpectedSoc.PlaceholderText = "State of Charge";
            Textbox_ExpectedSoc.Size = new Size(123, 29);
            Textbox_ExpectedSoc.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 225);
            label7.Name = "label7";
            label7.Size = new Size(115, 21);
            label7.TabIndex = 17;
            label7.Text = "Wanted SOC %";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Cap
            // 
            Label_Cap.AutoSize = true;
            Label_Cap.Location = new Point(339, 120);
            Label_Cap.Name = "Label_Cap";
            Label_Cap.Size = new Size(110, 21);
            Label_Cap.TabIndex = 19;
            Label_Cap.Text = "Rated capacity";
            Label_Cap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MaxCurr
            // 
            Label_MaxCurr.AutoSize = true;
            Label_MaxCurr.Location = new Point(339, 154);
            Label_MaxCurr.Name = "Label_MaxCurr";
            Label_MaxCurr.Size = new Size(175, 21);
            Label_MaxCurr.TabIndex = 20;
            Label_MaxCurr.Text = "Plus current or C Rating";
            Label_MaxCurr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Volt
            // 
            Label_Volt.AutoSize = true;
            Label_Volt.Location = new Point(339, 50);
            Label_Volt.Name = "Label_Volt";
            Label_Volt.Size = new Size(106, 21);
            Label_Volt.TabIndex = 18;
            Label_Volt.Text = "Rated Voltage";
            Label_Volt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_trigger
            // 
            Label_trigger.AutoSize = true;
            Label_trigger.Location = new Point(339, 260);
            Label_trigger.Name = "Label_trigger";
            Label_trigger.Size = new Size(76, 21);
            Label_trigger.TabIndex = 22;
            Label_trigger.Text = "Trigger %";
            Label_trigger.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_TriggerTime
            // 
            Label_TriggerTime.AutoSize = true;
            Label_TriggerTime.Location = new Point(339, 294);
            Label_TriggerTime.Name = "Label_TriggerTime";
            Label_TriggerTime.Size = new Size(97, 21);
            Label_TriggerTime.TabIndex = 23;
            Label_TriggerTime.Text = "Trigger Time";
            Label_TriggerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_CutVolt
            // 
            Label_CutVolt.AutoSize = true;
            Label_CutVolt.Location = new Point(339, 85);
            Label_CutVolt.Name = "Label_CutVolt";
            Label_CutVolt.Size = new Size(109, 21);
            Label_CutVolt.TabIndex = 21;
            Label_CutVolt.Text = "Cutoff Voltage";
            Label_CutVolt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Soc
            // 
            Label_Soc.AutoSize = true;
            Label_Soc.Location = new Point(339, 225);
            Label_Soc.Name = "Label_Soc";
            Label_Soc.Size = new Size(115, 21);
            Label_Soc.TabIndex = 24;
            Label_Soc.Text = "Wanted SOC %";
            Label_Soc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FactoryInformationBox
            // 
            FactoryInformationBox.Controls.Add(Label_MinCurr);
            FactoryInformationBox.Controls.Add(Textbox_MinCurrent);
            FactoryInformationBox.Controls.Add(label9);
            FactoryInformationBox.Controls.Add(Label_Soc);
            FactoryInformationBox.Controls.Add(Label_CutVolt);
            FactoryInformationBox.Controls.Add(Label_TriggerTime);
            FactoryInformationBox.Controls.Add(Label_trigger);
            FactoryInformationBox.Controls.Add(Label_Volt);
            FactoryInformationBox.Controls.Add(Label_MaxCurr);
            FactoryInformationBox.Controls.Add(Label_Cap);
            FactoryInformationBox.Controls.Add(label7);
            FactoryInformationBox.Controls.Add(Textbox_ExpectedSoc);
            FactoryInformationBox.Controls.Add(Textbox_TriggerTime);
            FactoryInformationBox.Controls.Add(Textbox_CutoffVoltage);
            FactoryInformationBox.Controls.Add(label3);
            FactoryInformationBox.Controls.Add(label4);
            FactoryInformationBox.Controls.Add(label5);
            FactoryInformationBox.Controls.Add(Textbox_TriggerPercent);
            FactoryInformationBox.Controls.Add(ApplyBatteryDataButton);
            FactoryInformationBox.Controls.Add(Textbox_MaxCurrent);
            FactoryInformationBox.Controls.Add(Textbox_BulkVoltage);
            FactoryInformationBox.Controls.Add(label1);
            FactoryInformationBox.Controls.Add(label6);
            FactoryInformationBox.Controls.Add(label2);
            FactoryInformationBox.Controls.Add(Textbox_Capacity);
            FactoryInformationBox.Location = new Point(12, 231);
            FactoryInformationBox.Name = "FactoryInformationBox";
            FactoryInformationBox.Size = new Size(433, 381);
            FactoryInformationBox.TabIndex = 18;
            FactoryInformationBox.TabStop = false;
            FactoryInformationBox.Text = "Factory Information";
            // 
            // Label_MinCurr
            // 
            Label_MinCurr.AutoSize = true;
            Label_MinCurr.Location = new Point(339, 189);
            Label_MinCurr.Name = "Label_MinCurr";
            Label_MinCurr.Size = new Size(173, 21);
            Label_MinCurr.TabIndex = 27;
            Label_MinCurr.Text = "Min current or C Rating";
            Label_MinCurr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_MinCurrent
            // 
            Textbox_MinCurrent.Location = new Point(210, 187);
            Textbox_MinCurrent.Name = "Textbox_MinCurrent";
            Textbox_MinCurrent.PlaceholderText = "Max Current";
            Textbox_MinCurrent.Size = new Size(123, 29);
            Textbox_MinCurrent.TabIndex = 7;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 189);
            label9.Name = "label9";
            label9.Size = new Size(164, 21);
            label9.TabIndex = 26;
            label9.Text = "Max discharge current";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Timer_Update
            // 
            Timer_Update.Enabled = true;
            Timer_Update.Tick += StandardUpdate;
            // 
            // Timer_LateUpdate
            // 
            Timer_LateUpdate.Enabled = true;
            Timer_LateUpdate.Interval = 1000;
            Timer_LateUpdate.Tick += LateUpdate;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 714);
            Controls.Add(ConsoleBox);
            Controls.Add(OperationsBox_UI);
            Controls.Add(LiveInfoData);
            Controls.Add(menuStrip1);
            Controls.Add(FactoryInformationBox);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Whisper Power - Sm15k Controller";
            FormClosing += MainForm_FormClosing;
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
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            OperationsBox_UI.ResumeLayout(false);
            OperationsBox_UI.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            Tab_ChargePage.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            Tab_DischargePage.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ControlPanel.ResumeLayout(false);
            ConsoleBox.ResumeLayout(false);
            ConsoleBox.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            FactoryInformationBox.ResumeLayout(false);
            FactoryInformationBox.PerformLayout();
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
        private Button Button_ValueEditor;
        private TableLayoutPanel tableLayoutPanel9;
        private Label Label_MachineAppliedVoltage_UI;
        private Label Label_Remote_CV_UI;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
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
        private ToolStripMenuItem ToolStripMenu_ExportSettings;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem RuntimeCSV_ToolstripItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem errorLogToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuSetting_keepSessionData;
        private GroupBox OperationsBox_UI;
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
        private GroupBox ControlPanel;
        private Button Operation_Start;
        private GroupBox ConsoleBox;
        private ToolStrip toolStrip1;
        private ToolStripButton ToggleConsole_Btn;
        private ToolStripButton ConsoleClear_Btn;
        private ToolStripButton Console_DownloadBtn;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripLabel Console_Short_ErrorLabel;
        private RichTextBox Console_Simple_Textbox_UI;
        private ToolStripMenuItem openManualFormToolStripMenuItem;
        private ToolStripMenuItem openSequencerToolStripMenuItem;
        private Button button2;
        private Button button1;
        private TextBox InputField_StoredValueVoltage;
        private CheckBox checkBox1;
        private Label Label_TriggerActualTime;
        private Label Label_AccumulatedCharge;
        private Label Label_KnownSOC;
        private TextBox Textbox_Capacity;
        private Label label2;
        private Label label6;
        private Label label1;
        private TextBox Textbox_BulkVoltage;
        private TextBox Textbox_MaxCurrent;
        private Button ApplyBatteryDataButton;
        private TextBox Textbox_TriggerPercent;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox Textbox_CutoffVoltage;
        private TextBox Textbox_TriggerTime;
        private TextBox Textbox_ExpectedSoc;
        private Label label7;
        private Label Label_Cap;
        private Label Label_MaxCurr;
        private Label Label_Volt;
        private Label Label_trigger;
        private Label Label_TriggerTime;
        private Label Label_CutVolt;
        private Label Label_Soc;
        private GroupBox FactoryInformationBox;
        private Label Label_MinCurr;
        private TextBox Textbox_MinCurrent;
        private Label label9;
        private TabControl tabControl1;
        private TabPage Tab_IdlePage;
        private TabPage Tab_ChargePage;
        private TabPage Tab_DischargePage;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.Timer Timer_LateUpdate;
        private ComboBox ComboBox_SettingConfigSelect;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button3;
    }
}