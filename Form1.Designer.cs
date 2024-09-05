namespace sm70_cp_450_GUI
{
    partial class Form1
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
            LiveInfoData = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            WattageDisplay = new Label();
            AppliedChargeAmps_UI = new TextBox();
            VoltageDisplay = new Label();
            AmperageDisplay = new Label();
            AppliedVolts_UI = new TextBox();
            AppliedChargeWatts_UI = new TextBox();
            AppliedDischargeAmps_UI = new TextBox();
            AppliedDischargeWatts_UI = new TextBox();
            EditValueButton = new Button();
            OperationsBox_UI = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            BatteryConnectButton = new Button();
            StartStopButton = new Button();
            Charge30Button = new Button();
            ChargeButton = new Button();
            DischargeButton = new Button();
            StatusCurrentOperation_UI = new TextBox();
            label7 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            BatteryInfo = new GroupBox();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            RemoteCP_UI = new Label();
            RemoteCC_UI = new Label();
            StatusLabel_UI = new Label();
            label3 = new Label();
            label4 = new Label();
            RemoteCV_UI = new Label();
            groupBox2 = new GroupBox();
            ApplyBatteryDataButton = new Button();
            C_Rating_UI = new TextBox();
            RatedBatteryVoltageUI = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            RatedBatteryAmperageUI = new TextBox();
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            OperationsBox_UI.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            BatteryInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // LiveInfoData
            // 
            LiveInfoData.Controls.Add(tableLayoutPanel2);
            LiveInfoData.Dock = DockStyle.Top;
            LiveInfoData.Location = new Point(0, 0);
            LiveInfoData.Name = "LiveInfoData";
            LiveInfoData.Size = new Size(782, 192);
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
            tableLayoutPanel2.Controls.Add(WattageDisplay, 2, 0);
            tableLayoutPanel2.Controls.Add(AppliedChargeAmps_UI, 1, 1);
            tableLayoutPanel2.Controls.Add(VoltageDisplay, 0, 0);
            tableLayoutPanel2.Controls.Add(AmperageDisplay, 1, 0);
            tableLayoutPanel2.Controls.Add(AppliedVolts_UI, 0, 1);
            tableLayoutPanel2.Controls.Add(AppliedChargeWatts_UI, 2, 1);
            tableLayoutPanel2.Controls.Add(AppliedDischargeAmps_UI, 1, 2);
            tableLayoutPanel2.Controls.Add(AppliedDischargeWatts_UI, 2, 2);
            tableLayoutPanel2.Controls.Add(EditValueButton, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 30);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(776, 159);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // WattageDisplay
            // 
            WattageDisplay.AutoSize = true;
            WattageDisplay.Dock = DockStyle.Fill;
            WattageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            WattageDisplay.Location = new Point(520, 0);
            WattageDisplay.Margin = new Padding(4, 0, 4, 0);
            WattageDisplay.Name = "WattageDisplay";
            WattageDisplay.Size = new Size(252, 47);
            WattageDisplay.TabIndex = 2;
            WattageDisplay.Text = "0.0 W";
            WattageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AppliedChargeAmps_UI
            // 
            AppliedChargeAmps_UI.Dock = DockStyle.Fill;
            AppliedChargeAmps_UI.Location = new Point(268, 57);
            AppliedChargeAmps_UI.Margin = new Padding(10);
            AppliedChargeAmps_UI.Name = "AppliedChargeAmps_UI";
            AppliedChargeAmps_UI.PlaceholderText = "0.0 A";
            AppliedChargeAmps_UI.ReadOnly = true;
            AppliedChargeAmps_UI.Size = new Size(238, 34);
            AppliedChargeAmps_UI.TabIndex = 10;
            AppliedChargeAmps_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // VoltageDisplay
            // 
            VoltageDisplay.AutoSize = true;
            VoltageDisplay.Dock = DockStyle.Fill;
            VoltageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            VoltageDisplay.Location = new Point(4, 0);
            VoltageDisplay.Margin = new Padding(4, 0, 4, 0);
            VoltageDisplay.Name = "VoltageDisplay";
            VoltageDisplay.Size = new Size(250, 47);
            VoltageDisplay.TabIndex = 0;
            VoltageDisplay.Text = "0.0 V";
            VoltageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AmperageDisplay
            // 
            AmperageDisplay.AutoSize = true;
            AmperageDisplay.Dock = DockStyle.Fill;
            AmperageDisplay.Font = new Font("Segoe UI", 21F, FontStyle.Regular, GraphicsUnit.Point);
            AmperageDisplay.Location = new Point(262, 0);
            AmperageDisplay.Margin = new Padding(4, 0, 4, 0);
            AmperageDisplay.Name = "AmperageDisplay";
            AmperageDisplay.Size = new Size(250, 47);
            AmperageDisplay.TabIndex = 1;
            AmperageDisplay.Text = "0.0 A";
            AmperageDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AppliedVolts_UI
            // 
            AppliedVolts_UI.Dock = DockStyle.Fill;
            AppliedVolts_UI.Location = new Point(10, 57);
            AppliedVolts_UI.Margin = new Padding(10);
            AppliedVolts_UI.Name = "AppliedVolts_UI";
            AppliedVolts_UI.PlaceholderText = "0.0 V";
            AppliedVolts_UI.ReadOnly = true;
            AppliedVolts_UI.Size = new Size(238, 34);
            AppliedVolts_UI.TabIndex = 9;
            AppliedVolts_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // AppliedChargeWatts_UI
            // 
            AppliedChargeWatts_UI.Dock = DockStyle.Fill;
            AppliedChargeWatts_UI.Location = new Point(526, 57);
            AppliedChargeWatts_UI.Margin = new Padding(10);
            AppliedChargeWatts_UI.Name = "AppliedChargeWatts_UI";
            AppliedChargeWatts_UI.PlaceholderText = "0.0 W";
            AppliedChargeWatts_UI.ReadOnly = true;
            AppliedChargeWatts_UI.Size = new Size(240, 34);
            AppliedChargeWatts_UI.TabIndex = 11;
            AppliedChargeWatts_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // AppliedDischargeAmps_UI
            // 
            AppliedDischargeAmps_UI.Dock = DockStyle.Fill;
            AppliedDischargeAmps_UI.Location = new Point(268, 111);
            AppliedDischargeAmps_UI.Margin = new Padding(10);
            AppliedDischargeAmps_UI.Name = "AppliedDischargeAmps_UI";
            AppliedDischargeAmps_UI.PlaceholderText = "-0.0 A";
            AppliedDischargeAmps_UI.ReadOnly = true;
            AppliedDischargeAmps_UI.Size = new Size(238, 34);
            AppliedDischargeAmps_UI.TabIndex = 12;
            AppliedDischargeAmps_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // AppliedDischargeWatts_UI
            // 
            AppliedDischargeWatts_UI.Dock = DockStyle.Fill;
            AppliedDischargeWatts_UI.Location = new Point(526, 111);
            AppliedDischargeWatts_UI.Margin = new Padding(10);
            AppliedDischargeWatts_UI.Name = "AppliedDischargeWatts_UI";
            AppliedDischargeWatts_UI.PlaceholderText = "-0.0 W";
            AppliedDischargeWatts_UI.ReadOnly = true;
            AppliedDischargeWatts_UI.Size = new Size(240, 34);
            AppliedDischargeWatts_UI.TabIndex = 13;
            AppliedDischargeWatts_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // EditValueButton
            // 
            EditValueButton.Anchor = AnchorStyles.Top;
            EditValueButton.AutoSize = true;
            EditValueButton.Location = new Point(9, 104);
            EditValueButton.Name = "EditValueButton";
            EditValueButton.Size = new Size(240, 38);
            EditValueButton.TabIndex = 14;
            EditValueButton.Text = "Edit Values";
            EditValueButton.UseVisualStyleBackColor = true;
            EditValueButton.Click += ToggleManualEditing;
            // 
            // OperationsBox_UI
            // 
            OperationsBox_UI.Controls.Add(tableLayoutPanel4);
            OperationsBox_UI.Dock = DockStyle.Bottom;
            OperationsBox_UI.Location = new Point(341, 382);
            OperationsBox_UI.Name = "OperationsBox_UI";
            OperationsBox_UI.Size = new Size(441, 191);
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
            tableLayoutPanel4.Location = new Point(3, 30);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(435, 158);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // BatteryConnectButton
            // 
            BatteryConnectButton.BackColor = Color.White;
            BatteryConnectButton.Dock = DockStyle.Fill;
            BatteryConnectButton.Location = new Point(3, 82);
            BatteryConnectButton.Name = "BatteryConnectButton";
            BatteryConnectButton.Size = new Size(138, 73);
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
            StartStopButton.Enabled = false;
            StartStopButton.Location = new Point(292, 82);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(140, 73);
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
            Charge30Button.Location = new Point(292, 3);
            Charge30Button.Name = "Charge30Button";
            Charge30Button.Size = new Size(140, 73);
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
            ChargeButton.Size = new Size(138, 73);
            ChargeButton.TabIndex = 0;
            ChargeButton.Text = "Charge";
            ChargeButton.UseVisualStyleBackColor = false;
            ChargeButton.Click += ChargeButton_Click;
            // 
            // DischargeButton
            // 
            DischargeButton.BackColor = Color.White;
            DischargeButton.Dock = DockStyle.Fill;
            DischargeButton.Location = new Point(147, 3);
            DischargeButton.Name = "DischargeButton";
            DischargeButton.Size = new Size(139, 73);
            DischargeButton.TabIndex = 1;
            DischargeButton.Text = "Discharge";
            DischargeButton.UseVisualStyleBackColor = false;
            DischargeButton.Click += DischargeButton_Click;
            // 
            // StatusCurrentOperation_UI
            // 
            StatusCurrentOperation_UI.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            StatusCurrentOperation_UI.Location = new Point(537, 195);
            StatusCurrentOperation_UI.Margin = new Padding(0);
            StatusCurrentOperation_UI.Name = "StatusCurrentOperation_UI";
            StatusCurrentOperation_UI.ReadOnly = true;
            StatusCurrentOperation_UI.Size = new Size(242, 43);
            StatusCurrentOperation_UI.TabIndex = 15;
            StatusCurrentOperation_UI.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.Location = new Point(350, 195);
            label7.Name = "label7";
            label7.Size = new Size(281, 43);
            label7.TabIndex = 12;
            label7.Text = "Current Operation:";
            // 
            // BatteryInfo
            // 
            BatteryInfo.Controls.Add(groupBox1);
            BatteryInfo.Controls.Add(groupBox2);
            BatteryInfo.Dock = DockStyle.Left;
            BatteryInfo.Location = new Point(0, 192);
            BatteryInfo.Name = "BatteryInfo";
            BatteryInfo.Size = new Size(341, 381);
            BatteryInfo.TabIndex = 6;
            BatteryInfo.TabStop = false;
            BatteryInfo.Text = "Battery Data";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(3, 212);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 166);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(RemoteCP_UI, 1, 2);
            tableLayoutPanel1.Controls.Add(RemoteCC_UI, 1, 1);
            tableLayoutPanel1.Controls.Add(StatusLabel_UI, 0, 0);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(RemoteCV_UI, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel1.Location = new Point(3, 30);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(329, 133);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // RemoteCP_UI
            // 
            RemoteCP_UI.AutoSize = true;
            RemoteCP_UI.Dock = DockStyle.Fill;
            RemoteCP_UI.Location = new Point(124, 88);
            RemoteCP_UI.Margin = new Padding(0);
            RemoteCP_UI.Name = "RemoteCP_UI";
            RemoteCP_UI.Size = new Size(205, 45);
            RemoteCP_UI.TabIndex = 10;
            RemoteCP_UI.Text = "Local";
            RemoteCP_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RemoteCC_UI
            // 
            RemoteCC_UI.AutoSize = true;
            RemoteCC_UI.Dock = DockStyle.Fill;
            RemoteCC_UI.Location = new Point(124, 44);
            RemoteCC_UI.Margin = new Padding(0);
            RemoteCC_UI.Name = "RemoteCC_UI";
            RemoteCC_UI.Size = new Size(205, 44);
            RemoteCC_UI.TabIndex = 9;
            RemoteCC_UI.Text = "Local";
            RemoteCC_UI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StatusLabel_UI
            // 
            StatusLabel_UI.AutoSize = true;
            StatusLabel_UI.Dock = DockStyle.Fill;
            StatusLabel_UI.Location = new Point(3, 0);
            StatusLabel_UI.Name = "StatusLabel_UI";
            StatusLabel_UI.Padding = new Padding(3);
            StatusLabel_UI.Size = new Size(118, 44);
            StatusLabel_UI.TabIndex = 0;
            StatusLabel_UI.Text = "Remote CV:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 44);
            label3.Name = "label3";
            label3.Padding = new Padding(3);
            label3.Size = new Size(118, 44);
            label3.TabIndex = 1;
            label3.Text = "Remote CC:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(3, 88);
            label4.Name = "label4";
            label4.Padding = new Padding(3);
            label4.Size = new Size(118, 45);
            label4.TabIndex = 2;
            label4.Text = "Remote CP:";
            // 
            // RemoteCV_UI
            // 
            RemoteCV_UI.AutoSize = true;
            RemoteCV_UI.Dock = DockStyle.Fill;
            RemoteCV_UI.Location = new Point(124, 0);
            RemoteCV_UI.Margin = new Padding(0);
            RemoteCV_UI.Name = "RemoteCV_UI";
            RemoteCV_UI.Size = new Size(205, 44);
            RemoteCV_UI.TabIndex = 8;
            RemoteCV_UI.Text = "Local";
            RemoteCV_UI.TextAlign = ContentAlignment.MiddleCenter;
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
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(3, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(335, 186);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Factory Information";
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Location = new Point(16, 140);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(313, 36);
            ApplyBatteryDataButton.TabIndex = 11;
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            ApplyBatteryDataButton.Click += UpdateFromBatteryLabelData;
            // 
            // C_Rating_UI
            // 
            C_Rating_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            C_Rating_UI.Location = new Point(209, 105);
            C_Rating_UI.Name = "C_Rating_UI";
            C_Rating_UI.PlaceholderText = "C1";
            C_Rating_UI.Size = new Size(120, 34);
            C_Rating_UI.TabIndex = 10;
            // 
            // RatedBatteryVoltageUI
            // 
            RatedBatteryVoltageUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RatedBatteryVoltageUI.Location = new Point(209, 35);
            RatedBatteryVoltageUI.Name = "RatedBatteryVoltageUI";
            RatedBatteryVoltageUI.PlaceholderText = "Voltage";
            RatedBatteryVoltageUI.Size = new Size(120, 34);
            RatedBatteryVoltageUI.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(135, 28);
            label1.TabIndex = 6;
            label1.Text = "Rated Voltage";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 102);
            label6.Name = "label6";
            label6.Size = new Size(86, 28);
            label6.TabIndex = 9;
            label6.Text = "C Rating";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(140, 28);
            label2.TabIndex = 8;
            label2.Text = "Rated capacity";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RatedBatteryAmperageUI
            // 
            RatedBatteryAmperageUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RatedBatteryAmperageUI.Location = new Point(209, 70);
            RatedBatteryAmperageUI.Name = "RatedBatteryAmperageUI";
            RatedBatteryAmperageUI.PlaceholderText = "Amps / Hour";
            RatedBatteryAmperageUI.Size = new Size(120, 34);
            RatedBatteryAmperageUI.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 573);
            Controls.Add(StatusCurrentOperation_UI);
            Controls.Add(OperationsBox_UI);
            Controls.Add(label7);
            Controls.Add(BatteryInfo);
            Controls.Add(LiveInfoData);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Sm15k Controller";
            LiveInfoData.ResumeLayout(false);
            LiveInfoData.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            OperationsBox_UI.ResumeLayout(false);
            OperationsBox_UI.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            BatteryInfo.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox LiveInfoData;
        private Label AmperageDisplay;
        private Label VoltageDisplay;
        private Label WattageDisplay;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox OperationsBox_UI;
        private TableLayoutPanel tableLayoutPanel4;
        private Button Charge30Button;
        private Button ChargeButton;
        private Button DischargeButton;
        private TextBox AppliedChargeWatts_UI;
        private TextBox AppliedChargeAmps_UI;
        private TextBox AppliedVolts_UI;
        private TextBox AppliedDischargeAmps_UI;
        private TextBox AppliedDischargeWatts_UI;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button EditValueButton;
        private Button StartStopButton;
        private GroupBox BatteryInfo;
        private GroupBox groupBox2;
        private Button ApplyBatteryDataButton;
        private TextBox C_Rating_UI;
        private TextBox RatedBatteryVoltageUI;
        private Label label1;
        private Label label6;
        private Label label2;
        private TextBox RatedBatteryAmperageUI;
        private TextBox StatusCurrentOperation_UI;
        private Label label7;
        private Button BatteryConnectButton;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label RemoteCP_UI;
        private Label RemoteCC_UI;
        private Label StatusLabel_UI;
        private Label label3;
        private Label label4;
        private Label RemoteCV_UI;
    }
}