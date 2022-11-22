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
    public class CartService : ICartService
    {
        public CartService(ICartRepository cartRepository, IProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }

        public ICartRepository _cartRepository { get; }
        public IProductService _productService { get; }

        public async Task<GeneralResponse<CartItem?>> AddToCart(AddProductToCart item)
        {
            var product = await _productService.GetProductAsync(item.ProductId);
            if (product.Data == null) return new GeneralResponse<CartItem?> { Message = product.Message, Code = product.Code};

            var cartItem = await _cartRepository.GetCartItemByProductId(item.ProductId);
            if (cartItem != null) return new GeneralResponse<CartItem?> { Message = "Product already exist in the cart", Code = 400 };

            try
            {
                var result = _cartRepository.AddToCart(new CartItem { ProductId = item.ProductId, });
                await _cartRepository.UnitOfWork.SaveChangesAsync();

                return new GeneralResponse<CartItem?> { Code = 201, Message = "Succcessful", Data = result };
            }
            catch (Exception e)
            {

                return new GeneralResponse<CartItem?> { Code = 500, Message = $"An error occured => {e.Message}" };
            }
            
        }

        public async Task<GeneralResponse<CartItem>> Delete(Guid id)
        {
            var item = await _cartRepository.GetCartItemAsync(id);
            if(item!= null) return new GeneralResponse<CartItem> { Code = 404, Message = "Item with id not found in Cart" };

            try
            {
                var result = _cartRepository.Delete(item);
                await _cartRepository.UnitOfWork.SaveChangesAsync();

                return new GeneralResponse<CartItem> { Code = 200, Message = "Item successfully deleted" };
            }
            catch (Exception e)
            {

                return new GeneralResponse<CartItem> { Code = 500, Message = $"An error occured => {e.Message}" };
            }
        }

        public GeneralResponse<CartSum> GetCartSum()
        {
            var sum = _cartRepository.SumCartTotal();
            return new GeneralResponse<CartSum> { Data = new CartSum { Sum = sum }, Message = "Successful", Code=200};
        }
    }
}
