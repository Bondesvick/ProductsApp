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

        public async Task<CartItem> AddToCart(CartItem item)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync();

            item.CartId = cart.Id;
            var entity = await _context.CartItems.AddAsync(item);

            return entity.Entity;
        }

        public async Task<CartItem?> GetCartItemAsync(Guid id)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(s => s.Id == id);

            if (cartItem == null) return null;

            return cartItem;
        }

        public async Task<Cart?> GetAsync()
        {
            return await _context.Carts.Include(x => x.CartItems).FirstOrDefaultAsync();
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
