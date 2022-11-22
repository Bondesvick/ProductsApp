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
    public class ProductEntitySchemaDefinition : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");


            builder.Property(x => x.Name)
               .HasMaxLength(20)
               .IsRequired();

            builder.Property(x => x.Price)
              .HasColumnType("decimal(18,2)")
              .IsRequired();
        }
    }
}
