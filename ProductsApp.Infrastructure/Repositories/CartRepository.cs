using Microsoft.EntityFrameworkCore;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Cart AddToCart(CartItem item)
        {
            var cart = _context.Carts.FirstOrDefault();
            cart.CartItems.Add(item);

            _context.Entry(cart).State = EntityState.Modified;
            return cart;
        }

        public async Task<CartItem> GetCartItemAsync(Guid id)
        {
            var product = await _context.CartItems.Where(s => s.Id == id)
               .AsNoTracking().FirstOrDefaultAsync();

            if (product == null) return null;

            _context.Entry(product).State = EntityState.Detached;
            return product;
        }
    }
}
