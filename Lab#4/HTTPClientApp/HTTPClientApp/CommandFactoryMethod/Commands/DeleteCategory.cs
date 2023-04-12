using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class DeleteCategory : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter id of category to delete it: ", ConsoleColor.DarkBlue);
            var categoryId = Console.ReadLine();

            var response = HttpClientService.DeleteCategory(Int32.Parse(categoryId));

            if (response.Status)
            {
                ConsoleUtils.PrintWithColour($"Category with ID: {categoryId} was deleted successfully!", ConsoleColor.DarkGreen);
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
