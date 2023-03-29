using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPClientServerChat.Abstract;
using UDPClientServerChat.UserManager;

namespace UDPClientServerChat
{
    public class Client : AbstractClient
    {
        private readonly AbstractServer _server;
        private string _userName;

        public Client(AbstractServer server) 
        {
            _server = server;
        }

        public override void Start()
        {
            lock (ConsoleLock.consolelock)
            {
                Console.Write("Enter your username: ");
                _userName = Console.ReadLine();
                _server.SendBroadcastWelcomeMessage(_userName);
            }

            startClient();
        }

        public override void Stop()
        {
            stopClient();
        }

        private void startClient()
        {
            while (true)
            {
                string msg = Console.ReadLine();
                msg = _userName + " => " + msg;
                
                lock (ConsoleLock.consolelock)
                {
                    Console.Write("Send to all[a] or specific user[u]: ");
                    string option = Console.ReadLine();

                    if (option == "a")
                    {
                        _server.SendBroadcast(msg);
                    }
                    else if (option == "u")
                    {
                        // select and send to specific user
                        IPEndPoint ipEndPoint = GetUserIPEndPointFromList();
                        _server.SendToUser(msg, ipEndPoint);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
            }
        }

        private IPEndPoint GetUserIPEndPointFromList()
        {
            var users = UDPUserManager.GetUsersList();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id} UserName: {user.UserName}");
            }

            Console.Write("Insert user ID: ");
            string userId = Console.ReadLine();

            IPEndPoint userIPEndPoint = (from user in users
                                         where user.Id == int.Parse(userId)
                                         select user.IPEndPoint).FirstOrDefault();

            return userIPEndPoint;
        }

        private void stopClient()
        {
            Console.WriteLine("You Session Has Finished!");
        }
    }
}
