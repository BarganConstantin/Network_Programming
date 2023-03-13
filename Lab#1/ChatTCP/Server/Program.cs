using System;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 3000;

            var server = new Server(ip, port);
            server.Start();
        }
    }
}
