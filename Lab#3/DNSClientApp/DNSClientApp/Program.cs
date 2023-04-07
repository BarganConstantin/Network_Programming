﻿using System;
using System.Linq;
using System.Net;
using DnsClient;
using DnsClient.Protocol;
using DNSClientApp.UI;

namespace DNSClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dnsLookupConsoleUI = new DnsLookupConsoleUI();
            dnsLookupConsoleUI.Run();
        }
    }
}
