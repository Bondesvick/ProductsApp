using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using ProductsApp.Domain.Requets;
using ProductsApp.Domain.Responses;
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

        public async Task<GeneralResponse<Product>> AddProductAsync(AddProduct request)
        {
            var existing = await _productRepository.GetProductByName(request.Name);

            if (existing != null) return new GeneralResponse<Product> {Message = "Product with Name already exist", Code = 400};

            var item = new Product
            {
                Name = request.Name,
                Price = request.Price,
            };

            try
            {
                var result = _productRepository.Add(item);
                await _productRepository.UnitOfWork.SaveChangesAsync();

                return new GeneralResponse<Product> { Data = result, Message = $"New Product {result.Name} successfully saved", Code = 201 };
            }
            catch (Exception e)
            {

                return new GeneralResponse<Product> { Message = $"An error occoured => {e.Message}", Code = 500 };
            }

            
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
            existingRecord.Name = request.Name;

            var result = _productRepository.Update(existingRecord);

            await _productRepository.UnitOfWork.SaveChangesAsync();
            return existingRecord;
        }

        public async Task<GeneralResponse<Product>> GetProductAsync(Guid id)
        {
            //if (id == null) throw new ArgumentNullException();
            var entity = await _productRepository.GetAsync(id);
            if (entity == null) return new GeneralResponse<Product> { Code = 404, Message = "Product not found" };
            return new GeneralResponse<Product>
            {
                Data = entity,
                Message = "successful",
                Code = 200
            };
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var result = await _productRepository.GetAsync();
            return result;
        } 
        
        public async Task<IEnumerable<Product>> SearchProductsAsync(SearchProduct request)
        {
            var result = await _productRepository.Search(request.Name);
            return result;
        }

        //public Categories GetCategories() {
        //    return Categories;
        //}
    }
}
