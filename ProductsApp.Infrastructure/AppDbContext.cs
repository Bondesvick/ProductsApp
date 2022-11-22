using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using ProductsApp.Infrastructure.SchemaDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infrastructure
{
    public class AppDbContext : DbContext , IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {

            await SaveChangesAsync(cancellationToken);
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new CartEntitySchemaDefinition());
            modelBuilder.ApplyConfiguration(new CartItemEntitySchemaDefinition());
        }
      }
}
