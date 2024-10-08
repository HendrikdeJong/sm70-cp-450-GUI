﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sm70_cp_450_GUI.MainForm;

namespace sm70_cp_450_GUI
{
    public class LogManager
    {
        private static LogManager? _instance;

        private int _currentErrorIndex = 0;  // Index to cycle through errors
        private int _errorDisplayCounter = 0;  // Counter for slower error display
        private readonly int _errorDisplayInterval = 10;  // Change this to set slower rate (e.g., 10 ticks = 10 seconds)

        // Private constructor to prevent direct instantiation
        private LogManager() { }
        public static LogManager Instance{get{_instance ??= new LogManager();return _instance;}}

        // Define a delegate for the log update event
        public delegate void LogUpdateEventHandler(string logMessage);

        // Define an event based on the delegate
        public event LogUpdateEventHandler? OnLogUpdate;

        public Dictionary<string, (int Count, DateTime LastOccurred)> _errorMessages = new();
        public Dictionary<string, (int Count, DateTime LastOccurred)> _infoMessages = new();
        public List<BatteryMetrics> batteryData = new();
        public class BatteryMetrics
        {
            public DateTime Time { get; set; }
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double Power { get; set; }
        }

        public void AddDebugLogMessage(string LogMessage)
        {
            DateTime currentTime = DateTime.Now;

            if (LogMessage.Contains('❌') || LogMessage.Contains("[ERROR]"))
            {
                _errorMessages[LogMessage] = _errorMessages.ContainsKey(LogMessage)
                    ? (_errorMessages[LogMessage].Count + 1, currentTime)
                    : (1, currentTime);
                LogErrorBasedOnConsoleState();  // Updated to conditionally update based on console state
            }

            _infoMessages[LogMessage] = _infoMessages.ContainsKey(LogMessage)
                ? (_infoMessages[LogMessage].Count + 1, currentTime)
                : (1, currentTime);
        }

        public void LogErrorBasedOnConsoleState()
        {
            if(MainForm.Instance != null)
            {
                if (MainForm.Instance._ConsoleState)  // Console is open
                {
                    UpdateConsole();  // Send detailed, multiline errors to the console textbox.
                }
                else  // Console is closed
                {
                    DisplaySingleErrorInLabel();  // Show one error every 2 seconds on a label.
                }
            }
        }

        // Update multiline error messages in the console
        public void UpdateConsole()
        {
            StringBuilder sb = new();
            DateTime now = DateTime.Now;

            // Remove errors that have expired
            List<string> expiredErrors = _errorMessages
                .Where(e => (now - e.Value.LastOccurred).TotalSeconds > 10)
                .Select(e => e.Key)
                .ToList();

            foreach (string? errorKey in expiredErrors)
            {
                _errorMessages.Remove(errorKey);
            }

            // Show all remaining errors sorted by last occurrence
            var sortedErrors = _errorMessages.OrderByDescending(e => e.Value.LastOccurred);
            foreach (var error in sortedErrors)
            {
                string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                sb.AppendLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
            }

            // Trigger an update to the UI with the log messages
            OnLogUpdate?.Invoke(sb.ToString());
        }

        // Show a single error on the label (simplified for closed console)
        public void DisplaySingleErrorInLabel()
        {
            if (MainForm.Instance != null)
            {
                _errorDisplayCounter++;
                if (_errorDisplayCounter >= _errorDisplayInterval)
                {
                    if (_errorMessages.Count > 0)
                    {
                        // Ensure the index wraps around if it exceeds the number of errors
                        if (_currentErrorIndex >= _errorMessages.Count)
                        {
                            _currentErrorIndex = 0;  // Reset the index to loop back to the start
                        }

                        // Get the error at the current index
                        var error = _errorMessages.ElementAt(_currentErrorIndex);

                        // Truncate the error message if it's too long
                        string truncatedError = TruncateMessage(error.Key, 40);
                        MainForm.Instance.Console_Short_ErrorLabel.Text = $"{truncatedError}";  // Update the label

                        // Move to the next error for the next update
                        _currentErrorIndex++;
                    }
                    _errorDisplayCounter = 0;
                }
            }
        }
        public void CollectBatteryMetrics(double V, double C, double P)
        {
            BatteryMetrics metrics = new()
            {
                Time = DateTime.Now,
                Voltage = V,
                Current = C,
                Power = P,
            };
            batteryData.Add(metrics);
        }

        public void ExportToCsv(bool SaveAs, string? saveLocation)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Save Battery Data",
                FileName = "battery_data.csv"
            };

