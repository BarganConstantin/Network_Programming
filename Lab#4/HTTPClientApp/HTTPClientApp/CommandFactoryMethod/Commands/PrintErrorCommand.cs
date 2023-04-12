using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class PrintErrorCommand : ICommand
    {
        public void Execute()
        {
            ConsoleUtils.PrintWithColour("Error to select option !", ConsoleColor.Red);
            ConsoleUtils.PrintWithColour("\nTry Again !", ConsoleColor.Red);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
