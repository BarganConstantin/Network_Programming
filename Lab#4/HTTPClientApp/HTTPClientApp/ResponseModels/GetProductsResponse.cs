using HTTPClientApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPClientApp.ResponseModels
{
    public class GetProductsResponse
    {
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
        public List<Product> Products { get; set; }
    }
}
