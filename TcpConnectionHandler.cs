using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace sm70_cp_450_GUI
{
    public class TcpConnectionHandler
    {
        private readonly string _serverIp;
        private readonly int _serverPort;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;

        public bool IsConnected => _tcpClient?.Connected ?? false;

        public TcpConnectionHandler(string serverIp, int serverPort)
        {
            _serverIp = serverIp;
            _serverPort = serverPort;
        }

        public async Task<bool> InitializeTcpClient()
        {
            _tcpClient = new TcpClient();
            try
            {
                await _tcpClient.ConnectAsync(_serverIp, _serverPort);
                _networkStream = _tcpClient.GetStream();
                return true;  // Successfully connected
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to connect: {ex.Message}");
                return false;  // Connection failed
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
    }
}
