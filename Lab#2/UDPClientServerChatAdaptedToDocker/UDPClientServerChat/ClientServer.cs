using System;
using System.Threading;
using System.Threading.Tasks;
using UDPClientServerChat.Abstract;

namespace UDPClientServerChat
{
    public class ClientServer
    {
        private AbstractServer _server;
        private AbstractClient _client;

        public ClientServer()
        {
            _server = new Server();
            _client = new Client(_server);
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(_ => _server.Start());
            _client.Start();
        }

        public void Stop()
        {
            _server.Stop();
            _client.Stop();
        }
    }
}
