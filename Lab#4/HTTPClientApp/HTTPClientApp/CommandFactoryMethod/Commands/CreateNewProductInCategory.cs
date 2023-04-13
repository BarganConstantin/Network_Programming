using Helpers;
using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod.Commands
{
    public class CreateNewProductInCategory : ICommand
    {
        public void Execute()
        {
            var newProduct = createNewProduct();

            var response = HttpClientService.PostProduct(newProduct);

            if (response.Status)
            {
                ConsoleUtils.PrintWithColour($"Product {newProduct.title} was added successfully!", ConsoleColor.DarkGreen);
            }
            else
            {
                ConsoleUtils.PrintWithColour(response.StatusMsg, ConsoleColor.DarkRed);
            }

            Console.ReadKey();
            Console.Clear();
        }

        private NewProduct createNewProduct()
        {
            Console.Clear();
            ConsoleUtils.PrintWithColour("Enter data for new Product\nName: ", ConsoleColor.DarkBlue);
            var productName = Console.ReadLine();
            ConsoleUtils.PrintWithColour("Price: ", ConsoleColor.DarkBlue);
            var productPrice = Console.ReadLine();
            ConsoleUtils.PrintWithColour("Product category ID: : ", ConsoleColor.DarkBlue);
            var categoryId = Console.ReadLine();

            var newProduct = new NewProduct()
            {
                title = productName,
                price = Double.Parse(productPrice),
                categoryId = Int32.Parse(categoryId)
            };

            return newProduct;
        }
    }
}
