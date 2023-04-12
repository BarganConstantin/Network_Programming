using Helpers;
using HTTPClientApp.CommandFactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp
{
    public class HttpClientApp
    {
        public HttpClientApp() 
        {
        }

        public void Run()
        {
            while (true)
            {
                printHttpClientMenu();
                var option = Console.ReadLine();

                ICommand command = CommandFactory.GetCommand(option);
                command.Execute();
            }
        }

        private void printHttpClientMenu()
        {
            Console.WriteLine("1 - enumerate the list of categories");
            Console.WriteLine("2 - show details about a category");
            Console.WriteLine("3 - create a new category");
            Console.WriteLine("4 - delete a category");
            Console.WriteLine("5 - change the title of a category");
            Console.WriteLine("6 - create new products in a category");
            Console.WriteLine("7 - see the list of products in a category");
            Console.WriteLine("0 - exit");
        }
    }
}
