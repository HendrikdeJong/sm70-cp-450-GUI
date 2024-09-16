using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sm70_cp_450_GUI.BatteryManager;
using static sm70_cp_450_GUI.MainForm;

namespace sm70_cp_450_GUI
{
    public class LogManager
    {
        private static LogManager? _instance;

        // Private constructor to prevent direct instantiation
        private LogManager() { }

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogManager();
                }
                return _instance;
            }
        }

        // Define a delegate for the log update event
        public delegate void LogUpdateEventHandler(string logMessage);

        // Define an event based on the delegate
        public event LogUpdateEventHandler? OnLogUpdate;

        public Dictionary<string, (int Count, DateTime LastOccurred)> _errorMessages = new();
        public Dictionary<string, (int Count, DateTime LastOccurred)> _infoMessages = new();
        public List<BatteryMetrics> batteryData = new();

        public void AddDebugLogMessage(string LogMessage)
        {
            DateTime currentTime = DateTime.Now;

            if (LogMessage.Contains("[ERROR]"))
            {
                _errorMessages[LogMessage] = _errorMessages.ContainsKey(LogMessage)
                    ? (_errorMessages[LogMessage].Count + 1, currentTime)
                    : (1, currentTime);
                UpdateConsole();  // Call the method to update the console log
            }

            _infoMessages[LogMessage] = _infoMessages.ContainsKey(LogMessage)
                ? (_infoMessages[LogMessage].Count + 1, currentTime)
                : (1, currentTime);
        }

        public void UpdateConsole()
        {
            StringBuilder sb = new();
            DateTime now = DateTime.Now;

            List<string> expiredErrors = _errorMessages
                .Where(e => (now - e.Value.LastOccurred).TotalSeconds > 10)
                .Select(e => e.Key)
                .ToList();

            foreach (string? errorKey in expiredErrors)
            {
                _errorMessages.Remove(errorKey);
            }

            var sortedErrors = _errorMessages.OrderByDescending(e => e.Value.LastOccurred);
            foreach (var error in sortedErrors)
            {
                string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                sb.AppendLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
            }

            // Raise the event to notify listeners (MainForm) to update the UI
            OnLogUpdate?.Invoke(sb.ToString());
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

        public void ExportToCsv(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Save Battery Data",
                FileName = "battery_data.csv"
            };

            // Show the dialog and check if the user clicks OK
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path selected by the user
                string filePath = saveFileDialog.FileName;

                // Write the CSV file
                using StreamWriter writer = new(filePath);
                writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                foreach (BatteryMetrics data in batteryData)
                {
                    writer.WriteLine($"{data.Time},{Math.Round((data.Voltage / 10000),3)} V,{Math.Round((data.Current / 1000),3)} A,{data.Power} W");  // Data rows
                }

                //MessageBox.Show("Data successfully saved to " + filePath);
            }
            else
            {
                //_ = MessageBox.Show("Save operation was canceled.");
            }
        }


        public void ExportLogToFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",  // Log file format
                Title = "Save Log File",
                FileName = "log.txt"  // Default file name
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using StreamWriter writer = new(filePath);
                writer.WriteLine("Error Log:");
                foreach (KeyValuePair<string, (int Count, DateTime LastOccurred)> error in _errorMessages.OrderByDescending(e => e.Value.LastOccurred))
                {
                    string formattedTime = error.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                    writer.WriteLine($"{formattedTime} - {error.Key} (Count: {error.Value.Count})");
                }

                writer.WriteLine("\nInfo/Warning Log:");
                foreach (KeyValuePair<string, (int Count, DateTime LastOccurred)> info in _infoMessages.OrderByDescending(i => i.Value.LastOccurred))
                {
                    string formattedTime = info.Value.LastOccurred.ToString("yyyy-MM-dd HH:mm:ss");
                    writer.WriteLine($"{formattedTime} - {info.Key} (Count: {info.Value.Count})");
                }

                //MessageBox.Show("Log file successfully saved to " + filePath);
            }
            else
            {
                //_ = MessageBox.Show("Save operation was canceled.");
            }
        }

    }

}
