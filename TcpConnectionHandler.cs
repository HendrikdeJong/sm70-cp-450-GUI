using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace sm70_cp_450_GUI
{
    public class TcpConnectionHandler
    {
        private static TcpConnectionHandler? _instance;
        private readonly LogManager? _logManager;


        //private string _serverIp;
        //private int _serverPort;

        private readonly string _DefaultServerIp = Properties.Settings.Default._IpAddres;
        private readonly int _DefaultServerPort = int.Parse(Properties.Settings.Default._Port);

        private TcpClient? _tcpClient;
        private NetworkStream? _networkStream;

        private readonly ConcurrentQueue<string> _commandQueue = new();
        private readonly ConcurrentQueue<string> _queryQueue = new();
        private readonly HashSet<string> _pendingQueries = new();
        private readonly HashSet<string> _pendingCommands = new();
        private bool _isProcessingQueryQueue = false;
        private bool _isProcessingCommandQueue = false;

        public bool IsConnected => _tcpClient?.Connected ?? false;
        public event Action? OnConnectionEstablished;
        public event Action? OnConnectionLost;

        public double MeasuredVoltage { get; private set; } = 0;
        public double MeasuredCurrent { get; private set; } = 0;
        public double MeasuredPower { get; private set; } = 0;

        public double SourceVoltage { get; private set; } = 0;
        public double SourceCurrent { get; private set; } = 0;
        public double SourcePower { get; private set; } = 0;
        public double SourceNegativeCurrent { get; private set; } = 0;
        public double SourceNegativePower { get; private set; } = 0;

        public string SystemRemoteSettingVoltage { get; private set; } = "Voltage Control";
        public string SystemRemoteSettingCurrent { get; private set; } = "Current Control";
        public string SystemRemoteSettingPower { get; private set; } = "Power Control";

        private TcpConnectionHandler()
        {
            _logManager = LogManager.Instance;
            // Automatically initialize on startup
            Task.Run(() => InitializeTcpClient());
        }

        public static TcpConnectionHandler Instance
        {
            get
            {
                _instance ??= new TcpConnectionHandler();
                return _instance;
            }
        }

        public async Task<bool> InitializeTcpClient()
        {
            if (IsConnected) return false;

            _tcpClient = new TcpClient();
            try
            {
                await _tcpClient.ConnectAsync(_DefaultServerIp, _DefaultServerPort);
                _networkStream = _tcpClient.GetStream();
                OnConnectionEstablished?.Invoke();
                EnqueueCommand("SYSTem:REMote:CV: Remote");
                EnqueueCommand("SYSTem:REMote:CC: Remote");
                EnqueueCommand("SYSTem:REMote:CP: Remote");
                EnqueueCommand("SYSTem:POWersink output,On");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task CloseConnectionAsync()
        {
            EnqueueCommand("OUTPut OFF");
            EnqueueCommand("SOUR:POW 0");
            EnqueueCommand("SOUR:POW:NEG 0");
            EnqueueCommand("SYSTem:REMote:CV: Front");
            EnqueueCommand("SYSTem:REMote:CC: Front");
            EnqueueCommand("SYSTem:REMote:CP: Front");

            await Task.Delay(4000);

            // Close the network stream and TCP client asynchronously
            _networkStream?.Close();
            await Task.Delay(100); // Small delay to ensure stream closure before client closes
            _tcpClient?.Close();

            OnConnectionLost?.Invoke();
            MessageBox.Show("Connection closed.", "Connection Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateInternalState(string query, string response)
        {
            // Define a set of queries that expect double values.
            var numericQueries = new HashSet<string>
            {
                "MEASure:VOLtage?",
                "MEASure:CURrent?",
                "MEASure:POWer?",
                "SOURce:VOLtage?",
                "SOURce:CURrent?",
                "SOURce:POWer?",
                "SOURce:CURrent:NEGative?",
                "SOURce:POWer:NEGative?"
            };

            // Check if the query expects a numeric value
            if (numericQueries.Contains(query))
            {
                if (!double.TryParse(response, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out double parsedValue))
                {
                    _logManager?.AddDebugLogMessage($"❌ Failed to parse response for query: {query}, Response: {response}");
                    return;
                }

                // Set the appropriate numeric value
                switch (query)
                {
                    case "MEASure:VOLtage?":
                        MeasuredVoltage = parsedValue;
                        break;
                    case "MEASure:CURrent?":
                        MeasuredCurrent = parsedValue;
                        break;
                    case "MEASure:POWer?":
                        MeasuredPower = parsedValue;
                        break;
                    case "SOURce:VOLtage?":
                        SourceVoltage = parsedValue;
                        break;
                    case "SOURce:CURrent?":
                        SourceCurrent = parsedValue;
                        break;
                    case "SOURce:POWer?":
                        SourcePower = parsedValue;
                        break;
                    case "SOURce:CURrent:NEGative?":
                        SourceNegativeCurrent = parsedValue;
                        break;
                    case "SOURce:POWer:NEGative?":
                        SourceNegativePower = parsedValue;
                        break;
                    default:
                        _logManager?.AddDebugLogMessage($"❌ Unrecognized numeric query: {query}");
                        break;
                }
            }
            else
            {
                // Handle string queries that do not expect numeric values
                switch (query)
                {
                    case "SYSTem:REMote:CV?":
                        SystemRemoteSettingVoltage = response;
                        break;
                    case "SYSTem:REMote:CC?":
                        SystemRemoteSettingCurrent = response;
                        break;
                    case "SYSTem:REMote:CP?":
                        SystemRemoteSettingPower = response;
                        break;
                    default:
                        _logManager?.AddDebugLogMessage($"❌ Unrecognized query for string response: {query}");
                        break;
                }
            }
        }



        #region queries

        public void EnqueueQuery(string query)
        {
            if (!_pendingQueries.Contains(query))
            {
                _queryQueue?.Enqueue(query);
                _ = _pendingQueries?.Add(query);
                _logManager?.AddDebugLogMessage($"⚠️ Enqueued query: {query}");
                ProcessQueryQueue();
            }
        }

        // Process the query queue
        private async void ProcessQueryQueue()
        {
            if (IsConnected)
            {
                if (_isProcessingQueryQueue) return;

                _isProcessingQueryQueue = true;

                while (_queryQueue.TryDequeue(out var query))
                {
                    string? response = await SendQueryAsync(query);
                    _ = _pendingQueries?.Remove(query);

                    // Log the query and response
                    _logManager?.AddDebugLogMessage($"⚠️ Processing query: {query}, Response: {response}");

                    if (!string.IsNullOrEmpty(response))
                    {
                        // Update the internal state based on the query
                        UpdateInternalState(query, response);

                        // Now update the UI
                        if (MainForm.Instance != null)
                        {
                            MainForm.Instance.Invoke(new Action(() => MainForm.Instance.UpdateAllUIFields()));
                        }
                    }
                    else
                    {
                        // Log if there was no response or error
                        _logManager?.AddDebugLogMessage($"❌ Failed to process query or received empty response: {query}");
                    }
                }

                _isProcessingQueryQueue = false;
            }
        }




        public async Task<string?> SendQueryAsync(string? query, int timeoutMilliseconds = 10000)
        {
            if (_tcpClient == null)
            {
                return null;
            }
            if (_networkStream == null || !_tcpClient.Connected)
            {
                _logManager?.AddDebugLogMessage("❌ TCP connection is not open.");
                return null;
            }

            try
            {
                using var cts = new CancellationTokenSource(timeoutMilliseconds);
                // Write the query to the network stream
                byte[] messageBuffer = Encoding.UTF8.GetBytes(query + "\n");
                await _networkStream.WriteAsync(messageBuffer, cts.Token);
                await _networkStream.FlushAsync(cts.Token);

                // Read the response
                var buffer = new byte[1024];
                var stringBuilder = new StringBuilder();
                int bytesRead;

                do
                {
                    bytesRead = await _networkStream.ReadAsync(buffer, cts.Token);
                    if (bytesRead > 0)
                    {
                        stringBuilder?.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                    }
                } while (_networkStream.DataAvailable && !cts.Token.IsCancellationRequested);

                return stringBuilder?.ToString().Trim();
            }
            catch (Exception ex)
            {
                _logManager?.AddDebugLogMessage($"❌ Failed to send query: {ex.Message}");
                return null;
            }
        }

        #endregion

        #region Commands
        public async Task<bool> SendCommandAsync(string? command)
        {
            if(_tcpClient  == null)
            {
                return false;
            }
            if (_networkStream == null || !_tcpClient.Connected)
            {
                _logManager?.AddDebugLogMessage("❌ TCP connection is not open.");
                return false;
            }

            try
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(command + "\n");
                await _networkStream.WriteAsync(messageBuffer);
                await _networkStream.FlushAsync();
                return true;  // Command sent successfully
            }
            catch (Exception ex)
            {
                _logManager?.AddDebugLogMessage($"❌ Failed to send command: {ex.Message}");
                return false;
            }
        }

        // Enqueue a command (no response expected)
        public void EnqueueCommand(string command)
        {
            if (!_pendingCommands.Contains(command))
            {
                _commandQueue?.Enqueue(command);
                _ = _pendingCommands?.Add(command);
                ProcessCommandQueue();
            }
        }

        // Process the command queue
        private async void ProcessCommandQueue()
        {
            if (_isProcessingCommandQueue) return;

            _isProcessingCommandQueue = true;

            while (_commandQueue.TryDequeue(out var command))
            {
                await SendCommandAsync(command);
                _ = _pendingCommands?.Remove(command);
            }

            _isProcessingCommandQueue = false;
        }
        #endregion
    }
}
