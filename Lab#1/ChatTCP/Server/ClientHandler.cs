using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private readonly Socket _client;
        private readonly List<Socket> _clients;

        public ClientHandler(Socket client, List<Socket> clients)
        {
            _client = client;
            _clients = clients;
        }

        public void Handle()
        {
            try
            {
                _reciveAndSendLoop();
            }
            catch (Exception e)
            {
                ConsoleUtils.PrintWarning("Error handling client: " + e.Message);
            }
            finally
            {
                _client.Shutdown(SocketShutdown.Both);
                _client.Close();
                _clients.Remove(_client);       //delete client from broadcast list
            }
        }

        private void _reciveAndSendLoop()
        {
            var buffer = new byte[256];
            var size = 0;
            var data = new StringBuilder();

            try
            {
                while (true)
                {
                    size = _client.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                    if (_client.Available == 0)
                    {
                        Console.WriteLine(_client.RemoteEndPoint.ToString() + " ---> " + data);

                        //_client.Send(Encoding.UTF8.GetBytes("Received by Server"));

                        Server.Broadcast(DateTime.Now.ToString("[HH:mm] ") + data.ToString());
                        data.Clear();
                    }
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionReset || ex.ErrorCode == 10053)
                {
                    //Console.WriteLine("The connection was forcibly closed by the remote host: " + _client.RemoteEndPoint.ToString());
                    ConsoleUtils.PrintWarning("# " + _client.RemoteEndPoint.ToString() + " disconected from server" + " [online: " + (_clients.Count - 1) + "]");
                }
                else
                {
                    ConsoleUtils.PrintWarning("SocketException occurred: " + ex.Message);
                }
            }
        }
    }
}
