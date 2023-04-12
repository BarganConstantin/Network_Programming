using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.Constants
{
    public static class UrlAddresses
    {
        public static string BaseAddress = "http://localhost:5000";
        public static string GetCategoryListAddress = "/api/Category/categories";
        public static string PostCategoryListAddress = "/api/Category/categories";
        public static string DeleteCategoryListAddress = "/api/Category/categories/";
        public static string PutCategoryListAddress = "/api/Category/";
    }
}
