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
        private CommandManager _commandManager;

        // Private constructor
        private BatteryManager()
        {
            _commandManager = CommandManager.Instance;
            BatteryData = new List<BatteryMetrics>();

        }

        // Access the BatteryManager instance
        public static BatteryManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BatteryManager();
                }
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
        public TimeSpan TimeToDischarge30Percent { get; private set; }

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

        // Function to calculate time to discharge to 30%
        public TimeSpan CalculateDischargeTimeTo30Percent()
        {
            if (RatedCapacity <= 0 || CRating <= 0)
            {
                throw new InvalidOperationException("Invalid rated capacity or C-rating. Please check your battery settings.");
            }

            double dischargeCurrent = RatedCapacity * CRating;

            if (dischargeCurrent <= 0)
            {
                throw new InvalidOperationException("Discharge current is zero or invalid.");
            }

            double fullDischargeTimeHours = RatedCapacity / dischargeCurrent;

            if (double.IsNaN(fullDischargeTimeHours) || fullDischargeTimeHours <= 0)
            {
                throw new InvalidOperationException("Calculated discharge time is invalid.");
            }

            // Time to discharge to 30% (70% of the full discharge time)
            TimeToDischarge30Percent = TimeSpan.FromHours(fullDischargeTimeHours * 0.70);
            return TimeToDischarge30Percent;
        }
    }
}

