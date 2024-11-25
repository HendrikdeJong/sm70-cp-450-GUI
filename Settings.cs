using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sm70_cp_450_GUI
{
    public class Settings
    {
        public double BulkVoltage { get; set; }
        public double MinimumVoltage { get; set; }
        public double Capacity { get; set; }
        public double MaxCurrent { get; set; }
        public double MinCurrent { get; set; }
        public double MaxPower { get; set; }
        public double MinPower { get; set; }
        public double ExpectedSoc { get; set; }
        public double TriggerPercent { get; set; }
        public double TriggerPercentValue { get; set; }
        public TimeSpan TriggerTime { get; set; }
    }
}
