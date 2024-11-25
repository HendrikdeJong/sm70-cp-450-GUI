using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                _instance ??= new LogManager();
                return _instance;
            }
        }

        // Define a delegate for the log update event
        public delegate void LogUpdateEventHandler(List<LogEntry> logEntries);
        public event LogUpdateEventHandler? OnLogUpdate;

        // List to store log entries
        public List<LogEntry> _logEntries = new();

        public class LogEntry
        {
            public enum LogType { Info, Error }

            public DateTime Time { get; set; }
            public string Message { get; set; }
            public LogType Type { get; set; }
            public Color DisplayColor { get; set; }
            public int Count { get; set; }

            public LogEntry(string message, LogType type)
            {
                Time = DateTime.Now;
                Message = message;
                Type = type;
                DisplayColor = type == LogType.Error ? Color.Red : Color.Black;
                Count = 1;
            }
        }

        // Inner BatteryMetrics class to store metrics data
        public class BatteryMetrics
        {
            public DateTime Time { get; set; }
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double Power { get; set; }
            public int Soc { get; set; }
        }

        // List to store battery metrics data
        public List<BatteryMetrics> batteryData = new();

        // Method to add battery metrics
        public void CollectBatteryMetrics(double voltage, double current, double power, int soc)
        {
            BatteryMetrics metrics = new()
            {
                Time = DateTime.Now,
                Voltage = voltage,
                Current = current,
                Power = power,
                Soc = soc,
            };
            batteryData.Add(metrics);
        }

        // Method to add info messages
        public void AddInfoLogMessage(string message)
        {
            AddLogMessage(message, LogEntry.LogType.Info);
        }

        // Method to add error messages
        public void AddErrorLogMessage(string message)
        {
            AddLogMessage(message, LogEntry.LogType.Error);
        }

        // General method to add a log message
        private void AddLogMessage(string message, LogEntry.LogType type)
        {
            var existingLog = _logEntries.FirstOrDefault(log => log.Message == message && log.Type == type);
            if (existingLog != null)
            {
                // Update the existing log entry
                existingLog.Count++;
                existingLog.Time = DateTime.Now;
            }
            else
            {
                // Add a new log entry
                _logEntries.Add(new LogEntry(message, type));
            }

            // Update the console to reflect all messages
            UpdateConsole();
        }

        // Update multiline error and information messages in the console
        private void UpdateConsole()
        {
            DateTime now = DateTime.Now;

            // Remove expired error logs (older than 10 seconds)
            _logEntries.RemoveAll(log => log.Type == LogEntry.LogType.Error && (now - log.Time).TotalSeconds > 10);

            // Sort logs by most recent occurrence
            var sortedLogs = _logEntries.OrderByDescending(log => log.Time).ToList();

            // Trigger an update to the UI with all log messages
            OnLogUpdate?.Invoke(sortedLogs);
        }

        public void ExportToCsv(bool saveAs, string? saveLocation)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Save Battery Data",
                FileName = "battery_data.csv"
            };

            if (saveAs)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using StreamWriter writer = new(filePath);
                    writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                    foreach (var data in batteryData)
                    {
                        writer.WriteLine($"{data.Time},{Math.Round((data.Voltage / 10000), 3)} V,{Math.Round((data.Current / 1000), 3)} A,{data.Power} W, {data.Soc} %");  // Data rows
                    }
                }
            }
            else if (!saveAs && saveLocation != null)
            {
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");
                string fileNameWithTime = $"battery_data_{timestamp}.csv";
                string filePath = Path.Combine(saveLocation, fileNameWithTime);

                using StreamWriter writer = new(filePath);
                writer.WriteLine("Time,Voltage,Current,Power");  // CSV header
                foreach (var data in batteryData)
                {
                    writer.WriteLine($"{data.Time},{Math.Round((data.Voltage / 10000), 3)} V,{Math.Round((data.Current / 1000), 3)} A,{data.Power} W, {data.Soc} %");  // Data rows
                }
            }
        }

        public void ExportLogToFile(bool saveAs, string? saveLocation)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save Log File",
                FileName = "log.txt"
            };

            if (saveAs)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using StreamWriter writer = new(filePath);
                    WriteLogsToWriter(writer);
                }
            }
            else if (!saveAs && saveLocation != null)
            {
                if (!Directory.Exists(saveLocation))
                {
                    Directory.CreateDirectory(saveLocation);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmm");
                string fileNameWithTime = $"log_{timestamp}.txt";
                string filePath = Path.Combine(saveLocation, fileNameWithTime);

                using StreamWriter writer = new(filePath);
                WriteLogsToWriter(writer);
            }
        }


        public void ExportSettings(bool saveAs, string? saveLocation)
        {
            
        }

        public void ImportSettings(string filename)
        {

        }

        private void WriteLogsToWriter(StreamWriter writer)
        {
            foreach (var log in _logEntries.OrderByDescending(log => log.Time))
            {
                string formattedTime = log.Time.ToString("HH:mm:ss");
                writer.WriteLine($"{formattedTime} - {log.Message} (Count: {log.Count})");
            }
        }
    }
}
