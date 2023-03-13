using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class ConsoleUtils
    {
        public static void PrintWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintWithColor(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void PrintResponse(string data)
        {
            int arrowIndex = data.IndexOf("=>");

            if (arrowIndex >= 0)
            {
                string textBeforeArrow = data.Substring(0, arrowIndex);
                data = data.Substring(arrowIndex);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(textBeforeArrow);
                //Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(data);
            Console.ResetColor();
        }

        public static void PrintWithColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
