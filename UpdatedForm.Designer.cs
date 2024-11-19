namespace sm70_cp_450_GUI
{
    partial class UpdatedForm
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
            components = new System.ComponentModel.Container();
            Input_BulkVoltage = new TextBox();
            Input_MaxAmps = new TextBox();
            Input_Capacity = new TextBox();
            Input_CutoffVoltage = new TextBox();
            Input_Procent = new TextBox();
            Button_Save = new Button();
            Button_Stop = new Button();
            Button_Pause = new Button();
            Button_Start = new Button();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            Label_Capacity = new Label();
            Label_BulkVolt = new Label();
            Label_MinVolt = new Label();
            Label_MaxCurr = new Label();
            Label_Procent = new Label();
            Label_LiveVoltage = new Label();
            Label_LiveCurrent = new Label();
            Rad_Btn_Charge = new RadioButton();
            Rad_Btn_Discharge = new RadioButton();
            Label_TriggerTime = new Label();
            Label_TriggerThreshold = new Label();
            Input_TriggerTime = new TextBox();
            Input_TriggerThreshold = new TextBox();
            Input_CRating = new TextBox();
            Label_ThresholdTimeRemaining = new Label();
            Label_thresholdPercent = new Label();
            Label_Timer1 = new Label();
            Label_SOC = new Label();
            Label_initialGuessedPercent = new Label();
            Input_Watt = new TextBox();
            Label_Watt = new Label();
            SuspendLayout();
            // 
            // Input_BulkVoltage
            // 
            Input_BulkVoltage.Location = new Point(179, 179);
            Input_BulkVoltage.Name = "Input_BulkVoltage";
            Input_BulkVoltage.PlaceholderText = "Charge voltage (Bulk) ";
            Input_BulkVoltage.Size = new Size(130, 23);
            Input_BulkVoltage.TabIndex = 2;
            // 
            // Input_MaxAmps
            // 
            Input_MaxAmps.Location = new Point(179, 237);
            Input_MaxAmps.Name = "Input_MaxAmps";
            Input_MaxAmps.PlaceholderText = "Max charging Amps";
            Input_MaxAmps.Size = new Size(130, 23);
            Input_MaxAmps.TabIndex = 4;
            // 
            // Input_Capacity
            // 
            Input_Capacity.Location = new Point(179, 150);
            Input_Capacity.Name = "Input_Capacity";
            Input_Capacity.PlaceholderText = "Capacity Ah";
            Input_Capacity.Size = new Size(130, 23);
            Input_Capacity.TabIndex = 1;
            // 
            // Input_CutoffVoltage
            // 
            Input_CutoffVoltage.Location = new Point(179, 208);
            Input_CutoffVoltage.Name = "Input_CutoffVoltage";
            Input_CutoffVoltage.PlaceholderText = "Mininum voltage";
            Input_CutoffVoltage.Size = new Size(130, 23);
            Input_CutoffVoltage.TabIndex = 3;
            // 
            // Input_Procent
            // 
            Input_Procent.Location = new Point(179, 266);
            Input_Procent.Name = "Input_Procent";
            Input_Procent.PlaceholderText = "Soc to %";
            Input_Procent.Size = new Size(130, 23);
            Input_Procent.TabIndex = 6;
            // 
            // Button_Save
            // 
            Button_Save.Location = new Point(179, 353);
            Button_Save.Name = "Button_Save";
            Button_Save.Size = new Size(266, 23);
            Button_Save.TabIndex = 9;
            Button_Save.Text = "Save Settings";
            Button_Save.UseVisualStyleBackColor = true;
            Button_Save.Click += ButtonHandler;
            // 
            // Button_Stop
            // 
            Button_Stop.Location = new Point(179, 410);
            Button_Stop.Name = "Button_Stop";
            Button_Stop.Size = new Size(87, 23);
            Button_Stop.TabIndex = 10;
            Button_Stop.Text = "Stop";
            Button_Stop.UseVisualStyleBackColor = true;
            Button_Stop.Click += ButtonHandler;
            // 
            // Button_Pause
            // 
            Button_Pause.Location = new Point(272, 410);
            Button_Pause.Name = "Button_Pause";
            Button_Pause.Size = new Size(78, 23);
            Button_Pause.TabIndex = 11;
            Button_Pause.Text = "Pause";
            Button_Pause.UseVisualStyleBackColor = true;
            // 
            // Button_Start
            // 
            Button_Start.Location = new Point(356, 410);
            Button_Start.Name = "Button_Start";
            Button_Start.Size = new Size(89, 23);
            Button_Start.TabIndex = 12;
            Button_Start.Text = "Start";
            Button_Start.UseVisualStyleBackColor = true;
            Button_Start.Click += ButtonHandler;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += TimedFunction;
            // 
            // Label_Capacity
            // 
            Label_Capacity.AutoSize = true;
            Label_Capacity.Location = new Point(44, 153);
            Label_Capacity.Name = "Label_Capacity";
            Label_Capacity.Size = new Size(86, 15);
            Label_Capacity.TabIndex = 21;
            Label_Capacity.Text = "Label_Capacity";
            // 
            // Label_BulkVolt
            // 
            Label_BulkVolt.AutoSize = true;
            Label_BulkVolt.Location = new Point(44, 182);
            Label_BulkVolt.Name = "Label_BulkVolt";
            Label_BulkVolt.Size = new Size(83, 15);
            Label_BulkVolt.TabIndex = 22;
            Label_BulkVolt.Text = "Label_BulkVolt";
            // 
            // Label_MinVolt
            // 
            Label_MinVolt.AutoSize = true;
            Label_MinVolt.Location = new Point(44, 211);
            Label_MinVolt.Name = "Label_MinVolt";
            Label_MinVolt.Size = new Size(81, 15);
            Label_MinVolt.TabIndex = 23;
            Label_MinVolt.Text = "Label_MinVolt";
            // 
            // Label_MaxCurr
            // 
            Label_MaxCurr.AutoSize = true;
            Label_MaxCurr.Location = new Point(44, 240);
            Label_MaxCurr.Name = "Label_MaxCurr";
            Label_MaxCurr.Size = new Size(86, 15);
            Label_MaxCurr.TabIndex = 24;
            Label_MaxCurr.Text = "Label_MaxCurr";
            // 
            // Label_Procent
            // 
            Label_Procent.AutoSize = true;
            Label_Procent.Location = new Point(44, 269);
            Label_Procent.Name = "Label_Procent";
            Label_Procent.Size = new Size(81, 15);
            Label_Procent.TabIndex = 25;
            Label_Procent.Text = "Label_Procent";
            // 
            // Label_LiveVoltage
            // 
            Label_LiveVoltage.AutoSize = true;
            Label_LiveVoltage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_LiveVoltage.Location = new Point(44, 99);
            Label_LiveVoltage.Name = "Label_LiveVoltage";
            Label_LiveVoltage.Size = new Size(134, 21);
            Label_LiveVoltage.TabIndex = 26;
            Label_LiveVoltage.Text = "Label_LiveVoltage";
            // 
            // Label_LiveCurrent
            // 
            Label_LiveCurrent.AutoSize = true;
            Label_LiveCurrent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_LiveCurrent.Location = new Point(217, 99);
            Label_LiveCurrent.Name = "Label_LiveCurrent";
            Label_LiveCurrent.Size = new Size(135, 21);
            Label_LiveCurrent.TabIndex = 27;
            Label_LiveCurrent.Text = "Label_LiveCurrent";
            // 
            // Rad_Btn_Charge
            // 
            Rad_Btn_Charge.AutoSize = true;
            Rad_Btn_Charge.Location = new Point(179, 439);
            Rad_Btn_Charge.Name = "Rad_Btn_Charge";
            Rad_Btn_Charge.Size = new Size(63, 19);
            Rad_Btn_Charge.TabIndex = 13;
            Rad_Btn_Charge.TabStop = true;
            Rad_Btn_Charge.Text = "Charge";
            Rad_Btn_Charge.UseVisualStyleBackColor = true;
            // 
            // Rad_Btn_Discharge
            // 
            Rad_Btn_Discharge.AutoSize = true;
            Rad_Btn_Discharge.Location = new Point(368, 439);
            Rad_Btn_Discharge.Name = "Rad_Btn_Discharge";
            Rad_Btn_Discharge.Size = new Size(77, 19);
            Rad_Btn_Discharge.TabIndex = 14;
            Rad_Btn_Discharge.TabStop = true;
            Rad_Btn_Discharge.Text = "Discharge";
            Rad_Btn_Discharge.UseVisualStyleBackColor = true;
            // 
            // Label_TriggerTime
            // 
            Label_TriggerTime.AutoSize = true;
            Label_TriggerTime.Location = new Point(44, 327);
            Label_TriggerTime.Name = "Label_TriggerTime";
            Label_TriggerTime.Size = new Size(102, 15);
            Label_TriggerTime.TabIndex = 31;
            Label_TriggerTime.Text = "Label_TriggerTime";
            // 
            // Label_TriggerThreshold
            // 
            Label_TriggerThreshold.AutoSize = true;
            Label_TriggerThreshold.Location = new Point(44, 298);
            Label_TriggerThreshold.Name = "Label_TriggerThreshold";
            Label_TriggerThreshold.Size = new Size(128, 15);
            Label_TriggerThreshold.TabIndex = 30;
            Label_TriggerThreshold.Text = "Label_TriggerThreshold";
            // 
            // Input_TriggerTime
            // 
            Input_TriggerTime.Location = new Point(179, 324);
            Input_TriggerTime.Name = "Input_TriggerTime";
            Input_TriggerTime.PlaceholderText = "Threshold Time";
            Input_TriggerTime.Size = new Size(130, 23);
            Input_TriggerTime.TabIndex = 8;
            // 
            // Input_TriggerThreshold
            // 
            Input_TriggerThreshold.Location = new Point(179, 295);
            Input_TriggerThreshold.Name = "Input_TriggerThreshold";
            Input_TriggerThreshold.PlaceholderText = "Threshold %";
            Input_TriggerThreshold.Size = new Size(130, 23);
            Input_TriggerThreshold.TabIndex = 7;
            // 
            // Input_CRating
            // 
            Input_CRating.Location = new Point(315, 237);
            Input_CRating.Name = "Input_CRating";
            Input_CRating.PlaceholderText = "C-Rating, (NOT WORKING)";
            Input_CRating.Size = new Size(130, 23);
            Input_CRating.TabIndex = 32;
            // 
            // Label_ThresholdTimeRemaining
            // 
            Label_ThresholdTimeRemaining.AutoSize = true;
            Label_ThresholdTimeRemaining.Location = new Point(451, 327);
            Label_ThresholdTimeRemaining.Name = "Label_ThresholdTimeRemaining";
            Label_ThresholdTimeRemaining.Size = new Size(27, 15);
            Label_ThresholdTimeRemaining.TabIndex = 34;
            Label_ThresholdTimeRemaining.Text = "0.0s";
            // 
            // Label_thresholdPercent
            // 
            Label_thresholdPercent.AutoSize = true;
            Label_thresholdPercent.Location = new Point(451, 298);
            Label_thresholdPercent.Name = "Label_thresholdPercent";
            Label_thresholdPercent.Size = new Size(130, 15);
            Label_thresholdPercent.TabIndex = 35;
            Label_thresholdPercent.Text = "Label_thresholdPercent";
            // 
            // Label_Timer1
            // 
            Label_Timer1.AutoSize = true;
            Label_Timer1.Location = new Point(451, 269);
            Label_Timer1.Name = "Label_Timer1";
            Label_Timer1.Size = new Size(76, 15);
            Label_Timer1.TabIndex = 36;
            Label_Timer1.Text = "Label_Timer1";
            // 
            // Label_SOC
            // 
            Label_SOC.AutoSize = true;
            Label_SOC.Location = new Point(451, 240);
            Label_SOC.Name = "Label_SOC";
            Label_SOC.Size = new Size(63, 15);
            Label_SOC.TabIndex = 37;
            Label_SOC.Text = "Label_SOC";
            // 
            // Label_initialGuessedPercent
            // 
            Label_initialGuessedPercent.AutoSize = true;
            Label_initialGuessedPercent.Location = new Point(451, 211);
            Label_initialGuessedPercent.Name = "Label_initialGuessedPercent";
            Label_initialGuessedPercent.Size = new Size(77, 15);
            Label_initialGuessedPercent.TabIndex = 38;
            Label_initialGuessedPercent.Text = "Guessed SOC";
            // 
            // Input_Watt
            // 
            Input_Watt.Location = new Point(315, 150);
            Input_Watt.Name = "Input_Watt";
            Input_Watt.PlaceholderText = "max watt, norm5000";
            Input_Watt.Size = new Size(130, 23);
            Input_Watt.TabIndex = 39;
            // 
            // Label_Watt
            // 
            Label_Watt.AutoSize = true;
            Label_Watt.Location = new Point(451, 153);
            Label_Watt.Name = "Label_Watt";
            Label_Watt.Size = new Size(38, 15);
            Label_Watt.TabIndex = 40;
            Label_Watt.Text = "label1";
            // 
            // UpdatedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 768);
            Controls.Add(Label_Watt);
            Controls.Add(Input_Watt);
            Controls.Add(Label_initialGuessedPercent);
            Controls.Add(Label_SOC);
            Controls.Add(Label_Timer1);
            Controls.Add(Label_thresholdPercent);
            Controls.Add(Label_ThresholdTimeRemaining);
            Controls.Add(Input_CRating);
            Controls.Add(Label_TriggerTime);
            Controls.Add(Label_TriggerThreshold);
            Controls.Add(Input_TriggerTime);
            Controls.Add(Input_TriggerThreshold);
            Controls.Add(Rad_Btn_Discharge);
            Controls.Add(Rad_Btn_Charge);
            Controls.Add(Label_LiveCurrent);
            Controls.Add(Label_LiveVoltage);
            Controls.Add(Label_Procent);
            Controls.Add(Label_MaxCurr);
            Controls.Add(Label_MinVolt);
            Controls.Add(Label_BulkVolt);
            Controls.Add(Label_Capacity);
            Controls.Add(Button_Start);
            Controls.Add(Button_Pause);
            Controls.Add(Button_Stop);
            Controls.Add(Button_Save);
            Controls.Add(Input_Procent);
            Controls.Add(Input_CutoffVoltage);
            Controls.Add(Input_BulkVoltage);
            Controls.Add(Input_MaxAmps);
            Controls.Add(Input_Capacity);
            Name = "UpdatedForm";
            Text = "UpdatedForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox Input_BulkVoltage;
        private TextBox Input_MaxAmps;
        private TextBox Input_Capacity;
        private TextBox Input_CutoffVoltage;
        private TextBox Input_Procent;
        private Button Button_Save;
        private Button Button_Stop;
        private Button Button_Pause;
        private Button Button_Start;
        private System.Windows.Forms.Timer UpdateTimer;
        private Label Label_Capacity;
        private Label Label_BulkVolt;
        private Label Label_MinVolt;
        private Label Label_MaxCurr;
        private Label Label_Procent;
        private Label Label_LiveVoltage;
        private Label Label_LiveCurrent;
        private RadioButton Rad_Btn_Charge;
        private RadioButton Rad_Btn_Discharge;
        private Label Label_TriggerTime;
        private Label Label_TriggerThreshold;
        private TextBox Input_TriggerTime;
        private TextBox Input_TriggerThreshold;
        private TextBox Input_CRating;
        private Label Label_ThresholdTimeRemaining;
        private Label Label_thresholdPercent;
        private Label Label_Timer1;
        private Label Label_SOC;
        private Label Label_initialGuessedPercent;
        private TextBox Input_Watt;
        private Label Label_Watt;
    }
}