using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public int categoryId { get; set; }
    }
}
