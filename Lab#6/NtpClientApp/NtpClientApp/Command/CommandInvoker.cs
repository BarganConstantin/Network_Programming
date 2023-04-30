using Helpers;
using NtpClientApp.Command.Commands;
using System;
using System.Collections.Generic;

namespace NtpClientApp.Command
{
    public class CommandInvoker : ICommandInvoker
    {
        public Dictionary<string, ICommand> _actionMap;

        public CommandInvoker()
        {
            _actionMap = new Dictionary<string, ICommand>()
            {
                { "1", new TimeZOneHandlerCommand() },
                { "0", new CloseNtpClientApp() },
            };
        }

        public ICommand Invoke(string option)
        {
            if (_actionMap.ContainsKey(option))
            {
                return _actionMap[option];
            }
            return new PrintErrorCommand();
        }
        public void printCommandMenu()
        {
            Console.Clear();

            ConsoleUtils.PrintOnCenterWithColour("NTP Client App", ConsoleColor.White, ConsoleColor.DarkGreen);

            ConsoleUtils.PrintWithColour("\n 1 - Get date and time by time zone", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour("\n 0 - Exit\n\n", ConsoleColor.DarkBlue);

            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);
            ConsoleUtils.PrintWithColour("\n Option: ", ConsoleColor.White);
        }

    }
}
