using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Requets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(Guid id);

        Task<Product> AddProductAsync(AddProduct request);

        Task<Product> EditProductAsync(Product request);

        Task<Product> DeleteProductAsync(Guid id);
    }
}
