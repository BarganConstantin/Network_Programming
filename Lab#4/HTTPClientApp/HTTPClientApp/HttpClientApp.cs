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
                CommandFactory.printCommandMenu();
                var option = Console.ReadLine();

                ICommand command = CommandFactory.GetCommand(option);

                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
