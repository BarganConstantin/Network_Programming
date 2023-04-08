using DnsClient;
using DNSClientApp.Singleton;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

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
                return "IP address cannot be null or empty.";
            }

            IDnsQueryResponse result;
            try
            {
                result = _client.QueryReverse(IPAddress.Parse(ipAddress));
            }
            catch (Exception ex)
            {
                return $"Failed to perform reverse DNS lookup for IP: {ipAddress}. {ex.Message}";
            }

            return result.AuditTrail.ToString();
        }

        public string ResolveDomain(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return "Domain name cannot be null or empty.";
            }

            IDnsQueryResponse result;
            try
            {
                result = _client.Query(domain, QueryType.ANY);
            }
            catch (Exception ex)
            {
                return $"Failed to perform DNS lookup for domain: {domain}. {ex.Message}";
            }

            return result.AuditTrail.ToString();
        }
        public string SetDnsServer(string newServerIP)
        {
            if (string.IsNullOrEmpty(newServerIP))
            {
                return "IP address cannot be null or empty.";
            }

            SingletonLookupClient.updateDnsServer(newServerIP);
            _client = SingletonLookupClient.GetInstance();

            return "DNS server address was updated";
        }

        public IReadOnlyCollection<NameServer> GetDnsServerAddress()
        {
            return _client.NameServers;
        }
    }
}
