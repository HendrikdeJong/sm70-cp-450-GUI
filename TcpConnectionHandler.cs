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
        public void CloseConnection()
        {
            _networkStream?.Close();
            _tcpClient?.Close();
            OnConnectionLost?.Invoke();
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
                    if (MainForm.Instance != null)
                    {
                        if (response != null && MainForm.Instance._commandToUIActions.TryGetValue(query, out var uiAction))
                        {
                            // Log that we found the matching action
                            _logManager?.AddDebugLogMessage($"⚠️ Found action for query: {query}");

                            // Invoke the corresponding UI action
                            MainForm.Instance.Invoke(new Action(() => uiAction(response)));
                        }
                        else
                        {
                            // Log if there was no matching action
                            _logManager?.AddDebugLogMessage($"❌ No matching action for query: {query}");
                        }
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
