using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Entities
{
    public class Cart
    {
        public Guid Id { get; set; }
        public User Owner { get; set; }
        public Guid OwnerId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
