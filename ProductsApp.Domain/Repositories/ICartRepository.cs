using ProductsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Repositories
{
    public interface ICartRepository : IRepository
    {
        CartItem AddToCart(CartItem item);
        CartItem Delete(CartItem item);
        Task<CartItem> GetCartItemAsync(Guid id);
        Task<CartItem> GetCartItemByProductId(Guid id);
        decimal SumCartTotal();
    }
}
