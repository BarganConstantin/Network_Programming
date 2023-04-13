using Helpers;
using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class PrintProductsInCategory : ICommand
    {
        public void Execute()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("View Category Products\nCategory ID: ", ConsoleColor.DarkBlue);
            var categoryId = Console.ReadLine();

            var response = HttpClientService.GetProducts(Int32.Parse(categoryId));

            if (response.Status)
            {
                printProductsList(response.Products);
            }
            else
            {
                ConsoleUtils.PrintWithColour(response.StatusMsg, ConsoleColor.DarkRed);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void printProductsList(List<Product> products)
        {
            if (products.Count < 1)
            {
                ConsoleUtils.PrintWithColour("Category is empty!", ConsoleColor.DarkMagenta);
            }
            else
            {
                foreach (var product in products)
                {
                    ConsoleUtils.PrintWithColour($"ID: {product.id} Name: {product.title} Price: {product.price}\n", ConsoleColor.DarkMagenta);
                }
            }
        }
    }
}
