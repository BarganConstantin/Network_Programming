using Helpers;
using System;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class CloseHttpClientApp : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Closing DNS Application ...", ConsoleColor.Magenta);
            Environment.Exit(0);
        }
    }
}
