using DnsClient;
using Helpers;
using System;
using System.Net;

namespace DNSClientApp.Singleton
{
    public sealed class SingletonLookupClient
    {
        private static ILookupClient _client = new LookupClient();
        private static readonly object _lock = new object();

        private SingletonLookupClient() {}
        public static ILookupClient GetInstance()
        {
            return _client;
        }

        public static bool updateDnsServer(string ip)
        {

            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 53);
                ILookupClient client = new LookupClient(endPoint);

                ConsoleUtils.PrintWithColour("Testing new DNS Server ... ", ConsoleColor.DarkBlue);
                var result = client.Query("google.com", QueryType.ANY);

                lock (_lock)
                {
                    _client = client;
                    _client.EnableAuditTrail = true;
                    _client.UseCache = true;
                }
            }
            catch (Exception)
            {
                ConsoleUtils.PrintWithColour("ERROR\n", ConsoleColor.DarkRed);
                return false;
            }
            ConsoleUtils.PrintWithColour("SUCCESS\n", ConsoleColor.Green);
            return true;
        }
    }
}