            if (SaveAs)
            {
                // Show the dialog and check if the user clicks OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Write the CSV file
                    using StreamWriter writer = new(filePath);
                    writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                    foreach (BatteryMetrics data in batteryData)
                    {
                        writer.WriteLine($"{data.Time},{Math.Round((data.Voltage / 10000), 3)} V,{Math.Round((data.Current / 1000), 3)} A,{data.Power} W");  // Data rows
                    }
                }
            }
            else if (!SaveAs && saveLocation != null)
            {
                // Ensure the folder exists
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }

                // Append current time to the file name
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");
                string fileNameWithTime = $"battery_data_{timestamp}.csv";
                string filePath = Path.Combine(saveLocation, fileNameWithTime);

                // Write the CSV file
                using StreamWriter writer = new(filePath);
                writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                foreach (BatteryMetrics data in batteryData)
                {
                    writer.WriteLine($"{data.Time},{Math.Round((data.Voltage / 10000), 3)} V,{Math.Round((data.Current / 1000), 3)} A,{data.Power} W");  // Data rows
                }
            }
        }

        public void ExportLogToFile(bool SaveAs, string? saveLocation)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save Log File",
                FileName = "log.txt"
            };

            if (SaveAs)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using StreamWriter writer = new(filePath);
                    writer.WriteLine("Error Log:");
                    foreach (var error in _errorMessages.OrderByDescending(e => e.Value.LastOccurred))
                    {
                        string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
                    }

                    writer.WriteLine("\nInfo/Warning Log:");
                    foreach (var info in _infoMessages.OrderByDescending(i => i.Value.LastOccurred))
                    {
                        string formattedTime = info.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                        writer.WriteLine($"{formattedTime} - {info.Key} (Count: {info.Value.Count})");
                    }
                }
            }
            else if (!SaveAs && saveLocation != null)
            {
                // Ensure the folder exists
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }

                // Append current time to the file name
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");
                string fileNameWithTime = $"log_{timestamp}.txt";
                string filePath = Path.Combine(saveLocation, fileNameWithTime);

                using StreamWriter writer = new(filePath);
                writer.WriteLine("Error Log:");
                foreach (var error in _errorMessages.OrderByDescending(e => e.Value.LastOccurred))
                {
                    string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                    writer.WriteLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
                }

                writer.WriteLine("\nInfo/Warning Log:");
                foreach (var info in _infoMessages.OrderByDescending(i => i.Value.LastOccurred))
                {
                    string formattedTime = info.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                    writer.WriteLine($"{formattedTime} - {info.Key} (Count: {info.Value.Count})");
                }
            }
        }
        private void SaveSettings(object sender, EventArgs e)
        {
            if(MainForm.Instance == null)
            {
                return;
            }
            SaveFileDialog? saveFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Save as .txt file
                Title = "Save Factory Settings",
                FileName = "factory_settings.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (StreamWriter? writer = new(filePath))
                {
                    // Save the settings in comma-separated format (CSV-like)
                    writer.WriteLine($"{MainForm.Instance._CutOffDischargeVoltage},{MainForm.Instance._MaxChargeVoltage},{MainForm.Instance._MaxCurrent},{MainForm.Instance._MaxPower},{MainForm.Instance._MinCurrent},{MainForm.Instance._MinPower}");
                }

                _ = MessageBox.Show("Settings successfully saved to " + filePath);
            }
        }
        //private void LoadSettings(object sender, EventArgs e)
        //{
        //    OpenFileDialog? openFileDialog = new()
        //    {
        //        Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Load from .txt file
        //        Title = "Load Factory Settings"
        //    };

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        string filePath = openFileDialog.FileName;

        //        using StreamReader? reader = new(filePath);
        //        string? line = reader.ReadLine();
        //        if (!string.IsNullOrEmpty(line))
        //        {
        //            // Split the values by comma
        //            string[] values = line.Split(',');

        //            if (values.Length == 5)
        //            {
        //                _StoredVoltageSetting = double.Parse(values[0]);
        //                _StoredCurrent = double.Parse(values[1]);
        //                _StoredPower = double.Parse(values[2]);
        //                _StoredNegativeCurrent = double.Parse(values[3]);
        //                _StoredNegativePower = double.Parse(values[4]);

        //                // Populate the UI fields with the loaded values
        //                InputField_StoredValueVoltage.Text = _StoredVoltageSetting.ToString() + " V";
        //                InputField_StoredValueCurrentPlus.Text = _StoredCurrent.ToString() + " A";
        //                InputField_StoredValuePowerPlus.Text = _StoredPower.ToString() + " W";
        //                InputField_StoredValueCurrentMin.Text = "-" + Math.Abs(_StoredNegativeCurrent).ToString() + " A";
        //                InputField_StoredValuePowerMin.Text = "-" + Math.Abs(_StoredNegativePower).ToString() + " W";

        //                _ = MessageBox.Show("Settings successfully loaded from " + filePath);
        //            }
        //            else
        //            {
        //                _ = MessageBox.Show("Error: Incorrect format in the settings file.");
        //            }
        //        }
        //    }
        //}


        private static string TruncateMessage(string errorMessage, int TruncateLength)
        {
            if (errorMessage.Length > TruncateLength)
            {
                return $"{errorMessage[..TruncateLength]}...";
            }
            return errorMessage;
        }
    }

}
