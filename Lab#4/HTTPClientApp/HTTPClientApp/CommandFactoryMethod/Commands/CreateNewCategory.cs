using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class CreateNewCategory : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter name of new category: ", ConsoleColor.DarkBlue);
            var categoryName = Console.ReadLine();

            var response = HttpClientService.PostCategory(categoryName);

            if (response.Status)
            {
                ConsoleUtils.PrintWithColour($"Category {categoryName} was added successfully!", ConsoleColor.DarkGreen);
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
