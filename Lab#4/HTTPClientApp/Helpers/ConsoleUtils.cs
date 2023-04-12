using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ConsoleUtils
    {
        public static void PrintWithColour(string text, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void PrintWithColour(string text, ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
