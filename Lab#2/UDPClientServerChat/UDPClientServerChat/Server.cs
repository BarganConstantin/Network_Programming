using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using UDPClientServerChat.Abstract;
using UDPClientServerChat.Services;
using UDPClientServerChat.UserManager;

namespace UDPClientServerChat
{
    public class Server : AbstractServer
    {
        

        private readonly MessageProcessing _messageProcessing;

        public Server()
        {
            try
            {
                IP = IPAddresses.GetLocalIPAddress();
                BroadcastAddress = IPAddresses.GetBroadcastAddress(IP);
                Port = 3000;

                var udpEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
                UdpServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                UdpServerSocket.EnableBroadcast = true;

                BindServer(udpEndPoint);

                _messageProcessing = new MessageProcessing(this);

                // events when user close app
                Console.CancelKeyPress += ProcessExitHandler;
                AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;
            }
            catch (Exception e)
            {
                ConsoleUtils.PrintWarning("Error creating server side: " + e.Message);
                throw;
            }
        }

        public override Socket Start()
        {
            while (true)
            {
                byte[] buffer = new byte[1048];
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0); // here 0 is placeholder which be replaced with actual port value
                string receivedData = "";

                do
                {
                    int bytesRead = UdpServerSocket.ReceiveFrom(buffer, ref remoteEndPoint);

                    receivedData += Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
                while (isEndOfMessage(receivedData) == false);

                // run msg processing
                _messageProcessing.ProcessMsg(receivedData);
            }
        }

        
        private void BindServer(IPEndPoint udpEndPoint)
        {
            try
            {
                UdpServerSocket.Bind(udpEndPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error binding: {e.Message}");
            }
            Console.WriteLine("You will receive message on {0}", udpEndPoint);
        }

        private bool isEndOfMessage(string receivedData)
        {
            return receivedData.Contains(Constants.EndOfMessageMarker);
        }

        public override void SendBroadcastWelcomeMessage(string userName)
        {
            EndPoint broadcastEP = new IPEndPoint(IPAddress.Parse(BroadcastAddress), 3000);

            string message = "Hello, everyone! My UserName is: " + userName + " and I listen on: " + UdpServerSocket.LocalEndPoint;

            byte[] data = Encoding.UTF8.GetBytes(Constants.BroadcastWelcomeMessageMarker + message + Constants.EndOfMessageMarker);

            // Send the welcome message as a broadcast
            UdpServerSocket.SendTo(data, broadcastEP);
        }

        public override void SendPrivateWelcomeMessage(string userName, string ip)
        {
            EndPoint concreteUserEP = new IPEndPoint(IPAddress.Parse(ip), 3000);

            string message = "Hello! My UserName is: " + userName + " and I listen on: " + UdpServerSocket.LocalEndPoint;

            byte[] data = Encoding.UTF8.GetBytes(Constants.PrivateWelcomeMessageMarker + message + Constants.EndOfMessageMarker);

            // Send the welcome message to concrete user
            UdpServerSocket.SendTo(data, concreteUserEP);
        }

        public override void SendBroadcast(string message)
        {
            EndPoint broadcastEP = new IPEndPoint(IPAddress.Parse(BroadcastAddress), 3000);

            byte[] data = Encoding.UTF8.GetBytes(Constants.BroadcastMessageMarker + message + Constants.EndOfMessageMarker);
            
            // Send the message as a broadcast
            UdpServerSocket.SendTo(data, broadcastEP);
        }

        public override void SendToUser(string message, IPEndPoint ipEndPoint)
        {
            byte[] data = Encoding.UTF8.GetBytes(Constants.PrivateMessageMarker + message + Constants.EndOfMessageMarker);

            // Send the message to specific user
            UdpServerSocket.SendTo(data, ipEndPoint);
        }

        public override void SendBroadcastGoodByeMessage()
        {
            EndPoint broadcastEP = new IPEndPoint(IPAddress.Parse(BroadcastAddress), 3000);

            string message = "GoodBye, everyone! My UserName is: " + UDPUserManager.GetUserNameByIP(IP) + " and I listened on: " + UdpServerSocket.LocalEndPoint;

            byte[] data = Encoding.UTF8.GetBytes(Constants.GoodbyeMessageMarker + message + Constants.EndOfMessageMarker);

            // Send the welcome message as a broadcast
            UdpServerSocket.SendTo(data, broadcastEP);
        }

        public override void Stop()
        {
            SendBroadcastGoodByeMessage();
        }

        private void ProcessExitHandler(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
