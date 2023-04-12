using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class ChangeCategoryTitle : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter id of category: ", ConsoleColor.DarkBlue);
            var categoryId = Console.ReadLine();
            ConsoleUtils.PrintWithColour("Enter new category name: ", ConsoleColor.DarkBlue);
            var categoryName = Console.ReadLine();

            var response = HttpClientService.PutCategory(Int32.Parse(categoryId), categoryName);

            if (response.Status)
            {
                ConsoleUtils.PrintWithColour($"Category with ID: {categoryId} was updated successfully!", ConsoleColor.DarkGreen);
            }
            else
            {
                ConsoleUtils.PrintWithColour(response.StatusMsg, ConsoleColor.DarkRed);
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
