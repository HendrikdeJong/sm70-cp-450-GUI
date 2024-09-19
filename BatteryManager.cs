using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sm70_cp_450_GUI
{
    public class BatteryManager
    {
        private static BatteryManager? _instance;

        // Private constructor
        private BatteryManager()
        {
            BatteryData = new List<BatteryMetrics>();

        }

        // Access the BatteryManager instance
        public static BatteryManager Instance
        {
            get
            {
                _instance ??= new BatteryManager();
                return _instance;
            }
        }


        public class BatteryMetrics
        {
            public DateTime Time { get; set; }
            public double Voltage { get; set; }
            public double Current { get; set; }
            public double Power { get; set; }
        }


        public double RatedVoltage { get; private set; }
        public double RatedCapacity { get; private set; }
        public double CRating { get; private set; }
        public double RatedPower { get; private set; }
        public TimeSpan EstimateTime { get; private set; }

        public List<BatteryMetrics> BatteryData { get; private set; }


        // Store the current battery settings
        public void SetBatterySettings(double ratedVoltage, double ratedCapacity, double cRating)
        {
            RatedVoltage = ratedVoltage;
            RatedCapacity = ratedCapacity;
            CRating = cRating;
            RatedPower = RatedCapacity * CRating * RatedVoltage;
        }

        // Collect battery metrics
        public void CollectBatteryMetrics(double currentVoltage, double currentCurrent, double currentPower)
        {
            var metrics = new BatteryMetrics
            {
                Time = DateTime.Now,
                Voltage = currentVoltage,
                Current = currentCurrent,
                Power = currentPower
            };
            BatteryData.Add(metrics);
        }

        // Save settings to Properties
        public void SaveSettings(double storedVoltage, double storedCurrent, double storedPower, double storedNegativeCurrent, double storedNegativePower)
        {
            Properties.Settings.Default._StoredVoltageSetting = storedVoltage;
            Properties.Settings.Default._StoredCurrent = storedCurrent;
            Properties.Settings.Default._StoredPower = storedPower;
            Properties.Settings.Default._StoredNegativeCurrent = storedNegativeCurrent;
            Properties.Settings.Default._StoredNegativePower = storedNegativePower;

            Properties.Settings.Default._ratedVoltage = RatedVoltage;
            Properties.Settings.Default._ratedCapacity = RatedCapacity;
            Properties.Settings.Default._cRating = CRating;
            Properties.Settings.Default._ratedPower = RatedPower;

            Properties.Settings.Default.Save();
        }

        public TimeSpan CalculateTimeEstimate(double Percentage)
        {
            if (RatedCapacity <= 0 || CRating <= 0)
            {
                MessageBox.Show("Invalid rated capacity or C-rating. Please check your battery settings.");
                return TimeSpan.Zero;
            }

            double Current = RatedCapacity * CRating;

            if (Current <= 0)
            {
                MessageBox.Show("Current is zero or invalid.");
                return TimeSpan.Zero;
            }

            double fullDischargeTimeHours = RatedCapacity / Current;

            if (double.IsNaN(fullDischargeTimeHours) || fullDischargeTimeHours <= 0)
            {
                MessageBox.Show("Calculated time is invalid.");
                return TimeSpan.Zero;
            }


            EstimateTime = TimeSpan.FromHours(fullDischargeTimeHours * (Percentage / 100));
            return EstimateTime;
        }
    }
}

