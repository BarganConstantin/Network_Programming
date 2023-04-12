using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.ViewModels
{
    public class CategoryListResponse
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public List<Category> Categories { get; set; }
    }
}
