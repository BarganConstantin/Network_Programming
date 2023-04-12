using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Available Category:");
                foreach (var category in Categories)
                {
                    Console.WriteLine($" - {category.name}");
                }
            }
            else
            {
                Console.WriteLine("Service don't have any category!");
            }
        }
    }
}
