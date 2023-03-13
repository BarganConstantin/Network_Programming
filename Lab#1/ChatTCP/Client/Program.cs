using Helpers;
using System;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 3000;

            
            var client = new Client(ip, port);

            try
            {
                client.Start();
            }
            catch (Exception ex)
            {
                ConsoleUtils.PrintWarning("An error occurred: " + ex.Message);
            }

            client.Close();
        }
    }
}
