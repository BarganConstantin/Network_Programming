using DnsClient;
using DNSClientApp.Singleton;
using System;
using System.Collections.Generic;
using System.Net;

namespace DNSClientApp.Services
{
    public class DnsLookupUtility
    {
        private ILookupClient _client;

        public DnsLookupUtility(ILookupClient client)
        {
            _client = client;
            _client.EnableAuditTrail = true;
            _client.UseCache = true;
        }

        public string ResolveIp(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                throw new ArgumentException("IP address cannot be null or empty.", nameof(ipAddress));
            }

            IDnsQueryResponse result;
            try
            {
                result = _client.QueryReverse(IPAddress.Parse(ipAddress));
            }
            catch (DnsResponseException ex)
            {
                Console.WriteLine($"Failed to perform reverse DNS lookup for IP: {ipAddress}. {ex.Message}");
                throw;
            }

            return result.AuditTrail.ToString();
        }

        public string ResolveDomain(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                throw new ArgumentException("Domain name cannot be null or empty.", nameof(domain));
            }

            IDnsQueryResponse result;
            try
            {
                result = _client.Query(domain, QueryType.ANY);
            }
            catch (DnsResponseException ex)
            {
                Console.WriteLine($"Failed to perform DNS lookup for domain: {domain}. {ex.Message}");
                throw;
            }

            return result.AuditTrail.ToString();
        }
        public void SetDnsServer(string newServerIP)
        {
            SingletonLookupClient.updateDnsServer(newServerIP);
            _client = SingletonLookupClient.GetInstance();
        }

        public IReadOnlyCollection<NameServer> GetDnsServerAddress()
        {
            return _client.NameServers;
        }
    }
}
