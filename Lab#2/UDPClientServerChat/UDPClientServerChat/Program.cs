using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPClientServerChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientServer = new ClientServer();
            clientServer.Start();
        }
    }
}
