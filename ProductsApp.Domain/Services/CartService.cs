using ProductsApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Services
{
    public class CartService : ICartService
    {
        public CartService(ICartRepository cartRepository)
        {
            CartRepository = cartRepository;
        }

        public ICartRepository CartRepository { get; }
    }
}
