using DnsClient;
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

        public static void updateDnsServer(string ip)
        {
            lock (_lock)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 53);
                _client = new LookupClient(endPoint);
                _client.EnableAuditTrail = true;
                _client.UseCache = true;
            }
        }
    }
}
