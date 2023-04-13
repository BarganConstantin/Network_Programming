using Helpers;
using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class PrintCategoryList : ICommand
    {
        public void Execute()
        {
            var response = HttpClientService.GetCategories();
            Console.Clear();

            if (response.Status) 
            {
                printCategoryList(response.Categories);
            }
            else
            {
                Console.WriteLine(response.StatusMsg);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void printCategoryList(List<Category> Categories) 
        {
            if (Categories.Count > 0)
            {
                ConsoleUtils.PrintOnCenterWithColour("Available Category", ConsoleColor.White, ConsoleColor.Green);
                Console.WriteLine();
                foreach (var category in Categories)
                {
                    ConsoleUtils.PrintWithColour($" - {category.name}\n", ConsoleColor.DarkBlue);
                }
                Console.WriteLine();
                ConsoleUtils.PrintEmptyColourLine(ConsoleColor.White, ConsoleColor.Green);
                ConsoleUtils.PrintWithColour("\n Press any key to continue ... ", ConsoleColor.White);
            }
            else
            {
                Console.WriteLine("Service don't have any category!");
            }
        }
    }
}
