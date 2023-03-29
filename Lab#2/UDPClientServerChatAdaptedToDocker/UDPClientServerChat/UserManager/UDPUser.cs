using System.Net;

namespace UDPClientServerChat.UserManager
{
    public class UDPUser
    {
        public int Id {  get; set; }
        public IPEndPoint IPEndPoint { get; set; }
        public string UserName { get; set; }

        public UDPUser(string ip, string port, string userName)
        {
            IPEndPoint = new IPEndPoint(IPAddress.Parse(ip), int.Parse(port));
            UserName = userName;
        }
    }
}