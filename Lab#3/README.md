# Lab 3: DNS Client Application 🌐

A DNS client application built with C# using the DNSClient library for resolving domain names and IP addresses. 📡

## Description 📝

This console application allows users to resolve domain names to IP addresses or vice versa using the [DNSClient.NET](https://github.com/MichaCo/DnsClient.NET) library in C#. The DNS server indicated by the system will be used by default, but the user can also specify a different DNS server to be used for the commands.

## Dependencies 📦

The following dependencies are required for the DNS Client Application:

- [DNSClient.NET](https://github.com/MichaCo/DnsClient.NET): A C# library for DNS resolution.

## Features 🌟

The DNS Client Application will have the following features:

1. `resolve <domain>`: Displays the list of IP addresses assigned to the domain name.
2. `resolve <ip>`: Displays the list of domain names assigned to the IP address.
3. `set dns <ip>`: Changes the DNS server that will be used for the above commands to the specified IP address.

## Installation 💾

1. Clone the repository 📦
2. Open the solution in Visual Studio 🧰
3. Build the solution 🔨

## Usage 📖

1. Start the DNS Client Application by running the DNSClientConsole project in Visual Studio or by executing the compiled executable.
2. By default, the system's DNS server will be used for the commands. To change the DNS server, use the `set dns <ip>` option, followed by inserting the IP address of DNS server.
3. To resolve a domain name to IP addresses, use the `resolve <domain>` option, followed by inserting the domain address.
4. To resolve an IP address to domain names, use the `resolve <ip>` option followed by inserting the IP address.

Example commands and their output:

```
You use DNS: 192.168.1.1:53

 1 -> resolve <domain>
 2 -> resolve <ip>
 3 -> set dns <ip>
 0 -> Exit

Select Option: 1

Enter domain name: utm.md

; (1 server found)
;; Got answer:
;; ->>HEADER<<- opcode: Query, status: No Error, id: 31951
;; flags: qr rd ra; QUERY: 1, ANSWER: 5, AUTHORITY: 0, ADDITIONAL: 1

;; OPT PSEUDOSECTION:
; EDNS: version: 0, flags:; UDP: 512; code: NoError
;; QUESTION SECTION:
utm.md.                                 IN      ANY

;; ANSWER SECTION:
utm.md.                                 1835    IN      NS      ns3.utm.md.
utm.md.                                 2483    IN      SOA     ns3.utm.md. barahtin.mail.utm.md. 2023030101 3600 600 1209600 3600
utm.md.                                 1835    IN      NS      ns2.utm.md.
utm.md.                                 1403    IN      A       81.180.74.23
utm.md.                                 1835    IN      NS      ns1.utm.md.

;; Query time: 4 msec
;; SERVER: 192.168.1.1#53
;; WHEN: Sat Apr 08 11:10:03 Z 2023
;; MSG SIZE  rcvd: 155

```

## Conclusion 🎓

This lab provided us with hands-on experience in building a DNS client application in C#. We learned how to resolve domain names to IP addresses and vice versa, as well as how to change the DNS server used by the application. This project helped us gain practical skills in working with DNS resolution in C# and understanding how DNS servers are used in network applications.

We hope that this project will be useful for others who are interested in learning more about DNS resolution and network programming in C# using same library! 😊
