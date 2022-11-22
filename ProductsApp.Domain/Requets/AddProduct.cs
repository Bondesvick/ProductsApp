using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Requets
{
    public class AddProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
