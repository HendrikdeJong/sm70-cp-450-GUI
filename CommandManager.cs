using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sm70_cp_450_GUI
{
    public class CommandManager
    {

        private static CommandManager? _instance;
        private readonly TcpConnectionHandler _tcpHandler;
        private readonly LogManager _logManager;

        private CommandManager()
        {
            _logManager = LogManager.Instance;
            _tcpHandler = TcpConnectionHandler.Instance;
        }


        public static CommandManager Instance
        {
            get
            {
                _instance ??= new CommandManager();
                return _instance;
            }
        }

        //public bool IsConnectionEstablished()
        //{
        //    if (!_tcpHandler.IsConnected)
        //    {
        //        _logManager.AddDebugLogMessage("❌ TCP connection is not established.");
        //        return false;
        //    }
        //    return true;
        //}

        #region queries

        public void Request_Measure_Voltage()
        {

            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:VOLtage?");
            _tcpHandler.EnqueueQuery("MEASure:VOLtage?");
        }

        public void Request_Measure_Current()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:CURrent?");
            _tcpHandler.EnqueueQuery("MEASure:CURrent?");
        }

        public void Request_Measure_Power()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:POWer?");
            _tcpHandler.EnqueueQuery("MEASure:POWer?");
        }

        public void Request_Source_Voltage()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SOURce:VOLtage?");
            _tcpHandler.EnqueueQuery("SOURce:VOLtage?");
        }

        public void Request_Source_Current()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SOURce:CURrent?");
            _tcpHandler.EnqueueQuery("SOURce:CURrent?");
        }

        public void Request_Source_Current_Negative()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SOURce:CURrent:NEGative?");
            _tcpHandler.EnqueueQuery("SOURce:CURrent:NEGative?");
        }

        public void Request_Source_Power()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SOURce:POWer?");
            _tcpHandler.EnqueueQuery("SOURce:POWer?");
        }

        public void Request_Source_Power_Negative()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SOURce:POWer:NEGative?");
            _tcpHandler.EnqueueQuery("SOURce:POWer:NEGative?");
        }

        public void RequestRemoteSetting_CV()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:REMote:CV?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CV?");
        }

        public void RequestRemoteSetting_CC()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:REMote:CC?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CC?");
        }

        public void RequestRemoteSetting_CP()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:REMote:CP?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CP?");
        }

        public void RequestTime()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:TIMe?");
            _tcpHandler.EnqueueQuery("SYSTem:TIMe?");
        }

        public void RequestInstrumentCurrentPOS()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:INStrument AH,POS,TOTAL?");
            _tcpHandler.EnqueueQuery("MEASure:INStrument AH,POS,TOTAL?");
        }
        public void RequestInstrumentCurrentNEG()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:INStrument AH,NEG,TOTAL?");
            _tcpHandler.EnqueueQuery("MEASure:INStrument AH,NEG,TOTAL?");
        }
        public void RequestInstrumentTime()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: MEASure:INStrument AH,TIMESEC?");
            _tcpHandler.EnqueueQuery("MEASure:INStrument AH,TIMESEC?");
        }

        internal void RequestSystemVoltageLimit()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:LIMits:VOLtage?");
            _tcpHandler.EnqueueQuery("SYSTem:LIMits:VOLtage?");
        }

        internal void RequestSystemCurrentLimit()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:LIMits:CURrent?");
            _tcpHandler.EnqueueQuery("SYSTem:LIMits:CURrent?");
        }

        internal void RequestSystemPowerLimit()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:LIMits:POWer?");
            _tcpHandler.EnqueueQuery("SYSTem:LIMits:POWer?");
        }

        internal void RequestSystemNegCurrentLimit()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:LIMits:CURrent:NEGative?");
            _tcpHandler.EnqueueQuery("SYSTem:LIMits:CURrent:NEGative?");
        }

        internal void RequestSystemNegPowerLimit()
        {
            _logManager.AddDebugLogMessage("⚠️ trying to enqueueQuery: SYSTem:LIMits:POWer:NEGative?");
            _tcpHandler.EnqueueQuery("SYSTem:LIMits:POWer:NEGative?");
        }

        #endregion













        #region commands

        public void SetSystemRemoteSetting_CV(string state)
        {
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SYSTem:REMote:CV {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CV {state}");
        }

        public void SetSystemRemoteSetting_CC(string state)
        {
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SYSTem:REMote:CC {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CC {state}");
        }

        public void SetSystemRemoteSetting_CP(string state)
        {
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SYSTem:REMote:CP {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CP {state}");
        }

        public void SetOutputVoltage(double outputVoltage)
        {
            string String = outputVoltage.ToString().Replace(',', '.');
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SOURce:VOLtage {String}");
            _tcpHandler.EnqueueCommand($"SOURce:VOLtage {String}");
        }

        public void SetOutputCurrent(double outputCurrent)
        {
            string String = outputCurrent.ToString().Replace(',', '.');
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SOURce:CURrent {String}");
            _tcpHandler.EnqueueCommand($"SOURce:CURrent {String}");
        }

        public void SetOutputCurrentNegative(double outputCurrentNegative)
        {
            string String = (-Math.Abs(outputCurrentNegative)).ToString().Replace(',', '.');
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SOURce:CURrent:NEGative {String} ");
            _tcpHandler.EnqueueCommand($"SOURce:CURrent:NEGative {String}");
        }

        public void SetOutputPower(double outputPower)
        {
            string String = outputPower.ToString().Replace(',', '.');
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SOURce:POWer {String}");
            _tcpHandler.EnqueueCommand($"SOURce:POWer {String}");
        }

        public void SetOutputPowerNegative(double outputPowerNegative)
        {
            string String = (-Math.Abs(outputPowerNegative)).ToString().Replace(',', '.');
            _logManager.AddDebugLogMessage($"⚠️ trying to enqueue command: SOURce:POWer:NEGative {String}");
            _tcpHandler.EnqueueCommand($"SOURce:POWer:NEGative {String}");
        }

        public void SetOutputState(bool v)
        {
            _tcpHandler.EnqueueCommand(v ? "OUTPut ON" : "OUTPut OFF");
        }

        #endregion

    }
}
