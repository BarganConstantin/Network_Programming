using Helpers;
using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class PrintCategoryDetail : ICommand
    {
        public void Execute()
        {
            var response = HttpClientService.GetCategories();
            Console.Clear();

            if (response.Status)
            {
                ConsoleUtils.PrintWithColour("Category name: ", ConsoleColor.DarkBlue);
                var categoryName = Console.ReadLine();

                printCategoryDetails(response.Categories, categoryName);
            }
            else
            {
                ConsoleUtils.PrintWithColour(response.StatusMsg, ConsoleColor.DarkRed);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void printCategoryDetails(List<Category> categories, string categoryName)
        {
            Console.Clear();
            ConsoleUtils.PrintOnCenterWithColour("Category Details", ConsoleColor.White, ConsoleColor.Green);
            Console.WriteLine();

            bool categoryFound = false;
            foreach (var category in categories)
            {
                if (category.name.ToLower().Contains(categoryName.ToLower()))
                {
                    ConsoleUtils.PrintWithColour($" Id: {category.id} \n Name: {category.name} \n ItemsCount: {category.itemsCount}\n\n", ConsoleColor.DarkBlue);
                    categoryFound = true;
                }
            }
            if (!categoryFound) ConsoleUtils.PrintOnCenterWithColour("Category not found!\n", ConsoleColor.DarkRed, ConsoleColor.Black);

            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.White, ConsoleColor.Green);
            ConsoleUtils.PrintWithColour("\n Press any key to continue ... ", ConsoleColor.White);
        }
    }
}
