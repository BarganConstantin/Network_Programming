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

        public static void PrintOnCenterWithColour(string text, ConsoleColor foreground, ConsoleColor background)
        {
            const int width = 44;

            int spaceLen = (width - text.Length) / 2;

            StringBuilder space = new StringBuilder();

            for (int i = 0; i < spaceLen; i++) 
            {
                space.Append(' '); 
            }

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(space + text + space + "\n");
            Console.ResetColor();
        }

        public static void PrintEmptyColourLine(ConsoleColor foreground, ConsoleColor background)
        {
            PrintOnCenterWithColour("                                            ", foreground, background);
        }
    }
}
