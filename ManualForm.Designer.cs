namespace sm70_cp_450_GUI
{
    partial class ManualForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Output_Btn2 = new Button();
            Output_Btn1 = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel9 = new TableLayoutPanel();
            CV_ComboBox = new ComboBox();
            Label_MachineAppliedVoltage_UI = new Label();
            Label_Remote_CV_UI = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            InputField_StoredValueVoltage = new TextBox();
            SetValues_btn = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            InputField_StoredValuePowerMin = new TextBox();
            InputField_StoredValuePowerPlus = new TextBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            CP_ComboBox = new ComboBox();
            Label_MachineAppliedPowerPlus_UI = new Label();
            Label_Remote_CP_UI = new Label();
            Label_MachineAppliedPowerMin_UI = new Label();
            WattageDisplay = new Label();
            VoltageDisplay = new Label();
            AmperageDisplay = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            CC_ComboBox = new ComboBox();
            Label_MachineAppliedCurrentPlus_UI = new Label();
            Label_Remote_CC_UI = new Label();
            Label_MachineAppliedCurrentMin_UI = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            InputField_StoredValueCurrentMin = new TextBox();
            InputField_StoredValueCurrentPlus = new TextBox();
            LiveInfoData = new GroupBox();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            LiveInfoData.SuspendLayout();
            SuspendLayout();
            // 
            // Output_Btn2
            // 
            Output_Btn2.Location = new Point(724, 447);
            Output_Btn2.Name = "Output_Btn2";
            Output_Btn2.Size = new Size(129, 68);
            Output_Btn2.TabIndex = 8;
            Output_Btn2.Tag = "Output OFF";
            Output_Btn2.Text = "Output Off";
            Output_Btn2.UseVisualStyleBackColor = true;
            Output_Btn2.Click += ButtonHandler;
            // 
            // Output_Btn1
            // 
            Output_Btn1.Location = new Point(589, 447);
            Output_Btn1.Name = "Output_Btn1";
            Output_Btn1.Size = new Size(129, 68);
            Output_Btn1.TabIndex = 7;
            Output_Btn1.Tag = "Output ON";
            Output_Btn1.Text = "Output On";
            Output_Btn1.UseVisualStyleBackColor = true;
            Output_Btn1.Click += ButtonHandler;
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
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Size = new Size(835, 184);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.AutoSize = true;
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Controls.Add(CV_ComboBox, 0, 1);
            tableLayoutPanel9.Controls.Add(Label_MachineAppliedVoltage_UI, 1, 0);
            tableLayoutPanel9.Controls.Add(Label_Remote_CV_UI, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(3, 49);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 2;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.Size = new Size(272, 58);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // CV_ComboBox
            // 
            CV_ComboBox.Dock = DockStyle.Fill;
            CV_ComboBox.FormattingEnabled = true;
            CV_ComboBox.Items.AddRange(new object[] { "Front", "Web", "Sequencer", "Ethernet" });
            CV_ComboBox.Location = new Point(3, 32);
            CV_ComboBox.Name = "CV_ComboBox";
            CV_ComboBox.Size = new Size(130, 23);
            CV_ComboBox.TabIndex = 15;
            CV_ComboBox.Tag = "CV_ComboBox";
            CV_ComboBox.SelectedIndexChanged += ComboBoxHandler;
            // 
            // Label_MachineAppliedVoltage_UI
            // 
            Label_MachineAppliedVoltage_UI.AutoSize = true;
            Label_MachineAppliedVoltage_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedVoltage_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedVoltage_UI.Location = new Point(139, 0);
            Label_MachineAppliedVoltage_UI.Name = "Label_MachineAppliedVoltage_UI";
            Label_MachineAppliedVoltage_UI.Size = new Size(130, 29);
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
            Label_Remote_CV_UI.Size = new Size(130, 29);
            Label_Remote_CV_UI.TabIndex = 12;
            Label_Remote_CV_UI.Text = "Front";
            Label_Remote_CV_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.Controls.Add(InputField_StoredValueVoltage, 0, 0);
            tableLayoutPanel8.Controls.Add(SetValues_btn, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 113);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(272, 68);
            tableLayoutPanel8.TabIndex = 12;
            // 
            // InputField_StoredValueVoltage
            // 
            InputField_StoredValueVoltage.Dock = DockStyle.Fill;
            InputField_StoredValueVoltage.Location = new Point(3, 3);
            InputField_StoredValueVoltage.Name = "InputField_StoredValueVoltage";
            InputField_StoredValueVoltage.PlaceholderText = "0 A";
            InputField_StoredValueVoltage.Size = new Size(266, 23);
            InputField_StoredValueVoltage.TabIndex = 0;
            InputField_StoredValueVoltage.Tag = "";
            InputField_StoredValueVoltage.TextAlign = HorizontalAlignment.Center;
            // 
            // SetValues_btn
            // 
            SetValues_btn.Dock = DockStyle.Fill;
            SetValues_btn.Location = new Point(3, 37);
            SetValues_btn.Name = "SetValues_btn";
            SetValues_btn.Size = new Size(266, 28);
            SetValues_btn.TabIndex = 1;
            SetValues_btn.Tag = "SetValues_btn";
            SetValues_btn.Text = "Set Values";
            SetValues_btn.UseVisualStyleBackColor = true;
            SetValues_btn.Click += ButtonHandler;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerMin, 0, 1);
            tableLayoutPanel7.Controls.Add(InputField_StoredValuePowerPlus, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(559, 113);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(273, 68);
            tableLayoutPanel7.TabIndex = 11;
            // 
            // InputField_StoredValuePowerMin
            // 
            InputField_StoredValuePowerMin.Dock = DockStyle.Fill;
            InputField_StoredValuePowerMin.Location = new Point(3, 37);
            InputField_StoredValuePowerMin.Name = "InputField_StoredValuePowerMin";
            InputField_StoredValuePowerMin.PlaceholderText = "0 W";
            InputField_StoredValuePowerMin.Size = new Size(267, 23);
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
            InputField_StoredValuePowerPlus.Size = new Size(267, 23);
            InputField_StoredValuePowerPlus.TabIndex = 1;
            InputField_StoredValuePowerPlus.Tag = "";
            InputField_StoredValuePowerPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(CP_ComboBox, 0, 1);
            tableLayoutPanel5.Controls.Add(Label_MachineAppliedPowerPlus_UI, 1, 0);
            tableLayoutPanel5.Controls.Add(Label_Remote_CP_UI, 0, 0);
            tableLayoutPanel5.Controls.Add(Label_MachineAppliedPowerMin_UI, 1, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(559, 49);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(273, 58);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // CP_ComboBox
            // 
            CP_ComboBox.Dock = DockStyle.Fill;
            CP_ComboBox.FormattingEnabled = true;
            CP_ComboBox.Items.AddRange(new object[] { "Front", "Web", "Sequencer", "Ethernet" });
            CP_ComboBox.Location = new Point(3, 32);
            CP_ComboBox.Name = "CP_ComboBox";
            CP_ComboBox.Size = new Size(130, 23);
            CP_ComboBox.TabIndex = 15;
            CP_ComboBox.Tag = "CP_ComboBox";
            CP_ComboBox.SelectedIndexChanged += ComboBoxHandler;
            // 
            // Label_MachineAppliedPowerPlus_UI
            // 
            Label_MachineAppliedPowerPlus_UI.AutoSize = true;
            Label_MachineAppliedPowerPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerPlus_UI.Location = new Point(139, 0);
            Label_MachineAppliedPowerPlus_UI.Name = "Label_MachineAppliedPowerPlus_UI";
            Label_MachineAppliedPowerPlus_UI.Size = new Size(131, 29);
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
            Label_Remote_CP_UI.Size = new Size(130, 29);
            Label_Remote_CP_UI.TabIndex = 10;
            Label_Remote_CP_UI.Text = "Front";
            Label_Remote_CP_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedPowerMin_UI
            // 
            Label_MachineAppliedPowerMin_UI.AutoSize = true;
            Label_MachineAppliedPowerMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedPowerMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedPowerMin_UI.Location = new Point(139, 29);
            Label_MachineAppliedPowerMin_UI.Name = "Label_MachineAppliedPowerMin_UI";
            Label_MachineAppliedPowerMin_UI.Size = new Size(131, 29);
            Label_MachineAppliedPowerMin_UI.TabIndex = 9;
            Label_MachineAppliedPowerMin_UI.Text = "-0 W";
            Label_MachineAppliedPowerMin_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // WattageDisplay
            // 
            WattageDisplay.AutoSize = true;
            WattageDisplay.Dock = DockStyle.Fill;
            WattageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            WattageDisplay.Location = new Point(560, 0);
            WattageDisplay.Margin = new Padding(4, 0, 4, 0);
            WattageDisplay.Name = "WattageDisplay";
            WattageDisplay.Size = new Size(271, 46);
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
            VoltageDisplay.Size = new Size(270, 46);
            VoltageDisplay.TabIndex = 0;
            VoltageDisplay.Text = "0.0 V";
            VoltageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AmperageDisplay
            // 
            AmperageDisplay.AutoSize = true;
            AmperageDisplay.Dock = DockStyle.Fill;
            AmperageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            AmperageDisplay.Location = new Point(282, 0);
            AmperageDisplay.Margin = new Padding(4, 0, 4, 0);
            AmperageDisplay.Name = "AmperageDisplay";
            AmperageDisplay.Size = new Size(270, 46);
            AmperageDisplay.TabIndex = 1;
            AmperageDisplay.Text = "0.0 A";
            AmperageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(CC_ComboBox, 0, 1);
            tableLayoutPanel3.Controls.Add(Label_MachineAppliedCurrentPlus_UI, 1, 0);
            tableLayoutPanel3.Controls.Add(Label_Remote_CC_UI, 0, 0);
            tableLayoutPanel3.Controls.Add(Label_MachineAppliedCurrentMin_UI, 1, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(281, 49);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(272, 58);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // CC_ComboBox
            // 
            CC_ComboBox.Dock = DockStyle.Fill;
            CC_ComboBox.FormattingEnabled = true;
            CC_ComboBox.Items.AddRange(new object[] { "Front", "Web", "Sequencer", "Ethernet" });
            CC_ComboBox.Location = new Point(3, 32);
            CC_ComboBox.Name = "CC_ComboBox";
            CC_ComboBox.Size = new Size(130, 23);
            CC_ComboBox.TabIndex = 15;
            CC_ComboBox.Tag = "CC_ComboBox";
            CC_ComboBox.SelectedIndexChanged += ComboBoxHandler;
            // 
            // Label_MachineAppliedCurrentPlus_UI
            // 
            Label_MachineAppliedCurrentPlus_UI.AutoSize = true;
            Label_MachineAppliedCurrentPlus_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentPlus_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentPlus_UI.Location = new Point(139, 0);
            Label_MachineAppliedCurrentPlus_UI.Name = "Label_MachineAppliedCurrentPlus_UI";
            Label_MachineAppliedCurrentPlus_UI.Size = new Size(130, 29);
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
            Label_Remote_CC_UI.Size = new Size(130, 29);
            Label_Remote_CC_UI.TabIndex = 9;
            Label_Remote_CC_UI.Text = "Front";
            Label_Remote_CC_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Label_MachineAppliedCurrentMin_UI
            // 
            Label_MachineAppliedCurrentMin_UI.AutoSize = true;
            Label_MachineAppliedCurrentMin_UI.Dock = DockStyle.Fill;
            Label_MachineAppliedCurrentMin_UI.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_MachineAppliedCurrentMin_UI.Location = new Point(139, 29);
            Label_MachineAppliedCurrentMin_UI.Name = "Label_MachineAppliedCurrentMin_UI";
            Label_MachineAppliedCurrentMin_UI.Size = new Size(130, 29);
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
            tableLayoutPanel6.Location = new Point(281, 113);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(272, 68);
            tableLayoutPanel6.TabIndex = 10;
            // 
            // InputField_StoredValueCurrentMin
            // 
            InputField_StoredValueCurrentMin.Dock = DockStyle.Fill;
            InputField_StoredValueCurrentMin.Location = new Point(3, 37);
            InputField_StoredValueCurrentMin.Name = "InputField_StoredValueCurrentMin";
            InputField_StoredValueCurrentMin.PlaceholderText = "0 A";
            InputField_StoredValueCurrentMin.Size = new Size(266, 23);
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
            InputField_StoredValueCurrentPlus.Size = new Size(266, 23);
            InputField_StoredValueCurrentPlus.TabIndex = 0;
            InputField_StoredValueCurrentPlus.Tag = "";
            InputField_StoredValueCurrentPlus.TextAlign = HorizontalAlignment.Center;
            // 
            // LiveInfoData
            // 
            LiveInfoData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LiveInfoData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            LiveInfoData.Controls.Add(tableLayoutPanel2);
            LiveInfoData.Location = new Point(12, 12);
            LiveInfoData.Name = "LiveInfoData";
            LiveInfoData.Size = new Size(841, 206);
            LiveInfoData.TabIndex = 6;
            LiveInfoData.TabStop = false;
            LiveInfoData.Text = "SM70-CP-450 Controller Status:";
            // 
            // ManualForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(865, 527);
            Controls.Add(Output_Btn2);
            Controls.Add(Output_Btn1);
            Controls.Add(LiveInfoData);
            Name = "ManualForm";
            Text = "ManualForm";
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
            LiveInfoData.ResumeLayout(false);
            LiveInfoData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Output_Btn2;
        private Button Output_Btn1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel9;
        private ComboBox CV_ComboBox;
        private Label Label_MachineAppliedVoltage_UI;
        private Label Label_Remote_CV_UI;
        private TableLayoutPanel tableLayoutPanel8;
        private TextBox InputField_StoredValueVoltage;
        private Button SetValues_btn;
        private TableLayoutPanel tableLayoutPanel7;
        private TextBox InputField_StoredValuePowerMin;
        private TextBox InputField_StoredValuePowerPlus;
        private TableLayoutPanel tableLayoutPanel5;
        private ComboBox CP_ComboBox;
        private Label Label_MachineAppliedPowerPlus_UI;
        private Label Label_Remote_CP_UI;
        private Label Label_MachineAppliedPowerMin_UI;
        private Label WattageDisplay;
        private Label VoltageDisplay;
        private Label AmperageDisplay;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox CC_ComboBox;
        private Label Label_MachineAppliedCurrentPlus_UI;
        private Label Label_Remote_CC_UI;
        private Label Label_MachineAppliedCurrentMin_UI;
        private TableLayoutPanel tableLayoutPanel6;
        private TextBox InputField_StoredValueCurrentMin;
        private TextBox InputField_StoredValueCurrentPlus;
        private GroupBox LiveInfoData;
    }
}