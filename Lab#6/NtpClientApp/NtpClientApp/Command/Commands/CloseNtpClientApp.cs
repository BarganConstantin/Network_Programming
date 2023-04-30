using System;
using System.Threading;

namespace NtpClientApp.Command.Commands
{
    public class CloseNtpClientApp : ICommand
    {
        public void Execute()
        {
            printGoodbye();
            Environment.Exit(0);
        }
        private void printGoodbye()
        {
            Console.Clear();

            Console.WriteLine("  _____                 _ _                  _ \r\n" +
                " |  __ \\               | | |                | |\r\n" +
                " | |  \\/ ___   ___   __| | |__  _   _  ___  | |\r\n" +
                " | | __ / _ \\ / _ \\ / _` | '_ \\| | | |/ _ \\ | |\r\n" +
                " | |_\\ \\ (_) | (_) | (_| | |_) | |_| |  __/ |_|\r\n" +
                "  \\____/\\___/ \\___/ \\__,_|_.__/ \\__, |\\___| (_)\r\n" +
                "                                 __/ |         \r\n" +
                "                                |___/          ");

            Thread.Sleep(1500);
        }
    }
}
