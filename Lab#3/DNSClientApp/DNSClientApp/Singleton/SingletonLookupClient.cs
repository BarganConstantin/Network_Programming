﻿using DnsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DNSClientApp.Singleton
{
    public sealed class SingletonLookupClient
    {
        private static ILookupClient _client = new LookupClient();
        public static ILookupClient GetInstance()
        {
            return _client;
        }

        public static void updateDnsServer(string ip)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), 53);
            _client = new LookupClient(endPoint);
            _client.EnableAuditTrail = true;
            _client.UseCache = true;
        }
    }
}
