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
        private static CommandManager _instance;
        private TcpConnectionHandler _tcpHandler;
        private LogManager _logManager;

        // Private constructor
        private CommandManager()
        {
            _logManager = LogManager.Instance;
            _tcpHandler = TcpConnectionHandler.Instance;
        }


        // Access the CommandManager instance
        public static CommandManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommandManager();
                }
                return _instance;
            }
        }

        public bool IsConnectionEstablished()
        {
            if (!_tcpHandler.IsConnected)
            {
                _logManager.AddDebugLogMessage("[ERROR] TCP connection is not established.");
                return false;
            }
            return true;
        }

        public void Request_Measure_Voltage()
        {
            //if (!IsConnectionEstablished()) return;

            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: MEASure:VOLtage?");
            _tcpHandler.EnqueueQuery("MEASure:VOLtage?");
        }

        public void Request_Measure_Current()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: MEASure:CURrent?");
            _tcpHandler.EnqueueQuery("MEASure:CURrent?");
        }

        public void Request_Measure_Power()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: MEASure:POWer?");
            _tcpHandler.EnqueueQuery("MEASure:POWer?");
        }

        public void Request_Source_Voltage()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SOURce:VOLtage?");
            _tcpHandler.EnqueueQuery("SOURce:VOLtage?");
        }

        public void Request_Source_Current()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SOURce:CURrent?");
            _tcpHandler.EnqueueQuery("SOURce:CURrent?");
        }

        public void Request_Source_Current_Negative()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SOURce:CURrent:NEGative?");
            _tcpHandler.EnqueueQuery("SOURce:CURrent:NEGative?");
        }

        public void Request_Source_Power()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SOURce:POWer?");
            _tcpHandler.EnqueueQuery("SOURce:POWer?");
        }

        public void Request_Source_Power_Negative()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SOURce:POWer:NEGative?");
            _tcpHandler.EnqueueQuery("SOURce:POWer:NEGative?");
        }

        public void RequestRemoteSetting_CV()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SYSTem:REMote:CV?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CV?");
        }

        public void RequestRemoteSetting_CC()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SYSTem:REMote:CC?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CC?");
        }

        public void RequestRemoteSetting_CP()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SYSTem:REMote:CP?");
            _tcpHandler.EnqueueQuery("SYSTem:REMote:CP?");
        }

        public void RequestTime()
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage("[INFO] trying to enqueueQuery: SYSTem:TIMe?");
            _tcpHandler.EnqueueQuery("SYSTem:TIMe?");
        }

        public void SetSystemRemoteSetting_CV(string state)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SYSTem:REMote:CV {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CV {state}");
        }

        public void SetSystemRemoteSetting_CC(string state)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SYSTem:REMote:CC {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CC {state}");
        }

        public void SetSystemRemoteSetting_CP(string state)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SYSTem:REMote:CP {state}");
            _tcpHandler.EnqueueCommand($"SYSTem:REMote:CP {state}");
        }

        public void SetOutputVoltage(double outputVoltage)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SOURce:VOLtage {outputVoltage}");
            _tcpHandler.EnqueueCommand($"SOURce:VOLtage {outputVoltage}");
        }

        public void SetOutputCurrent(double outputCurrent)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SOURce:CURrent {outputCurrent}");
            _tcpHandler.EnqueueCommand($"SOURce:CURrent {outputCurrent}");
        }

        public void SetOutputCurrentNegative(double outputCurrentNegative)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SOURce:CURrent:NEGative {outputCurrentNegative} ");
            _tcpHandler.EnqueueCommand($"SOURce:CURrent:NEGative {outputCurrentNegative}");
        }

        public void SetOutputPower(double outputPower)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SOURce:POWer {outputPower}");
            _tcpHandler.EnqueueCommand($"SOURce:POWer {outputPower}");
        }

        public void SetOutputPowerNegative(double outputPowerNegative)
        {
            //if (!IsConnectionEstablished()) return;
            _logManager.AddDebugLogMessage($"[INFO] trying to enqueue command: SOURce:POWer:NEGative {outputPowerNegative}");
            _tcpHandler.EnqueueCommand($"SOURce:POWer:NEGative {outputPowerNegative}");
        }

    }
}
