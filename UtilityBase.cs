using System.Data;
using System.Diagnostics;

namespace sm70_cp_450_GUI
{
    public static class UtilityBase
    {
        public static bool IsApproximatelyEqual(double value1, double value2, double value3 = 0.1)
        {
            double difference = Math.Abs(value1 - value2);
            return difference <= value3;
        }

        public static void OpenURL(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    _ = Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show($"Unable to open the browser. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static double ParseInput(string input)
        {
            return double.TryParse(RemoveNonNumeric(input), out double result) ? result : 0;
        }

        public static string RemoveNonNumeric(string input)
        {
            return new string(input.Where(c => char.IsDigit(c) || c == '.' || c == '-' || c == ',' || c == '~').ToArray());
        }
    }
}