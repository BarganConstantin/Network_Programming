using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        private readonly Socket _tcpSocket;

        public Client(string ip, int port)
        {
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            connectToServer(tcpEndPoint);
        }

        public void Start()
        {
            Console.Write("username: ");
            var userName = Console.ReadLine();

            startReadingFromServer();
            startSendingToServer(userName);

        }

        private void startSendingToServer(string userName)
        {
            while (true)
            {
                var message = Console.ReadLine() ?? "";

                if (message == "exit")
                {
                    break;
                }

                try
                {
                    sendToServer(userName + " => " + message);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.PrintWarning("Error sending data to server: " + ex.Message);
                }
            }
        }

        private void startReadingFromServer()
        {
            Thread reader = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        var data = readFromServer();
                        ConsoleUtils.PrintResponse(data);
                    }
                    catch (SocketException e)
                    {
                        if (e.SocketErrorCode == SocketError.ConnectionReset) // Error code for 'An existing connection was forcibly closed by the remote host'
                        {
                            ConsoleUtils.PrintWarning("The server closed the connection.");
                            Thread.Sleep(3000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            ConsoleUtils.PrintWarning("Socket exception occurred: " + e.Message);
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleUtils.PrintWarning("Exception occurred: " + ex.Message);
                    }
                }
            });
            reader.Start();
        }

        private void connectToServer(IPEndPoint tcpEndPoint)
        {
            while (true)
            {
                try
                {
                    _tcpSocket.Connect(tcpEndPoint);
                    ConsoleUtils.PrintWithColor("Socket connected to server " + _tcpSocket.RemoteEndPoint.ToString());
                    break;
                }
                catch (SocketException)
                {
                    ConsoleUtils.PrintWarning("Connection failed. Retrying in 1 second...");
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    ConsoleUtils.PrintWarning("Error connecting to server: " + ex.Message);
                }
            }
        }

        private void sendToServer(string message)
        {
            var data = Encoding.UTF8.GetBytes(message);
            _tcpSocket.Send(data);
        }

        private string readFromServer()
        {
            var buffer = new byte[256];
            int size;
            var response = new StringBuilder();

            do
            {
                size = _tcpSocket.Receive(buffer);
                response.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (_tcpSocket.Available > 0);

            return response.ToString();
        }

        public void Close()
        {
            try
            {
                _tcpSocket.Shutdown(SocketShutdown.Both);
                _tcpSocket.Close();
            }
            catch (SocketException e)
            {
                ConsoleUtils.PrintWarning("Socket exception occurred while closing the connection: " + e.Message);
            }
            catch (Exception ex)
            {
                ConsoleUtils.PrintWarning("Exception occurred while closing the connection: " + ex.Message);
            }
        }
    }
}
