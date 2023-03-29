using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPClientServerChat.Services
{
    public static class Constants
    {
        public const string BroadcastWelcomeMessageMarker = "!@#$BROADCAST_WELCOME_MSG!@#$";
        public const string PrivateWelcomeMessageMarker = "!@#$PRIVATE_WELCOME_MSG!@#$";
        public const string PrivateMessageMarker = "!@#$PRIVATE_MSG!@#$";
        public const string BroadcastMessageMarker = "!@#$BROADCAST_MSG!@#$";
        public const string EndOfMessageMarker = "!@#$END_OF_MSG!@#$";
        public const string GoodbyeMessageMarker = "!@#$GOODBYE_MSG!@#$";
    }
}
