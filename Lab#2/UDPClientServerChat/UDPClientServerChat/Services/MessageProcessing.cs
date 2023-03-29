using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPClientServerChat.Abstract;
using UDPClientServerChat.UserManager;

namespace UDPClientServerChat.Services
{
    public class MessageProcessing
    {
        private readonly AbstractServer _server;
        private readonly string _username;

        public MessageProcessing(AbstractServer server)
        {
            _server = server;
        }

        public void ProcessMsg(string message)
        {
            Action<string> messageProcessing = getMessageProcessingMethod(message);

            // run processing function
            messageProcessing(message);
        }

        private Action<string> getMessageProcessingMethod(string data)
        {
            var logicMapping = new Dictionary<string, Action<string>>
            {
                { Constants.BroadcastWelcomeMessageMarker, broadcastWelcomeMessageProcessing },
                { Constants.PrivateWelcomeMessageMarker, privateWelcomeMessageProcessing },
                { Constants.PrivateMessageMarker, privateMessageProcessing },
                { Constants.BroadcastMessageMarker, broadcastMessageProcessing },
                { Constants.GoodbyeMessageMarker, goodbyeMessageProcessing },
            };

            string msgMarker = MessageParser.GetMsgMarker(data);

            return logicMapping[msgMarker];
        }

        private void privateWelcomeMessageProcessing(string data)
        {
            // get user data from msg 
            string userIP = MessageParser.GetIPFromUserInfoMsg(data);
            string userPort = MessageParser.GetPortFromUserInfoMsg(data);
            string userName = MessageParser.GetUserNameFromUserInfoMsg(data);

            // add to user list
            UDPUser user = new UDPUser(userIP, userPort, userName);
            UDPUserManager.AddUserToList(user);

            // get msg body for display in console
            string msgToDisplay = MessageParser.GetMsgBody(data);

            lock (ConsoleLock.consolelock)
            {
                ConsoleUtils.PrintPrivateWithMagenta(userName + " => " + msgToDisplay);
            }
        }

        private void broadcastWelcomeMessageProcessing(string data)
        {
            // get user data from msg 
            string userIP = MessageParser.GetIPFromUserInfoMsg(data);
            string userPort = MessageParser.GetPortFromUserInfoMsg(data);
            string userName = MessageParser.GetUserNameFromUserInfoMsg(data);

            // add to user list
            UDPUser user = new UDPUser(userIP, userPort, userName);
            UDPUserManager.AddUserToList(user);

            // get msg body for display in console
            string msgToDisplay = MessageParser.GetMsgBody(data);

            lock (ConsoleLock.consolelock)
            {
                ConsoleUtils.PrintBroadcastWithBlue(userName + " => " + msgToDisplay);
            }

            if (_server.IP != userIP)   // check if it's not first host welcome msg
            {
                _server.SendPrivateWelcomeMessage(UDPUserManager.GetUserNameByIP(_server.IP), userIP);

            }
        }

        public void privateMessageProcessing(string data)
        {
            string msgToDisplay = MessageParser.GetMsgBody(data);
            lock (ConsoleLock.consolelock)
            {
                ConsoleUtils.PrintPrivateWithMagenta(msgToDisplay);
            }
        }

        public void broadcastMessageProcessing(string data)
        {
            string msgToDisplay = MessageParser.GetMsgBody(data);
            lock (ConsoleLock.consolelock)
            {
                ConsoleUtils.PrintBroadcastWithBlue(msgToDisplay);
            }
        }

        private void goodbyeMessageProcessing(string data)
        {
            // get user ip from msg 
            string userIP = MessageParser.GetIPFromUserInfoMsg(data);
            string userName = MessageParser.GetUserNameFromUserInfoMsg(data);

            var userInfo = UDPUserManager.GetUserById(userIP);
            if (userInfo != null) // check maybe we don;t have this user in list
            {
                UDPUserManager.RemoveUserFromList(userInfo);
            }

            // remove markers from msg and display
            string msgToDisplay = MessageParser.GetMsgBody(data);

            lock (ConsoleLock.consolelock)
            {
                ConsoleUtils.PrintBroadcastWithDarkRed(userName + " => " + msgToDisplay);
            }
        }
    }
}
