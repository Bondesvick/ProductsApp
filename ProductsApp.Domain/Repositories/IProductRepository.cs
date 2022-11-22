using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Repositories
{
    public interface IProductRepository : IRepository
    {
        Task<IEnumerable<Product>> GetAsync();

        Task<Product> GetAsync(Guid id);

        Product Add(Product product);

        Product Update(Product product);

        Product Delete(Product product);
        Task<IEnumerable<Product>> Search(string name);

        Task<Product> GetProductByName(string name);
    }
}
