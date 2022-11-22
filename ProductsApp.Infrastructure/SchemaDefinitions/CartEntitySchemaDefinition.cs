using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infrastructure.SchemaDefinitions
{
    public class CartEntitySchemaDefinition : IEntityTypeConfiguration<Cart>
    {
        

        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");

            builder.HasKey(x => x.Id);

            var entries = new List<Cart>
            {
                new Cart
                {
                    Id = new Guid("6a14b08a-882d-4c94-9b66-9df7b06dd8e9"),
                    CartItems= new List<CartItem> {}
                }
            };

            builder.HasData(entries);

           
        }
    }
}
