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
            Button_Reset = new Button();
            Button_Start = new Button();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            Label_Capacity = new Label();
            Label_BulkVolt = new Label();
            Label_MinVolt = new Label();
            Label_MaxCurr = new Label();
            Label_Procent = new Label();
            Label_LiveVoltage = new Label();
            Label_LiveCurrent = new Label();
            Label_TriggerTime = new Label();
            Label_TriggerThreshold = new Label();
            Input_TriggerTime = new TextBox();
            Input_TriggerThreshold = new TextBox();
            Input_CRating = new TextBox();
            Input_Watt = new TextBox();
            Label_Status = new Label();
            checkBox1 = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox5 = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ProgressBar_Trigger = new ProgressBar();
            label1 = new Label();
            flowLayoutPanel1.SuspendLayout();
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
            // Button_Reset
            // 
            Button_Reset.Location = new Point(272, 410);
            Button_Reset.Name = "Button_Reset";
            Button_Reset.Size = new Size(78, 23);
            Button_Reset.TabIndex = 11;
            Button_Reset.Text = "Reset";
            Button_Reset.UseVisualStyleBackColor = true;
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
            Label_Capacity.Location = new Point(36, 153);
            Label_Capacity.Name = "Label_Capacity";
            Label_Capacity.Size = new Size(53, 15);
            Label_Capacity.TabIndex = 21;
            Label_Capacity.Text = "Capacity";
            // 
            // Label_BulkVolt
            // 
            Label_BulkVolt.AutoSize = true;
            Label_BulkVolt.Location = new Point(36, 182);
            Label_BulkVolt.Name = "Label_BulkVolt";
            Label_BulkVolt.Size = new Size(72, 15);
            Label_BulkVolt.TabIndex = 22;
            Label_BulkVolt.Text = "Bulk Voltage";
            // 
            // Label_MinVolt
            // 
            Label_MinVolt.AutoSize = true;
            Label_MinVolt.Location = new Point(36, 211);
            Label_MinVolt.Name = "Label_MinVolt";
            Label_MinVolt.Size = new Size(86, 15);
            Label_MinVolt.TabIndex = 23;
            Label_MinVolt.Text = "Cut off voltage";
            // 
            // Label_MaxCurr
            // 
            Label_MaxCurr.AutoSize = true;
            Label_MaxCurr.Location = new Point(36, 240);
            Label_MaxCurr.Name = "Label_MaxCurr";
            Label_MaxCurr.Size = new Size(71, 15);
            Label_MaxCurr.TabIndex = 24;
            Label_MaxCurr.Text = "max current";
            // 
            // Label_Procent
            // 
            Label_Procent.AutoSize = true;
            Label_Procent.Location = new Point(36, 269);
            Label_Procent.Name = "Label_Procent";
            Label_Procent.Size = new Size(137, 15);
            Label_Procent.TabIndex = 25;
            Label_Procent.Text = "Disired state of charge %";
            // 
            // Label_LiveVoltage
            // 
            Label_LiveVoltage.AutoSize = true;
            Label_LiveVoltage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_LiveVoltage.Location = new Point(36, 99);
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
            // Label_TriggerTime
            // 
            Label_TriggerTime.AutoSize = true;
            Label_TriggerTime.Location = new Point(36, 327);
            Label_TriggerTime.Name = "Label_TriggerTime";
            Label_TriggerTime.Size = new Size(128, 15);
            Label_TriggerTime.TabIndex = 31;
            Label_TriggerTime.Text = "Trigger time stopwatch";
            // 
            // Label_TriggerThreshold
            // 
            Label_TriggerThreshold.AutoSize = true;
            Label_TriggerThreshold.Location = new Point(36, 298);
            Label_TriggerThreshold.Name = "Label_TriggerThreshold";
            Label_TriggerThreshold.Size = new Size(118, 15);
            Label_TriggerThreshold.TabIndex = 30;
            Label_TriggerThreshold.Text = "Trigger Threshhold %";
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
            // Input_Watt
            // 
            Input_Watt.Location = new Point(315, 150);
            Input_Watt.Name = "Input_Watt";
            Input_Watt.PlaceholderText = "max watt, norm5000";
            Input_Watt.Size = new Size(130, 23);
            Input_Watt.TabIndex = 39;
            // 
            // Label_Status
            // 
            Label_Status.AutoSize = true;
            Label_Status.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Label_Status.Location = new Point(179, 436);
            Label_Status.Name = "Label_Status";
            Label_Status.Size = new Size(123, 21);
            Label_Status.TabIndex = 42;
            Label_Status.Text = "Status: Charging";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 53);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(106, 19);
            checkBox1.TabIndex = 48;
            checkBox1.Text = "Done Charging";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(checkBox3);
            flowLayoutPanel1.Controls.Add(checkBox4);
            flowLayoutPanel1.Controls.Add(checkBox1);
            flowLayoutPanel1.Controls.Add(checkBox2);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(475, 150);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(213, 370);
            flowLayoutPanel1.TabIndex = 49;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(3, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(92, 19);
            checkBox3.TabIndex = 50;
            checkBox3.Text = "Values saved";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(3, 28);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(172, 19);
            checkBox4.TabIndex = 51;
            checkBox4.Text = "Voltage is up to bulkvoltage";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(3, 78);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(120, 19);
            checkBox2.TabIndex = 49;
            checkBox2.Text = "Done Discharging";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(475, 554);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(115, 19);
            checkBox5.TabIndex = 52;
            checkBox5.Text = "Trigger threshold";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(312, 593);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 44;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(312, 608);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 45;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(312, 623);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 46;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(312, 638);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 47;
            label5.Text = "label5";
            // 
            // ProgressBar_Trigger
            // 
            ProgressBar_Trigger.Location = new Point(475, 526);
            ProgressBar_Trigger.Name = "ProgressBar_Trigger";
            ProgressBar_Trigger.Size = new Size(213, 22);
            ProgressBar_Trigger.TabIndex = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(312, 578);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 53;
            label1.Text = "label1";
            // 
            // UpdatedForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(727, 768);
            Controls.Add(label1);
            Controls.Add(ProgressBar_Trigger);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(checkBox5);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Label_Status);
            Controls.Add(Input_Watt);
            Controls.Add(Input_CRating);
            Controls.Add(Label_TriggerTime);
            Controls.Add(Label_TriggerThreshold);
            Controls.Add(Input_TriggerTime);
            Controls.Add(Input_TriggerThreshold);
            Controls.Add(Label_LiveCurrent);
            Controls.Add(Label_LiveVoltage);
            Controls.Add(Label_Procent);
            Controls.Add(Label_MaxCurr);
            Controls.Add(Label_MinVolt);
            Controls.Add(Label_BulkVolt);
            Controls.Add(Label_Capacity);
            Controls.Add(Button_Start);
            Controls.Add(Button_Reset);
            Controls.Add(Button_Stop);
            Controls.Add(Button_Save);
            Controls.Add(Input_Procent);
            Controls.Add(Input_CutoffVoltage);
            Controls.Add(Input_BulkVoltage);
            Controls.Add(Input_MaxAmps);
            Controls.Add(Input_Capacity);
            Name = "UpdatedForm";
            Text = "UpdatedForm";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
        private Button Button_Reset;
        private Button Button_Start;
        private System.Windows.Forms.Timer UpdateTimer;
        private Label Label_Capacity;
        private Label Label_BulkVolt;
        private Label Label_MinVolt;
        private Label Label_MaxCurr;
        private Label Label_Procent;
        private Label Label_LiveVoltage;
        private Label Label_LiveCurrent;
        private Label Label_TriggerTime;
        private Label Label_TriggerThreshold;
        private TextBox Input_TriggerTime;
        private TextBox Input_TriggerThreshold;
        private TextBox Input_CRating;
        private TextBox Input_Watt;
        private Label Label_Status;
        private CheckBox checkBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ProgressBar ProgressBar_Trigger;
        private Label label1;
    }
}