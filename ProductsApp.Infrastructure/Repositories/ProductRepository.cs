using Microsoft.EntityFrameworkCore;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Product Add(Product product)
        {
            return _context.Products.Add(product).Entity;
        }

        public Product Delete(Product product)
        {
            _context.Products.Remove(product);

            return product;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await _context.Products
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            var product = await _context.Products.Where(s => s.Id == id)
               .AsNoTracking().FirstOrDefaultAsync();

            if (product == null) return null;

            _context.Entry(product).State = EntityState.Detached;
            return product;
        }

        public Product Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return product;
        }

        public async Task<IEnumerable<Product>> Search(string name)
        {
            var products = _context.Products.Where(s => s.Name.ToLower().Contains(name.ToLower()));

            if (products == null) return null;

            //_context.Entry(products).State = EntityState.Detached;
            return products.ToList();
        }

        public async Task<Product?> GetProductByName(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            return product;
        }
    }
}
