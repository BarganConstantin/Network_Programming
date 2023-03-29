using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UDPClientServerChat.UserManager
{
    public class UDPUserManager
    {
        private static List<UDPUser> _udpUsersList;
        private static readonly object _lockpad = new object();
        private static int _nextId = 1;

        public static List<UDPUser> GetUsersList()
        {
            if (_udpUsersList == null)
            {
                lock (_lockpad)
                {
                    if (_udpUsersList == null)
                    {
                        _udpUsersList = new List<UDPUser>();
                    }
                }
            }
            return _udpUsersList;
        }

        public static void AddUserToList(UDPUser user)
        {
            user.Id = _nextId++;
            var list = GetUsersList();
            list.Add(user);
        }

        public static void RemoveUserFromList(UDPUser user)
        {
            _udpUsersList?.Remove(user);
        }

        public static string GetUserNameByIP(string ip)
        {
            var users = GetUsersList();
            string userName = users.Where(user => user.IPEndPoint.Address.ToString() == ip)
                           .Select(user => user.UserName)
                           .FirstOrDefault();
            return userName;
        }

        public static UDPUser GetUserById(string ip)
        {
            var users = GetUsersList();
            UDPUser user = users.Where(user => user.IPEndPoint.Address.ToString() == ip)
                           .Select(user => user)
                           .FirstOrDefault();
            return user;
        }
    }
}
