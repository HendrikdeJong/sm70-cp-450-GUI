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
            Label_ThresholdTime = new Label();
            Label_ThresholdPercentage = new Label();
            Input_ThresholdTime = new TextBox();
            Input_ThresholdPercentage = new TextBox();
            Input_CRating = new TextBox();
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
            Button_Save.TabIndex = 7;
            Button_Save.Text = "Save Settings";
            Button_Save.UseVisualStyleBackColor = true;
            Button_Save.Click += ButtonHandler;
            // 
            // Button_Stop
            // 
            Button_Stop.Location = new Point(179, 410);
            Button_Stop.Name = "Button_Stop";
            Button_Stop.Size = new Size(87, 23);
            Button_Stop.TabIndex = 8;
            Button_Stop.Text = "Stop";
            Button_Stop.UseVisualStyleBackColor = true;
            Button_Stop.Click += ButtonHandler;
            // 
            // Button_Pause
            // 
            Button_Pause.Location = new Point(272, 410);
            Button_Pause.Name = "Button_Pause";
            Button_Pause.Size = new Size(78, 23);
            Button_Pause.TabIndex = 9;
            Button_Pause.Text = "Pause";
            Button_Pause.UseVisualStyleBackColor = true;
            // 
            // Button_Start
            // 
            Button_Start.Location = new Point(356, 410);
            Button_Start.Name = "Button_Start";
            Button_Start.Size = new Size(89, 23);
            Button_Start.TabIndex = 10;
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
            Label_Capacity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_Capacity.AutoSize = true;
            Label_Capacity.Location = new Point(87, 153);
            Label_Capacity.Name = "Label_Capacity";
            Label_Capacity.Size = new Size(86, 15);
            Label_Capacity.TabIndex = 21;
            Label_Capacity.Text = "Label_Capacity";
            // 
            // Label_BulkVolt
            // 
            Label_BulkVolt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_BulkVolt.AutoSize = true;
            Label_BulkVolt.Location = new Point(87, 182);
            Label_BulkVolt.Name = "Label_BulkVolt";
            Label_BulkVolt.Size = new Size(83, 15);
            Label_BulkVolt.TabIndex = 22;
            Label_BulkVolt.Text = "Label_BulkVolt";
            // 
            // Label_MinVolt
            // 
            Label_MinVolt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_MinVolt.AutoSize = true;
            Label_MinVolt.Location = new Point(87, 211);
            Label_MinVolt.Name = "Label_MinVolt";
            Label_MinVolt.Size = new Size(81, 15);
            Label_MinVolt.TabIndex = 23;
            Label_MinVolt.Text = "Label_MinVolt";
            // 
            // Label_MaxCurr
            // 
            Label_MaxCurr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_MaxCurr.AutoSize = true;
            Label_MaxCurr.Location = new Point(87, 240);
            Label_MaxCurr.Name = "Label_MaxCurr";
            Label_MaxCurr.Size = new Size(86, 15);
            Label_MaxCurr.TabIndex = 24;
            Label_MaxCurr.Text = "Label_MaxCurr";
            // 
            // Label_Procent
            // 
            Label_Procent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_Procent.AutoSize = true;
            Label_Procent.Location = new Point(87, 269);
            Label_Procent.Name = "Label_Procent";
            Label_Procent.Size = new Size(81, 15);
            Label_Procent.TabIndex = 25;
            Label_Procent.Text = "Label_Procent";
            // 
            // Label_LiveVoltage
            // 
            Label_LiveVoltage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_LiveVoltage.AutoSize = true;
            Label_LiveVoltage.Location = new Point(188, 57);
            Label_LiveVoltage.Name = "Label_LiveVoltage";
            Label_LiveVoltage.Size = new Size(100, 15);
            Label_LiveVoltage.TabIndex = 26;
            Label_LiveVoltage.Text = "Label_LiveVoltage";
            // 
            // Label_LiveCurrent
            // 
            Label_LiveCurrent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_LiveCurrent.AutoSize = true;
            Label_LiveCurrent.Location = new Point(294, 57);
            Label_LiveCurrent.Name = "Label_LiveCurrent";
            Label_LiveCurrent.Size = new Size(101, 15);
            Label_LiveCurrent.TabIndex = 27;
            Label_LiveCurrent.Text = "Label_LiveCurrent";
            // 
            // Rad_Btn_Charge
            // 
            Rad_Btn_Charge.AutoSize = true;
            Rad_Btn_Charge.Location = new Point(179, 439);
            Rad_Btn_Charge.Name = "Rad_Btn_Charge";
            Rad_Btn_Charge.Size = new Size(63, 19);
            Rad_Btn_Charge.TabIndex = 11;
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
            Rad_Btn_Discharge.TabIndex = 12;
            Rad_Btn_Discharge.TabStop = true;
            Rad_Btn_Discharge.Text = "Discharge";
            Rad_Btn_Discharge.UseVisualStyleBackColor = true;
            // 
            // Label_ThresholdTime
            // 
            Label_ThresholdTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_ThresholdTime.AutoSize = true;
            Label_ThresholdTime.Location = new Point(87, 327);
            Label_ThresholdTime.Name = "Label_ThresholdTime";
            Label_ThresholdTime.Size = new Size(96, 15);
            Label_ThresholdTime.TabIndex = 31;
            Label_ThresholdTime.Text = "Label_TholdTime";
            // 
            // Label_ThresholdPercentage
            // 
            Label_ThresholdPercentage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Label_ThresholdPercentage.AutoSize = true;
            Label_ThresholdPercentage.Location = new Point(87, 298);
            Label_ThresholdPercentage.Name = "Label_ThresholdPercentage";
            Label_ThresholdPercentage.Size = new Size(80, 15);
            Label_ThresholdPercentage.TabIndex = 30;
            Label_ThresholdPercentage.Text = "Label_Thold%";
            // 
            // Input_ThresholdTime
            // 
            Input_ThresholdTime.Location = new Point(179, 324);
            Input_ThresholdTime.Name = "Input_ThresholdTime";
            Input_ThresholdTime.PlaceholderText = "Threshold Time";
            Input_ThresholdTime.Size = new Size(130, 23);
            Input_ThresholdTime.TabIndex = 29;
            // 
            // Input_ThresholdPercentage
            // 
            Input_ThresholdPercentage.Location = new Point(179, 295);
            Input_ThresholdPercentage.Name = "Input_ThresholdPercentage";
            Input_ThresholdPercentage.PlaceholderText = "Threshold %";
            Input_ThresholdPercentage.Size = new Size(130, 23);
            Input_ThresholdPercentage.TabIndex = 28;
            // 
            // Input_CRating
            // 
            Input_CRating.Location = new Point(315, 237);
            Input_CRating.Name = "Input_CRating";
            Input_CRating.PlaceholderText = "C-Rating, (NOT WORKING)";
            Input_CRating.Size = new Size(130, 23);
            Input_CRating.TabIndex = 32;
            // 
            // UpdatedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 768);
            Controls.Add(Input_CRating);
            Controls.Add(Label_ThresholdTime);
            Controls.Add(Label_ThresholdPercentage);
            Controls.Add(Input_ThresholdTime);
            Controls.Add(Input_ThresholdPercentage);
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
        private Label Label_ThresholdTime;
        private Label Label_ThresholdPercentage;
        private TextBox Input_ThresholdTime;
        private TextBox Input_ThresholdPercentage;
        private TextBox Input_CRating;
    }
}