using Helpers;
using System;
using System.Text.RegularExpressions;

namespace NtpClientApp.Command.Commands
{
    internal class TimeZOneHandlerCommand : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintOnCenterWithColour("Time & Date by Time Zone", ConsoleColor.White, ConsoleColor.DarkGreen);
            ConsoleUtils.PrintWithColour("\n Enter the time zone \n in GMT+X or GMT-X format: ", ConsoleColor.White);
            string input = Console.ReadLine();

            Match match = Regex.Match(input, @"GMT(\+|\-)\d{1,2}");
            if (!match.Success)
            {
                ConsoleUtils.PrintWithColour("\nThe format is not valid!\n", ConsoleColor.Red);
                Console.WriteLine("\nPress any key to continue ...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

            // Extract the offset value from the input string and convert it to an integer
            int offset = int.Parse(match.Value.Substring(4));
            if (match.Value[3] == '-')
            {
                // If the offset is negative, convert it to a negative integer
                offset = -offset;
            }

            // Create a custom time zone object with the specified offset from UTC
            TimeZoneInfo timeZone = TimeZoneInfo.CreateCustomTimeZone("Custom Time Zone", new TimeSpan(offset, 0, 0), "Custom Time Zone", "Custom Time Zone");

            // Convert date time to particular time zone
            DateTimeOffset currentDateTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, timeZone);
            ConsoleUtils.PrintWithColour(string.Format("\n The current time and date in the specified\n area is: "), ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(string.Format(currentDateTime.ToString("dd/MM/yyyy HH:mm:ss")), ConsoleColor.White);
            
            Console.WriteLine("\n");
            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();
        }
    }
}
