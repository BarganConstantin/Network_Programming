using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UDPClientServerChat.UserManager;

namespace UDPClientServerChat.Abstract
{
    public abstract class AbstractServer
    {
        public Socket UdpServerSocket;
        public string BroadcastAddress;
        public string IP;
        public int Port;

        public abstract Socket Start();
        public abstract void Stop();
        public abstract void SendBroadcastWelcomeMessage(string userName);
        public abstract void SendPrivateWelcomeMessage(string userName, string ip);
        public abstract void SendBroadcastGoodByeMessage();
        public abstract void SendBroadcast(string message);
        public abstract void SendToUser(string message, IPEndPoint ipEndPoint);
    }
}
