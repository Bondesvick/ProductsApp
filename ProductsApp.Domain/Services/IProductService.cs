using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Requets;
using ProductsApp.Domain.Responses;
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

        Task<GeneralResponse<Product>> GetProductAsync(Guid id);

        Task<GeneralResponse<Product>> AddProductAsync(AddProduct request);

        Task<Product> EditProductAsync(Product request);

        Task<Product> DeleteProductAsync(Guid id);
        Task<IEnumerable<Product>> SearchProductsAsync(SearchProduct request);
    }
}
