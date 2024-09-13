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
        private static TcpConnectionHandler _instance;

        //private string _serverIp;
        //private int _serverPort;

        private readonly string _DefaultserverIp = Properties.Settings.Default._IpAddres;
        private readonly int _DefaultserverPort = int.Parse(Properties.Settings.Default._Port);

        private TcpClient _tcpClient;
        private NetworkStream _networkStream;

        private readonly ConcurrentQueue<string> _commandQueue = new();
        private readonly ConcurrentQueue<string> _queryQueue = new();
        private readonly HashSet<string> _pendingQueries = new();
        private readonly HashSet<string> _pendingCommands = new();
        private bool _isProcessingQueryQueue = false;
        private bool _isProcessingCommandQueue = false;

        public bool IsConnected => _tcpClient?.Connected ?? false;

        private TcpConnectionHandler()
        {
            // Automatically initialize on startup
            Task.Run(() => InitializeTcpClient());
        }

        public static TcpConnectionHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TcpConnectionHandler();
                }
                return _instance;
            }
        }

        public async Task<bool> InitializeTcpClient()
        {
            if (IsConnected) return false;

            _tcpClient = new TcpClient();
            try
            {
                await _tcpClient.ConnectAsync(_DefaultserverIp, _DefaultserverPort);
                _networkStream = _tcpClient.GetStream();
                EnqueueCommand("SYSTem:REMote:CV: Remote");
                EnqueueCommand("SYSTem:REMote:CC: Remote");
                EnqueueCommand("SYSTem:REMote:CP: Remote");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }








        public async Task<string?> SendQueryAsync(string query, int timeoutMilliseconds = 10000)
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                Console.WriteLine("[ERROR] TCP connection is not open.");
                return null;
            }

            try
            {
                using (var cts = new CancellationTokenSource(timeoutMilliseconds))
                {
                    // Write the query to the network stream
                    byte[] messageBuffer = Encoding.UTF8.GetBytes(query + "\n");
                    await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length, cts.Token);
                    await _networkStream.FlushAsync(cts.Token);

                    // Read the response
                    var buffer = new byte[1024];
                    var stringBuilder = new StringBuilder();
                    int bytesRead;

                    do
                    {
                        bytesRead = await _networkStream.ReadAsync(buffer, 0, buffer.Length, cts.Token);
                        if (bytesRead > 0)
                        {
                            stringBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                        }
                    } while (_networkStream.DataAvailable && !cts.Token.IsCancellationRequested);

                    return stringBuilder.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to send query: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SendCommandAsync(string command)
        {
            if (_networkStream == null || !_tcpClient.Connected)
            {
                Console.WriteLine("[ERROR] TCP connection is not open.");
                return false;
            }

            try
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(command + "\n");
                await _networkStream.WriteAsync(messageBuffer, 0, messageBuffer.Length);
                await _networkStream.FlushAsync();
                return true;  // Command sent successfully
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to send command: {ex.Message}");
                return false;
            }
        }

        public void CloseConnection()
        {
            _networkStream?.Close();
            _tcpClient?.Close();
        }


        public void EnqueueQuery(string query)
        {
            if (!_pendingQueries.Contains(query))
            {
                _queryQueue.Enqueue(query);
                _ = _pendingQueries.Add(query);
                ProcessQueryQueue();
            }
        }

        // Process the query queue
        private async void ProcessQueryQueue()
        {
            if (_isProcessingQueryQueue) return;

            _isProcessingQueryQueue = true;

            while (_queryQueue.TryDequeue(out string query))
            {
                string response = await SendQueryAsync(query);  // Implement your actual TCP query method
                _ = _pendingQueries.Remove(query);
                // Handle response if needed
            }

            _isProcessingQueryQueue = false;
        }

        // Enqueue a command (no response expected)
        public void EnqueueCommand(string command)
        {
            if (!_pendingCommands.Contains(command))
            {
                _commandQueue.Enqueue(command);
                _ = _pendingCommands.Add(command);
                ProcessCommandQueue();
            }
        }

        // Process the command queue
        private async void ProcessCommandQueue()
        {
            if (_isProcessingCommandQueue) return;

            _isProcessingCommandQueue = true;

            while (_commandQueue.TryDequeue(out string command))
            {
                await SendCommandAsync(command);  // Implement your actual TCP command method
                _ = _pendingCommands.Remove(command);
            }

            _isProcessingCommandQueue = false;
        }
    }
}
