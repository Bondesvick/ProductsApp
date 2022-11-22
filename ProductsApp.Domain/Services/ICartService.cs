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
    public interface ICartService
    {
        Task<GeneralResponse<Cart?>> AddToCart(AddProductToCart item);
        Task<GeneralResponse<CartItem>> Delete(Guid id);
        GeneralResponse<CartSum> GetCartSum();
    }
}
