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

        public CartItem AddToCart(CartItem item)
        {
            return _context.CartItems.Add(item).Entity;
        }

        public async Task<CartItem> GetCartItemAsync(Guid id)
        {
            var product = await _context.CartItems.Where(s => s.Id == id)
               .AsNoTracking().FirstOrDefaultAsync();

            if (product == null) return null;

            _context.Entry(product).State = EntityState.Detached;
            return product;
        }

        public async Task<CartItem> GetCartItemByProductId(Guid id)
        {
            var cart = await _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefaultAsync();

            var item =  cart.CartItems.FirstOrDefault(s => s.ProductId == id);

            if (item == null) return null;

            _context.Entry(item).State = EntityState.Detached;
            return item;
        }

        public CartItem? Delete(CartItem item)
        {
            var response = _context.CartItems.Remove(item);

            return item;
        }

        public Decimal SumCartTotal()
        {
            var cart = _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault();

            var sum = cart.CartItems.Sum(x => x.Product.Price);

            _context.Entry(cart).State = EntityState.Detached;
            return sum;
        }
    }
}
