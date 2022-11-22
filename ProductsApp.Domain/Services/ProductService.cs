using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using ProductsApp.Domain.Requets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IProductRepository _productRepository { get; }

        public async Task<Product> AddProductAsync(AddProduct request)
        {
            var item = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Category = request.Category
            };

            var result = _productRepository.Add(item);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<Product> DeleteProductAsync(Guid id)
        {

            var result = await _productRepository.GetAsync(id);
            //result.IsInactive = true;

            _productRepository.Delete(result);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<Product> EditProductAsync(Product request)
        {
            var existingRecord = await _productRepository.GetAsync(request.Id);

            if (existingRecord == null) throw new ArgumentException($"Entity with {request.Id} is not present");

            existingRecord.Price = request.Price;
            existingRecord.Category = request.Category;
            existingRecord.Name = request.Name;

            var result = _productRepository.Update(existingRecord);

            await _productRepository.UnitOfWork.SaveChangesAsync();
            return existingRecord;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            //if (id == null) throw new ArgumentNullException();
            var entity = await _productRepository.GetAsync(id);
            return entity;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var result = await _productRepository.GetAsync();
            return result;
        }
    }
}
