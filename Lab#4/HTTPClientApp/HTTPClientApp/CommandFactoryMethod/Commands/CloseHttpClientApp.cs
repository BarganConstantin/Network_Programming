using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
