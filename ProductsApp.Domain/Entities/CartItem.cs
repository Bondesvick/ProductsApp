using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Entities
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Cart Cart { get; set; }
        public Guid CartId { get; set; }
    }
}
