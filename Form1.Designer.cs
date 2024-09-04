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
            RatedBatteryVoltageUI = new TextBox();
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
            BatteryInfo = new GroupBox();
            groupBox2 = new GroupBox();
            ApplyBatteryDataButton = new Button();
            C_Rating_UI = new TextBox();
            label1 = new Label();
            label6 = new Label();
            label2 = new Label();
            RatedBatteryAmperageUI = new TextBox();
            groupBox1 = new GroupBox();
            textBox4 = new TextBox();
            textBox1 = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label4 = new Label();
            groupBox4 = new GroupBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            StartStopButton = new Button();
            Charge30Button = new Button();
            ChargeButton = new Button();
            DischargeButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            LiveInfoData.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            BatteryInfo.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // RatedBatteryVoltageUI
            // 
            RatedBatteryVoltageUI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RatedBatteryVoltageUI.Location = new Point(180, 35);
            RatedBatteryVoltageUI.Name = "RatedBatteryVoltageUI";
            RatedBatteryVoltageUI.PlaceholderText = "Voltage";
            RatedBatteryVoltageUI.Size = new Size(120, 34);
            RatedBatteryVoltageUI.TabIndex = 3;
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
            EditValueButton.Location = new Point(3, 104);
            EditValueButton.Name = "EditValueButton";
            EditValueButton.Size = new Size(245, 34);
            EditValueButton.TabIndex = 14;
            EditValueButton.Text = "Edit Values";
            EditValueButton.UseVisualStyleBackColor = true;
            EditValueButton.Click += ToggleManualEditing;
            // 
            // BatteryInfo
            // 
            BatteryInfo.Controls.Add(groupBox2);
            BatteryInfo.Controls.Add(groupBox1);
            BatteryInfo.Dock = DockStyle.Right;
            BatteryInfo.Location = new Point(470, 192);
            BatteryInfo.Name = "BatteryInfo";
            BatteryInfo.Size = new Size(312, 381);
            BatteryInfo.TabIndex = 6;
            BatteryInfo.TabStop = false;
            BatteryInfo.Text = "Battery Data";
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
            groupBox2.Size = new Size(306, 186);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "Factory Information";
            // 
            // ApplyBatteryDataButton
            // 
            ApplyBatteryDataButton.Location = new Point(16, 140);
            ApplyBatteryDataButton.Name = "ApplyBatteryDataButton";
            ApplyBatteryDataButton.Size = new Size(290, 36);
            ApplyBatteryDataButton.TabIndex = 11;
            ApplyBatteryDataButton.Text = "Apply";
            ApplyBatteryDataButton.UseVisualStyleBackColor = true;
            ApplyBatteryDataButton.Click += UpdateFromBatteryLabelData;
            // 
            // C_Rating_UI
            // 
            C_Rating_UI.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            C_Rating_UI.Location = new Point(180, 105);
            C_Rating_UI.Name = "C_Rating_UI";
            C_Rating_UI.PlaceholderText = "C1";
            C_Rating_UI.Size = new Size(120, 34);
            C_Rating_UI.TabIndex = 10;
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
            RatedBatteryAmperageUI.Location = new Point(180, 70);
            RatedBatteryAmperageUI.Name = "RatedBatteryAmperageUI";
            RatedBatteryAmperageUI.PlaceholderText = "Amps / Hour";
            RatedBatteryAmperageUI.Size = new Size(120, 34);
            RatedBatteryAmperageUI.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.Location = new Point(3, 222);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 156);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(180, 27);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(120, 30);
            textBox4.TabIndex = 16;
            textBox4.Text = "On";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(180, 55);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(120, 30);
            textBox1.TabIndex = 15;
            textBox1.Text = "Charging";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 58);
            label7.Name = "label7";
            label7.Size = new Size(168, 28);
            label7.TabIndex = 14;
            label7.Text = "Current operation";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 30);
            label5.Name = "label5";
            label5.Size = new Size(79, 28);
            label5.TabIndex = 13;
            label5.Text = "Output:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 86);
            label3.Name = "label3";
            label3.Size = new Size(125, 28);
            label3.TabIndex = 10;
            label3.Text = "Max Voltage:";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(180, 83);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Voltage";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(120, 30);
            textBox2.TabIndex = 9;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(180, 112);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Calculating...";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(120, 30);
            textBox3.TabIndex = 11;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 114);
            label4.Name = "label4";
            label4.Size = new Size(146, 28);
            label4.TabIndex = 12;
            label4.Text = "Discharge time:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(tableLayoutPanel4);
            groupBox4.Dock = DockStyle.Bottom;
            groupBox4.Location = new Point(0, 362);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(470, 211);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Operations";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.AutoSize = true;
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
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
            tableLayoutPanel4.Size = new Size(464, 178);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // StartStopButton
            // 
            StartStopButton.AutoSize = true;
            StartStopButton.BackColor = Color.Chartreuse;
            StartStopButton.Dock = DockStyle.Fill;
            StartStopButton.Location = new Point(311, 92);
            StartStopButton.Name = "StartStopButton";
            StartStopButton.Size = new Size(150, 83);
            StartStopButton.TabIndex = 11;
            StartStopButton.Text = "Start";
            StartStopButton.UseVisualStyleBackColor = false;
            // 
            // Charge30Button
            // 
            Charge30Button.BackColor = Color.White;
            Charge30Button.Dock = DockStyle.Fill;
            Charge30Button.Enabled = false;
            Charge30Button.Location = new Point(311, 3);
            Charge30Button.Name = "Charge30Button";
            Charge30Button.Size = new Size(150, 83);
            Charge30Button.TabIndex = 2;
            Charge30Button.Text = "Charge to 30%";
            Charge30Button.UseVisualStyleBackColor = false;
            Charge30Button.Click += Charge30Button_Click;
            // 
            // ChargeButton
            // 
            ChargeButton.BackColor = Color.White;
            ChargeButton.Dock = DockStyle.Fill;
            ChargeButton.Location = new Point(3, 3);
            ChargeButton.Name = "ChargeButton";
            ChargeButton.Size = new Size(148, 83);
            ChargeButton.TabIndex = 0;
            ChargeButton.Text = "Charge";
            ChargeButton.UseVisualStyleBackColor = false;
            ChargeButton.Click += ChargeButton_Click;
            // 
            // DischargeButton
            // 
            DischargeButton.BackColor = Color.White;
            DischargeButton.Dock = DockStyle.Fill;
            DischargeButton.Location = new Point(157, 3);
            DischargeButton.Name = "DischargeButton";
            DischargeButton.Size = new Size(148, 83);
            DischargeButton.TabIndex = 1;
            DischargeButton.Text = "Discharge";
            DischargeButton.UseVisualStyleBackColor = false;
            DischargeButton.Click += DischargeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 573);
            Controls.Add(groupBox4);
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
            BatteryInfo.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox RatedBatteryVoltageUI;
        private GroupBox LiveInfoData;
        private GroupBox BatteryInfo;
        private Label label1;
        private Label label2;
        private TextBox RatedBatteryAmperageUI;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label4;
        private Label AmperageDisplay;
        private Label VoltageDisplay;
        private Label WattageDisplay;
        private TableLayoutPanel tableLayoutPanel2;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel4;
        private Button Charge30Button;
        private Button ChargeButton;
        private Button DischargeButton;
        private TextBox C_Rating_UI;
        private Label label6;
        private Button ApplyBatteryDataButton;
        private TextBox AppliedChargeWatts_UI;
        private TextBox AppliedChargeAmps_UI;
        private TextBox AppliedVolts_UI;
        private TextBox AppliedDischargeAmps_UI;
        private TextBox AppliedDischargeWatts_UI;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button EditValueButton;
        private TextBox textBox4;
        private TextBox textBox1;
        private Label label7;
        private Label label5;
        private Button StartStopButton;
    }
}