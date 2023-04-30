using NtpClientApp.Command;

namespace NtpClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ntpClientApp = new NtpClientApp(new CommandInvoker());
            ntpClientApp.Run();
        }
    }
}
