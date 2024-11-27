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
            Timer_Update = new System.Windows.Forms.Timer(components);
            Timer_LateUpdate = new System.Windows.Forms.Timer(components);
            flowLayoutPanel3 = new FlowLayoutPanel();
            ConsoleBox = new GroupBox();
            toolStrip1 = new ToolStrip();
            ToggleConsole_Btn = new ToolStripButton();
            ConsoleClear_Btn = new ToolStripButton();
            Console_DownloadBtn = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            Console_Short_ErrorLabel = new ToolStripLabel();
            Console_Simple_Textbox_UI = new RichTextBox();
            ControlPanel = new GroupBox();
            button2 = new Button();
            button1 = new Button();
            Operation_Start = new Button();
            LiveInfoData = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            Label_MachineAppliedVoltage_UI = new Label();
            Label_Remote_CV_UI = new Label();
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
            FactoryInformationBox = new GroupBox();
            ApplyBatteryDataButton = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            Textbox_TriggerPercent = new TextBox();
            Textbox_TriggerTime = new TextBox();
            Label_trigger = new Label();
            Label_TriggerTime = new Label();
            groupBox2 = new GroupBox();
            Textbox_MaxCurrent = new TextBox();
            Label_MaxCurr = new Label();
            Label_Volt = new Label();
            Textbox_Capacity = new TextBox();
            Textbox_BulkVoltage = new TextBox();
            Label_Cap = new Label();
            groupBox1 = new GroupBox();
            Textbox_MinCurrent = new TextBox();
            Label_MinCurr = new Label();
            Textbox_CutoffVoltage = new TextBox();
            Label_Soc = new Label();
            Label_CutVolt = new Label();
            Textbox_ExpectedSoc = new TextBox();
            menuStrip1.SuspendLayout();
            ConsoleBox.SuspendLayout();
            toolStrip1.SuspendLayout();
            ControlPanel.SuspendLayout();
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tabControl1.SuspendLayout();
            Tab_ChargePage.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            Tab_DischargePage.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            FactoryInformationBox.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolsToolStripMenuItem, toolStripMenuItem5, openManualFormToolStripMenuItem, openSequencerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(904, 24);
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
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel3.Location = new Point(316, 106);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(0, 0);
            flowLayoutPanel3.TabIndex = 34;
            // 
            // ConsoleBox
            // 
            ConsoleBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConsoleBox.Controls.Add(toolStrip1);
            ConsoleBox.Controls.Add(Console_Simple_Textbox_UI);
            ConsoleBox.Dock = DockStyle.Bottom;
            ConsoleBox.Location = new Point(0, 674);
            ConsoleBox.MaximumSize = new Size(450, 267);
            ConsoleBox.MinimumSize = new Size(300, 50);
            ConsoleBox.Name = "ConsoleBox";
            ConsoleBox.Size = new Size(450, 50);
            ConsoleBox.TabIndex = 36;
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
            // ControlPanel
            // 
            ControlPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ControlPanel.Controls.Add(button2);
            ControlPanel.Controls.Add(button1);
            ControlPanel.Controls.Add(Operation_Start);
            ControlPanel.Location = new Point(460, 621);
            ControlPanel.Name = "ControlPanel";
            ControlPanel.Size = new Size(432, 91);
            ControlPanel.TabIndex = 37;
            ControlPanel.TabStop = false;
            ControlPanel.Text = "Controls";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(291, 25);
            button2.Name = "button2";
            button2.Size = new Size(139, 60);
            button2.TabIndex = 29;
            button2.Tag = "Stop";
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(151, 25);
            button1.Name = "button1";
            button1.Size = new Size(134, 60);
            button1.TabIndex = 28;
            button1.Tag = "Start";
            button1.Text = "Restart";
            button1.UseVisualStyleBackColor = true;
            // 
            // Operation_Start
            // 
            Operation_Start.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Operation_Start.Location = new Point(6, 25);
            Operation_Start.Name = "Operation_Start";
            Operation_Start.Size = new Size(139, 60);
            Operation_Start.TabIndex = 27;
            Operation_Start.Tag = "Start";
            Operation_Start.Text = "Start";
            Operation_Start.UseVisualStyleBackColor = true;
            // 
            // LiveInfoData
            // 
            LiveInfoData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LiveInfoData.Controls.Add(tableLayoutPanel2);
            LiveInfoData.Location = new Point(12, 27);
            LiveInfoData.Name = "LiveInfoData";
            LiveInfoData.Size = new Size(880, 150);
            LiveInfoData.TabIndex = 38;
            LiveInfoData.TabStop = false;
            LiveInfoData.Text = "SM70-CP-450 Controller Status:";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 2, 1);
            tableLayoutPanel2.Controls.Add(WattageDisplay, 2, 0);
            tableLayoutPanel2.Controls.Add(VoltageDisplay, 0, 0);
            tableLayoutPanel2.Controls.Add(AmperageDisplay, 1, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 41.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 58.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(874, 122);
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
            tableLayoutPanel9.Location = new Point(3, 53);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(285, 66);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // Label_MachineAppliedVoltage_UI
            // 
            Label_MachineAppliedVoltage_UI.AutoSize = true;
            Label_MachineAppliedVoltage_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedVoltage_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedVoltage_UI.Location = new Point(145, 0);
            Label_MachineAppliedVoltage_UI.Name = "Label_MachineAppliedVoltage_UI";
            Label_MachineAppliedVoltage_UI.Size = new Size(137, 33);
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
            Label_Remote_CV_UI.Size = new Size(136, 33);
            Label_Remote_CV_UI.TabIndex = 12;
            Label_Remote_CV_UI.Text = "Front";
            Label_Remote_CV_UI.TextAlign = ContentAlignment.MiddleCenter;
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
            tableLayoutPanel5.Location = new Point(585, 53);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(286, 66);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // Label_MachineAppliedPowerPlus_UI
            // 
            Label_MachineAppliedPowerPlus_UI.AutoSize = true;
            Label_MachineAppliedPowerPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerPlus_UI.Location = new Point(146, 0);
            Label_MachineAppliedPowerPlus_UI.Name = "Label_MachineAppliedPowerPlus_UI";
            Label_MachineAppliedPowerPlus_UI.Size = new Size(137, 33);
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
            Label_Remote_CP_UI.Size = new Size(137, 33);
            Label_Remote_CP_UI.TabIndex = 10;
            Label_Remote_CP_UI.Text = "Front";
            Label_Remote_CP_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedPowerMin_UI
            // 
            Label_MachineAppliedPowerMin_UI.AutoSize = true;
            Label_MachineAppliedPowerMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerMin_UI.Location = new Point(146, 33);
            Label_MachineAppliedPowerMin_UI.Name = "Label_MachineAppliedPowerMin_UI";
            Label_MachineAppliedPowerMin_UI.Size = new Size(137, 33);
            Label_MachineAppliedPowerMin_UI.TabIndex = 9;
            Label_MachineAppliedPowerMin_UI.Text = "-0 W";
            Label_MachineAppliedPowerMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WattageDisplay
            // 
            WattageDisplay.AutoSize = true;
            WattageDisplay.Dock = DockStyle.Fill;
            WattageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            WattageDisplay.Location = new Point(586, 0);
            WattageDisplay.Margin = new Padding(4, 0, 4, 0);
            WattageDisplay.Name = "WattageDisplay";
            WattageDisplay.Size = new Size(284, 50);
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
            VoltageDisplay.Size = new Size(283, 50);
            VoltageDisplay.TabIndex = 0;
            VoltageDisplay.Text = "0.0 V";
            VoltageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AmperageDisplay
            // 
            AmperageDisplay.AutoSize = true;
            AmperageDisplay.Dock = DockStyle.Fill;
            AmperageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            AmperageDisplay.Location = new Point(295, 0);
            AmperageDisplay.Margin = new Padding(4, 0, 4, 0);
            AmperageDisplay.Name = "AmperageDisplay";
            AmperageDisplay.Size = new Size(283, 50);
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
            tableLayoutPanel3.Location = new Point(294, 53);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(285, 66);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // Label_MachineAppliedCurrentPlus_UI
            // 
            Label_MachineAppliedCurrentPlus_UI.AutoSize = true;
            Label_MachineAppliedCurrentPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentPlus_UI.Location = new Point(145, 0);
            Label_MachineAppliedCurrentPlus_UI.Name = "Label_MachineAppliedCurrentPlus_UI";
            Label_MachineAppliedCurrentPlus_UI.Size = new Size(137, 33);
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
            Label_Remote_CC_UI.Size = new Size(136, 33);
            Label_Remote_CC_UI.TabIndex = 9;
            Label_Remote_CC_UI.Text = "Front";
            Label_Remote_CC_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedCurrentMin_UI
            // 
            Label_MachineAppliedCurrentMin_UI.AutoSize = true;
            Label_MachineAppliedCurrentMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentMin_UI.Location = new Point(145, 33);
            Label_MachineAppliedCurrentMin_UI.Name = "Label_MachineAppliedCurrentMin_UI";
            Label_MachineAppliedCurrentMin_UI.Size = new Size(137, 33);
            Label_MachineAppliedCurrentMin_UI.TabIndex = 8;
            Label_MachineAppliedCurrentMin_UI.Text = "-0 A";
            Label_MachineAppliedCurrentMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Tab_IdlePage);
            tabControl1.Controls.Add(Tab_ChargePage);
            tabControl1.Controls.Add(Tab_DischargePage);
            tabControl1.ItemSize = new Size(290, 26);
            tabControl1.Location = new Point(12, 443);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.RightToLeft = RightToLeft.No;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(880, 100);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 40;
            tabControl1.TabStop = false;
            // 
            // Tab_IdlePage
            // 
            Tab_IdlePage.Location = new Point(4, 30);
            Tab_IdlePage.Name = "Tab_IdlePage";
            Tab_IdlePage.Padding = new Padding(3);
            Tab_IdlePage.Size = new Size(872, 66);
            Tab_IdlePage.TabIndex = 0;
            Tab_IdlePage.Text = "Idle";
            Tab_IdlePage.UseVisualStyleBackColor = true;
            // 
            // Tab_ChargePage
            // 
            Tab_ChargePage.Controls.Add(flowLayoutPanel1);
            Tab_ChargePage.Location = new Point(4, 30);
            Tab_ChargePage.Name = "Tab_ChargePage";
            Tab_ChargePage.Padding = new Padding(3);
            Tab_ChargePage.Size = new Size(872, 66);
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
            flowLayoutPanel1.Size = new Size(866, 60);
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
            Tab_DischargePage.Location = new Point(4, 30);
            Tab_DischargePage.Name = "Tab_DischargePage";
            Tab_DischargePage.Padding = new Padding(3);
            Tab_DischargePage.Size = new Size(872, 66);
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
            flowLayoutPanel2.Size = new Size(866, 60);
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
            // FactoryInformationBox
            // 
            FactoryInformationBox.Controls.Add(ApplyBatteryDataButton);
            FactoryInformationBox.Controls.Add(flowLayoutPanel4);
            FactoryInformationBox.Location = new Point(12, 183);
            FactoryInformationBox.Name = "FactoryInformationBox";
            FactoryInformationBox.Size = new Size(880, 254);
            FactoryInformationBox.TabIndex = 41;
            FactoryInformationBox.TabStop = false;
            FactoryInformationBox.Text = "Settings";
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Dock = DockStyle.Bottom;
            ApplyBatteryDataButton.Location = new Point(3, 196);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(874, 55);
            ApplyBatteryDataButton.TabIndex = 32;
            ApplyBatteryDataButton.Tag = "setData";
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(groupBox3);
            flowLayoutPanel4.Controls.Add(groupBox2);
            flowLayoutPanel4.Controls.Add(groupBox1);
            flowLayoutPanel4.Dock = DockStyle.Top;
            flowLayoutPanel4.Location = new Point(3, 25);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(874, 165);
            flowLayoutPanel4.TabIndex = 31;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(Textbox_TriggerPercent);
            groupBox3.Controls.Add(Textbox_TriggerTime);
            groupBox3.Controls.Add(Label_trigger);
            groupBox3.Controls.Add(Label_TriggerTime);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(178, 145);
            groupBox3.TabIndex = 30;
            groupBox3.TabStop = false;
            groupBox3.Text = "General Settings";
            // 
            // Textbox_TriggerPercent
            // 
            Textbox_TriggerPercent.Location = new Point(6, 49);
            Textbox_TriggerPercent.Name = "Textbox_TriggerPercent";
            Textbox_TriggerPercent.PlaceholderText = "Trigger";
            Textbox_TriggerPercent.Size = new Size(123, 29);
            Textbox_TriggerPercent.TabIndex = 9;
            // 
            // Textbox_TriggerTime
            // 
            Textbox_TriggerTime.Location = new Point(6, 105);
            Textbox_TriggerTime.Name = "Textbox_TriggerTime";
            Textbox_TriggerTime.PlaceholderText = "Trigger";
            Textbox_TriggerTime.Size = new Size(123, 29);
            Textbox_TriggerTime.TabIndex = 10;
            // 
            // Label_trigger
            // 
            Label_trigger.AutoSize = true;
            Label_trigger.Location = new Point(6, 25);
            Label_trigger.Name = "Label_trigger";
            Label_trigger.Size = new Size(149, 21);
            Label_trigger.TabIndex = 22;
            Label_trigger.Text = "Trigger Threshold %";
            Label_trigger.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_TriggerTime
            // 
            Label_TriggerTime.AutoSize = true;
            Label_TriggerTime.Location = new Point(3, 81);
            Label_TriggerTime.Name = "Label_TriggerTime";
            Label_TriggerTime.Size = new Size(170, 21);
            Label_TriggerTime.TabIndex = 23;
            Label_TriggerTime.Text = "Trigger Threshold Time";
            Label_TriggerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Textbox_MaxCurrent);
            groupBox2.Controls.Add(Label_MaxCurr);
            groupBox2.Controls.Add(Label_Volt);
            groupBox2.Controls.Add(Textbox_Capacity);
            groupBox2.Controls.Add(Textbox_BulkVoltage);
            groupBox2.Controls.Add(Label_Cap);
            groupBox2.Location = new Point(187, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(355, 147);
            groupBox2.TabIndex = 29;
            groupBox2.TabStop = false;
            groupBox2.Text = "Charge settings";
            // 
            // Textbox_MaxCurrent
            // 
            Textbox_MaxCurrent.Location = new Point(6, 98);
            Textbox_MaxCurrent.Name = "Textbox_MaxCurrent";
            Textbox_MaxCurrent.PlaceholderText = "Max Current";
            Textbox_MaxCurrent.Size = new Size(123, 29);
            Textbox_MaxCurrent.TabIndex = 6;
            // 
            // Label_MaxCurr
            // 
            Label_MaxCurr.AutoSize = true;
            Label_MaxCurr.Location = new Point(135, 100);
            Label_MaxCurr.Name = "Label_MaxCurr";
            Label_MaxCurr.Size = new Size(144, 21);
            Label_MaxCurr.TabIndex = 20;
            Label_MaxCurr.Text = "Max charge current";
            Label_MaxCurr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_Volt
            // 
            Label_Volt.AutoSize = true;
            Label_Volt.Location = new Point(135, 31);
            Label_Volt.Name = "Label_Volt";
            Label_Volt.Size = new Size(106, 21);
            Label_Volt.TabIndex = 18;
            Label_Volt.Text = "Rated Voltage";
            Label_Volt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_Capacity
            // 
            Textbox_Capacity.Location = new Point(6, 63);
            Textbox_Capacity.Name = "Textbox_Capacity";
            Textbox_Capacity.PlaceholderText = "Amps / Hour";
            Textbox_Capacity.Size = new Size(123, 29);
            Textbox_Capacity.TabIndex = 5;
            // 
            // Textbox_BulkVoltage
            // 
            Textbox_BulkVoltage.Location = new Point(6, 28);
            Textbox_BulkVoltage.Name = "Textbox_BulkVoltage";
            Textbox_BulkVoltage.PlaceholderText = "Voltage";
            Textbox_BulkVoltage.Size = new Size(123, 29);
            Textbox_BulkVoltage.TabIndex = 3;
            // 
            // Label_Cap
            // 
            Label_Cap.AutoSize = true;
            Label_Cap.Location = new Point(135, 66);
            Label_Cap.Name = "Label_Cap";
            Label_Cap.Size = new Size(110, 21);
            Label_Cap.TabIndex = 19;
            Label_Cap.Text = "Rated capacity";
            Label_Cap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Textbox_MinCurrent);
            groupBox1.Controls.Add(Label_MinCurr);
            groupBox1.Controls.Add(Textbox_CutoffVoltage);
            groupBox1.Controls.Add(Label_Soc);
            groupBox1.Controls.Add(Label_CutVolt);
            groupBox1.Controls.Add(Textbox_ExpectedSoc);
            groupBox1.Location = new Point(548, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(320, 147);
            groupBox1.TabIndex = 28;
            groupBox1.TabStop = false;
            groupBox1.Text = "Discharge settings";
            // 
            // Textbox_MinCurrent
            // 
            Textbox_MinCurrent.Location = new Point(6, 63);
            Textbox_MinCurrent.Name = "Textbox_MinCurrent";
            Textbox_MinCurrent.PlaceholderText = "Max Current";
            Textbox_MinCurrent.Size = new Size(123, 29);
            Textbox_MinCurrent.TabIndex = 7;
            // 
            // Label_MinCurr
            // 
            Label_MinCurr.AutoSize = true;
            Label_MinCurr.Location = new Point(135, 65);
            Label_MinCurr.Name = "Label_MinCurr";
            Label_MinCurr.Size = new Size(164, 21);
            Label_MinCurr.TabIndex = 27;
            Label_MinCurr.Text = "Max discharge current";
            Label_MinCurr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_CutoffVoltage
            // 
            Textbox_CutoffVoltage.Location = new Point(6, 28);
            Textbox_CutoffVoltage.Name = "Textbox_CutoffVoltage";
            Textbox_CutoffVoltage.PlaceholderText = "lowest Voltage";
            Textbox_CutoffVoltage.Size = new Size(123, 29);
            Textbox_CutoffVoltage.TabIndex = 4;
            // 
            // Label_Soc
            // 
            Label_Soc.AutoSize = true;
            Label_Soc.Location = new Point(135, 101);
            Label_Soc.Name = "Label_Soc";
            Label_Soc.Size = new Size(115, 21);
            Label_Soc.TabIndex = 24;
            Label_Soc.Text = "Wanted SOC %";
            Label_Soc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_CutVolt
            // 
            Label_CutVolt.AutoSize = true;
            Label_CutVolt.Location = new Point(135, 31);
            Label_CutVolt.Name = "Label_CutVolt";
            Label_CutVolt.Size = new Size(134, 21);
            Label_CutVolt.TabIndex = 21;
            Label_CutVolt.Text = "Minimum Voltage";
            Label_CutVolt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Textbox_ExpectedSoc
            // 
            Textbox_ExpectedSoc.Location = new Point(6, 98);
            Textbox_ExpectedSoc.Name = "Textbox_ExpectedSoc";
            Textbox_ExpectedSoc.PlaceholderText = "State of Charge";
            Textbox_ExpectedSoc.Size = new Size(123, 29);
            Textbox_ExpectedSoc.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 724);
            Controls.Add(FactoryInformationBox);
            Controls.Add(LiveInfoData);
            Controls.Add(tabControl1);
            Controls.Add(ControlPanel);
            Controls.Add(ConsoleBox);
            Controls.Add(flowLayoutPanel3);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Whisper Power - Sm15k Controller";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ConsoleBox.ResumeLayout(false);
            ConsoleBox.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ControlPanel.ResumeLayout(false);
            LiveInfoData.ResumeLayout(false);
            LiveInfoData.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            Tab_ChargePage.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            Tab_DischargePage.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            FactoryInformationBox.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        private ToolStripMenuItem openManualFormToolStripMenuItem;
        private ToolStripMenuItem openSequencerToolStripMenuItem;
        private System.Windows.Forms.Timer Timer_Update;
        private System.Windows.Forms.Timer Timer_LateUpdate;
        private FlowLayoutPanel flowLayoutPanel3;
        private GroupBox ConsoleBox;
        private ToolStrip toolStrip1;
        private ToolStripButton ToggleConsole_Btn;
        private ToolStripButton ConsoleClear_Btn;
        private ToolStripButton Console_DownloadBtn;
        private ToolStripSeparator toolStripSeparator4;
        public ToolStripLabel Console_Short_ErrorLabel;
        private RichTextBox Console_Simple_Textbox_UI;
        private GroupBox ControlPanel;
        private Button button2;
        private Button button1;
        private Button Operation_Start;
        private GroupBox LiveInfoData;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel9;
        private Label Label_MachineAppliedVoltage_UI;
        private Label Label_Remote_CV_UI;
        private TableLayoutPanel tableLayoutPanel5;
        private Label Label_MachineAppliedPowerPlus_UI;
        private Label Label_Remote_CP_UI;
        private Label Label_MachineAppliedPowerMin_UI;
        private Label WattageDisplay;
        private Label VoltageDisplay;
        private Label AmperageDisplay;
        private TableLayoutPanel tableLayoutPanel3;
        private Label Label_MachineAppliedCurrentPlus_UI;
        private Label Label_Remote_CC_UI;
        private Label Label_MachineAppliedCurrentMin_UI;
        private TabControl tabControl1;
        private TabPage Tab_IdlePage;
        private TabPage Tab_ChargePage;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox checkBox1;
        private Label Label_TriggerActualTime;
        private TabPage Tab_DischargePage;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label Label_AccumulatedCharge;
        private Label Label_KnownSOC;
        private GroupBox FactoryInformationBox;
        private Button ApplyBatteryDataButton;
        private FlowLayoutPanel flowLayoutPanel4;
        private GroupBox groupBox3;
        private TextBox Textbox_TriggerPercent;
        private TextBox Textbox_TriggerTime;
        private Label Label_trigger;
        private Label Label_TriggerTime;
        private GroupBox groupBox1;
        private TextBox Textbox_MinCurrent;
        private Label Label_MinCurr;
        private TextBox Textbox_CutoffVoltage;
        private Label Label_Soc;
        private Label Label_CutVolt;
        private TextBox Textbox_ExpectedSoc;
        private GroupBox groupBox2;
        private TextBox Textbox_MaxCurrent;
        private Label Label_MaxCurr;
        private Label Label_Volt;
        private TextBox Textbox_Capacity;
        private TextBox Textbox_BulkVoltage;
        private Label Label_Cap;
    }
}