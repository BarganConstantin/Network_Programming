using Helpers;
using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ConsoleUtils.PrintWithColour("View Category Details\nCategory name: ", ConsoleColor.DarkBlue);
                var categoryName = Console.ReadLine();

                bool categoryFound = printCategoryDetails(response.Categories, categoryName);

                if (!categoryFound) ConsoleUtils.PrintWithColour("Category not found!", ConsoleColor.DarkRed);
            }
            else
            {
                ConsoleUtils.PrintWithColour(response.StatusMsg, ConsoleColor.DarkRed);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private bool printCategoryDetails(List<Category> categories, string categoryName)
        {
            bool categoryFound = false;
            foreach (var category in categories)
            {
                if (category.name.ToLower().Contains(categoryName.ToLower()))
                {
                    ConsoleUtils.PrintWithColour($" Id: {category.id} \n Name: {category.name} \n ItemsCount: {category.itemsCount}\n\n", ConsoleColor.DarkGreen);
                    categoryFound = true;
                }
            }
            return categoryFound;
        }
    }
}
