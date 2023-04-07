﻿using DNSClientApp.Services;
using DNSClientApp.Singleton;
using Helpers;
using System;

namespace DNSClientApp.UI
{
    public class DnsLookupConsoleUI
    {
        private DnsLookupUtility _dnsLookupUtility;

        public DnsLookupConsoleUI()
        {
            _dnsLookupUtility = new DnsLookupUtility();
        }

        public void Run()
        {
            while (true)
            {
                printDnsServerInfo();

                ConsoleUtils.PrintWithColour(" 1 -> resolve <domain>", ConsoleColor.Blue);
                ConsoleUtils.PrintWithColour("\n 2 -> resolve <ip>    ", ConsoleColor.Blue);
                ConsoleUtils.PrintWithColour("\n 3 -> set dns <ip>    ", ConsoleColor.Blue);
                ConsoleUtils.PrintWithColour("\n 0 -> Exit            ", ConsoleColor.Blue);

                ConsoleUtils.PrintWithColour("\n\nSelect Option: ", ConsoleColor.White);
                string option = Console.ReadLine();
                
                switch (option)
                {
                    case "1":
                        resolveDomainUI();
                        break;
                    case "2":
                        resolveIpUI();
                        break;
                    case "3":
                        changeDnsUI();
                        break;
                    case "0":
                        closeApplicationUI();
                        break;
                    default:
                        selectOptionErrorUI();
                        break;
                }
            } 
        }

        private void printDnsServerInfo()
        {
            ConsoleUtils.PrintWithColour("You use DNS: ", ConsoleColor.White, ConsoleColor.Green);
            var nameServers = _dnsLookupUtility.GetDnsServerAddress();
            
            foreach (var nameServer in nameServers)
            {
                ConsoleUtils.PrintWithColour(nameServer.ToString(), ConsoleColor.White, ConsoleColor.Green);
            }
            
            Console.WriteLine("\n");
        }

        private void resolveDomainUI()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter domain name: ", ConsoleColor.White);
            var domain = Console.ReadLine();

            Console.Clear();
            var result = _dnsLookupUtility.ResolveDomain(domain);
            ConsoleUtils.PrintWithColour(result, ConsoleColor.Cyan);

            Console.ReadKey();
            Console.Clear();
        }

        private void resolveIpUI()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter an IP address: ", ConsoleColor.White);
            var ipAddress = Console.ReadLine();

            Console.Clear();
            var result = _dnsLookupUtility.ResolveIp(ipAddress);
            ConsoleUtils.PrintWithColour(result, ConsoleColor.Cyan);

            Console.ReadKey();
            Console.Clear();
        }

        private void changeDnsUI()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter an IP of new DNS server: ", ConsoleColor.White);
            var newServerIP = Console.ReadLine();

            _dnsLookupUtility.SetDnsServer(newServerIP);

            ConsoleUtils.PrintWithColour("DNS server address was updated", ConsoleColor.Green);
            
            Console.ReadKey();
            Console.Clear();
        }

        private void closeApplicationUI()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Closing DNS Application ...", ConsoleColor.Magenta);
            Environment.Exit(0);
        }

        public void selectOptionErrorUI()
        {
            ConsoleUtils.PrintWithColour("Error to select option !", ConsoleColor.Red);
            ConsoleUtils.PrintWithColour("\nTry Again !", ConsoleColor.Red);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
