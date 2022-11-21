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
        public Product Add(Product student)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product student)
        {
            throw new NotImplementedException();
        }
    }
}
