using GSPLink.Abstractions.Models;
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace KinoVea.Force.GSPLink.SwingMetricsClient
{
    public class SwingMetricsClient
    {
        private TcpClient tcpClient;

        private readonly string address;
        private readonly int port;

        private object syncRoot = new object();
        private bool connecting;
        private byte[] inBuffer;
        private const int bufferSize = 1024;
        private NetworkStream networkStream;

        public Action<SwingMetrics> SwingMetricsReceived;

        public SwingMetricsClient(string address, int port = 8090)
        {
            this.address = address;
            this.port = port;
        }

        public void Connect()
        {
            lock (syncRoot)
            {
                if (connecting)
                {
                    return;
                }
                connecting = true;
            }

            CloseConnection();

            tcpClient = new TcpClient();
            tcpClient.BeginConnect(address, port, EndConnect, null);

        }

        void EndConnect(IAsyncResult ar)
        {
            lock (syncRoot)
            {
                connecting = false;
            }

            try
            {
                tcpClient.EndConnect(ar);
                if (tcpClient.Connected)
                {
                    networkStream = tcpClient.GetStream();
                    inBuffer = new byte[bufferSize];
                    networkStream.BeginRead(inBuffer, 0, bufferSize, ReceiveCallback, inBuffer);
                }
            }
            catch { }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            lock (syncRoot)
            {
                try
                {
                    
                    int bytesRead = networkStream.EndRead(ar);
                    if (bytesRead > 0)
                    {
                        string data = Encoding.UTF8.GetString(inBuffer, 0, bytesRead);
                        SwingMetrics swingMetrics = JsonSerializer.Deserialize<SwingMetrics>(data);
                        SwingMetricsReceived?.Invoke(swingMetrics);
                    }
                    inBuffer = new byte[bufferSize];
                    tcpClient.GetStream().BeginRead(inBuffer, 0, bufferSize, ReceiveCallback, null);

                }
                catch (SocketException e)
                {
                    //DisconnectOnException(e, e.ErrorCode);
                    _ = e;
                }
                catch (Exception e)
                {
                    //DisconnectOnException(e, 0);
                    _ = e;
                }
            }

        }

        private void CloseConnection()
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
                tcpClient = null;
            }
        }

        public void Close()
        {
            CloseConnection();
        }


    }
}
