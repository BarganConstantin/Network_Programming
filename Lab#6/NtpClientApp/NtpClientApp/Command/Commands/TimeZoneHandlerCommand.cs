using Helpers;
using System;
using System.Text.RegularExpressions;
using NtpClient;

namespace NtpClientApp.Command.Commands
{
    internal class TimeZOneHandlerCommand : ICommand
    {
        public void Execute()
        {
            int offset = getOffSet();

            DateTime localTime = getTimeByOffSet(offset);

            printLocalDateTimeResult(localTime);
        }

        private int getOffSet()
        {
            Match match;

            while (true)
            {
                Console.Clear();
                ConsoleUtils.PrintOnCenterWithColour("Time & Date by Time Zone", ConsoleColor.White, ConsoleColor.DarkGreen);
                ConsoleUtils.PrintWithColour("\n Enter the time zone \n in GMT+X or GMT-X format: ", ConsoleColor.White);
                string input = Console.ReadLine();

                match = Regex.Match(input, @"GMT(\+|\-)\d{1,2}");
                if (!match.Success)
                {
                    ConsoleUtils.PrintWithColour("\nThe format is not valid!\n", ConsoleColor.Red);
                    Console.WriteLine("\nPress any key to continue ...");
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
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

            return offset;
        }

        private DateTime getTimeByOffSet(int offset)
        {
            TimeSpan diff = TimeSpan.FromHours(offset);

            // Get the current time from an NTP server
            DateTime ntpDateTime = getDateTimeFromNtpServer();

            // Add the offset to the UTC time to get the needed time
            DateTime localTime = ntpDateTime.Add(diff);

            return localTime;
        }

        private DateTime getDateTimeFromNtpServer()
        {
            var connection = new NtpConnection("pool.ntp.org");
            DateTime ntpDateTime = connection.GetUtc();
            return ntpDateTime;
        }

        private void printLocalDateTimeResult(DateTime localTime)
        {
            ConsoleUtils.PrintWithColour(string.Format("\n The current time and date in the specified\n area is: "), ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(string.Format(localTime.ToString("dd/MM/yyyy HH:mm:ss")), ConsoleColor.White);

            Console.WriteLine("\n");
            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.DarkGreen, ConsoleColor.DarkGreen);

            Console.WriteLine("\nPress any key to continue ...");
            Console.ReadKey();
        }
    }
}
