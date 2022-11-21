using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAsync();

        Task<Product> GetAsync(Guid id);

        Product Add(Product student);

        Product Update(Product student);

        Product Delete(Product student);
    }
}
