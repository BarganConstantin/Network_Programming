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
    }
}
