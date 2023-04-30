using Helpers;
using System;

namespace NtpClientApp.Command.Commands
{
    public class PrintErrorCommand : ICommand
    {
        public void Execute()
        {
            ConsoleUtils.PrintWithColour("\n Error to select option !", ConsoleColor.Red);
            ConsoleUtils.PrintWithColour("\n Try Again !", ConsoleColor.Red);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
