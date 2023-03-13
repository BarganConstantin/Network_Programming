using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private readonly Socket _tcpSocket;
        private static List<Socket> _clients = new List<Socket>();

        public Server(string ip, int port)
        {
            try
            {
                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                _tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                BindAndListen(tcpEndPoint, 10);
            }
            catch (Exception e)
            {
                ConsoleUtils.PrintWarning("Error creating server: " + e.Message);
                throw;
            }
        }

        private void BindAndListen(IPEndPoint tcpEndPoint, int queueLimit)
        {
            try
            {
                _tcpSocket.Bind(tcpEndPoint);
                _tcpSocket.Listen(queueLimit);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error binding and listening: {e.Message}");
            }
            Console.WriteLine("Server started on {0}", tcpEndPoint);
        }

        private Socket acceptClient()
        {
            try
            {
                Socket client = _tcpSocket.Accept();

                lock (_clients)
                {
                    _clients.Add(client);               //add client in broadcast list
                }

                return client;
            }
            catch (Exception e)
            {
                ConsoleUtils.PrintWarning("Error accepting client: " + e.Message);
                throw;
            }               
        }

        public void Start()
        {
            while(true)
            {
                var client = acceptClient();

                ConsoleUtils.PrintWithColor("# " + client.RemoteEndPoint.ToString() + " connected to server" + "     [online: " + (_clients.Count) + "]", ConsoleColor.Blue);

                var clientHandler = new ClientHandler(client, _clients);

                Thread thread = new Thread(clientHandler.Handle);
                thread.Start();

                //clientHandler.Handle();
            }
        }

        public void Close()
        {
            _tcpSocket.Shutdown(SocketShutdown.Both);
            _tcpSocket.Close();
        }

        public static void Broadcast(string message)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                foreach (var client in _clients)
                {
                    client.Send(buffer);
                }
            }
            catch (Exception e)
            {
                ConsoleUtils.PrintWarning("Error broadcasting message: " + e.Message);
                throw;
            }
        }
    }
}
