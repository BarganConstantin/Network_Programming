using NtpClientApp.Command;
using System;
using System.Threading;

namespace NtpClientApp
{
    public class NtpClientApp
    {
        private readonly ICommandInvoker _commandInvoker;
        public NtpClientApp(ICommandInvoker commandInvoker) 
        {
            _commandInvoker = commandInvoker;
        }
        public void Run()
        {
            printWelcome();

            while (true)
            {
                _commandInvoker.printCommandMenu();

                var option = Console.ReadLine();

                var command = _commandInvoker.Invoke(option);
                command.Execute();
            }
        }

        private void printWelcome()
        {
            Console.WriteLine("  _    _      _                            _ \r\n" +
                " | |  | |    | |                          | |\r\n" +
                " | |  | | ___| | ___ ___  _ __ ___   ___  | |\r\n" +
                " | |/\\| |/ _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\ | |\r\n" +
                " \\  /\\  /  __/ | (_| (_) | | | | | |  __/ |_|\r\n" +
                "  \\/  \\/ \\___|_|\\___\\___/|_| |_| |_|\\___| (_)\r\n" +
                "                                             \r\n" +
                "                                             ");

            Thread.Sleep(1500);
        }
    }
}
