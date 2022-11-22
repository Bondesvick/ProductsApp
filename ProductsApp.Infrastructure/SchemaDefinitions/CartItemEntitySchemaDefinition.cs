using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infrastructure.SchemaDefinitions
{
    public class CartItemEntitySchemaDefinition : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItem");

            builder
                .HasOne(e => e.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CartId);

            builder
                .HasOne(e => e.Product)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CartId);
        }
    }
}
