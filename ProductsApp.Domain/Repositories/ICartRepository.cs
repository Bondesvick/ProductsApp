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
        Cart AddToCart(CartItem item);
        Task<CartItem> GetCartItemAsync(Guid id);
    }
}
