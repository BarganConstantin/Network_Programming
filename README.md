# 🌐 Network Programming Labs

This repository contains my labs for the Network Programming course. The labs are written in C# and include exercises on building chat applications using TCP and other network protocols.

## Lab 1: Chat Application using TCP [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%231)

In this lab, I built a simple chat application using TCP protocol. The lab included the following requirements:

- Creation of two console applications: a server and a client 💻
- The client application will connect to the server 🤝
- The client application will ask the user to enter some text from the keyboard and send it to the server 💬
- The server application will display this message in its window and rebroadcast it to all connected clients (including the one that sent the original message) 📩
- Customers will be able to send as many messages as they want 🔄

## Lab 2: Chat Application using TCP [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%232)

In this lab, I built a simple chat application using UDP protocol. The lab included the following requirements:

- Creation of a console application that can act as both a client and a server 💻
- Multiple users can connect to the chat application simultaneously 👥
- Users can send and receive messages in real-time ⏰
- Each user runs an application of type client-server at the same time to handle incoming messages 📱
- Users can communicate through broadcast or send individual messages in private 🔒

## Lab 3:  DNS Client Application [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%233)

In this lab, I built a simple DNS client application using DNSClient.NET library in C#. The lab have the following feature:

- `resolve <domain>`: Displays the list of IP addresses assigned to the domain name 🌐
- `resolve <ip>`: Displays the list of domain names assigned to the IP address 🔍
- `set dns <ip>`: Changes the DNS server that will be used for the above commands to the specified IP address ⚙️

## Lab 4: HTTP Client Application [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%234)

In this lab, I built a simple HTTP client console application in C# with following features: 

- CRUD operations: The application allows users to perform CRUD operations (Create📝, Read📖, Update📈, Delete❌) on categories and products via HTTP requests.
- Category operations: Users can enumerate categories📊, retrieve category details🔍, create new categories🆕, delete categories🗑️, and update category titles✏️.
- Product operations: Users can create new products in categories🛍️ and retrieve products in categories🔎.
- Simple and intuitive: The console application is designed to be easy to understand and use, with clear prompts and instructions for performing operations.
- HTTP client: The application uses the HttpClient class in C# to send HTTP requests and receive responses, making it a practical example of using HTTP client in a real-world scenario.

## Lab 5: Email Client Web Application in C# [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%235)
In this lab, I built a simple Email Client Web Application in C# with following features: 

- Show the list of emails from the mailbox using the POP3 protocol 📩
- Show the list of emails from the mailbox using the IMAP protocol 📬
- Download an email with attachments using the POP3 and IMAP protocol 📤
- Send an email with text using the SMTP protocol 📨
- Send an email with an attachment using the SMTP protocol 📎

## Lab 6: NTP Client Console App [🔗](https://github.com/BarganConstantin/Network_Programming/tree/main/Lab%236)
In this lab, I built a simple NTP Client Console Application in C# with following features: 

- Prompt the user to enter a geographic zone in "GMT+X" or "GMT-X" format 🌍
- Fetch the time from NTP servers using the NTP protocol 🕰️
- Display the exact time for the specified geographic zone ⏰

## Getting Started 🚀

To run the code in this repository, you will need Visual Studio or another C# development environment installed on your machine. Clone the repository and open the solution file in your IDE.

## Contributing 🤝

Feel free to contribute to this repository by submitting pull requests or creating issues. If you have any questions or feedback, please feel free to reach out to me.

## License 📝

This repository is licensed under the MIT License - see the [MIT License](https://opensource.org/licenses/MIT) file for details.

You can modify this template to add more details, such as instructions for running the code, how to contribute, and any other relevant information for your course. Good luck with your labs!
