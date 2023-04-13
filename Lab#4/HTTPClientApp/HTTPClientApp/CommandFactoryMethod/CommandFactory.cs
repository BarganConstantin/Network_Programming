using Helpers;
using HTTPClientApp.CommandFactoryMethod;
using HTTPClientApp.CommandFactoryMethod.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.CommandFactoryMethod
{
    public static class CommandFactory
    {
        public static Dictionary<string, ICommand> _actionMap = new Dictionary<string, ICommand>()
        {
            { "1", new PrintCategoryList() },
            { "2", new PrintCategoryDetail() },
            { "3", new CreateNewCategory() },
            { "4", new DeleteCategory() },
            { "5", new ChangeCategoryTitle() },
            { "6", new CreateNewProductInCategory() },
            { "7", new PrintProductsInCategory() },
            { "0", new CloseHttpClientApp() },
        };

        public static ICommand GetCommand(string option)
        {
            if (_actionMap.ContainsKey(option))
            {
                return _actionMap[option];
            }
            return new PrintErrorCommand();
        }

        public static void printCommandMenu()
        {
            ConsoleUtils.PrintOnCenterWithColour("Available Commands", ConsoleColor.White, ConsoleColor.Green);
            ConsoleUtils.PrintWithColour("\n 1 - enumerate the list of categories\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 2 - show details about a category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 3 - create a new category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 4 - delete a category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 5 - change the title of a category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 6 - create new products in a category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 7 - see the list of products in a category\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintWithColour(" 0 - exit\n\n", ConsoleColor.DarkBlue);
            ConsoleUtils.PrintEmptyColourLine(ConsoleColor.White, ConsoleColor.Green);
            ConsoleUtils.PrintWithColour("\n Enter option: ", ConsoleColor.White);
        }
    }
}
