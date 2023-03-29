using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UDPClientServerChat.Services
{
    public class MessageParser
    {
        private static string tag = "!@#$";

        public static string GetMsgMarker(string data)
        {
            // get index of second tag
            int secondTagStartIndex = data.IndexOf(tag, 0 + tag.Length);
            // get msg start Marker by knowing index of his name
            string msgMarker = data.Substring(0, secondTagStartIndex + 4);

            return msgMarker;
        }

        public static string GetMsgBody(string data)
        {
            // extract msg without Markers using regex
            string pattern = @"(?<=!@#\$.*!@#\$)(.*?)(?=!@#\$END_OF_MSG!@#\$)";
            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                data = match.Value;
            }

            return data;
        }
        public static string GetIPFromUserInfoMsg(string data)
        {
            string userIp = string.Empty;

            // extract msg without Markers using regex
            string pattern = @"(?<=on: ).*(?=:)";
            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                userIp = match.Value;
            }

            return userIp;
        }

        public static string GetPortFromUserInfoMsg(string data)
        {
            string userPort = string.Empty;

            // extract msg without Markers using regex
            string pattern = @"(?<=\d:).*(?=!@#\$END_OF_MSG!@#\$)";
            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                userPort = match.Value;
            }

            return userPort;
        }

        public static string GetUserNameFromUserInfoMsg(string data)
        {
            string userName = string.Empty;

            // extract msg without Markers using regex
            string pattern = @"(?<=is: ).*(?= and)";
            MatchCollection matches = Regex.Matches(data, pattern);
            foreach (Match match in matches)
            {
                userName = match.Value;
            }

            return userName;
        }

    }
}
