using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Entities
{
    public class User : IdentityUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Cart Cart { get; set; }
        public Guid CartId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
