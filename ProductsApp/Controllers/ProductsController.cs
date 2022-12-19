using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using ProductsApp.Domain.Requets;
using ProductsApp.Domain.Responses;
using ProductsApp.Domain.Services;
using System.Net;

namespace ProductsApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IProductService _productService { get; }
        public ICartService _cartService { get; }

        /// <summary>
        /// 
        /// </summary>
        public ProductsController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GeneralResponse<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(GeneralResponse<Product>))]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _productService.GetProductAsync(id);
            if (result == null)
                return StatusCode(404, result);

            return Ok(result);
        }

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GeneralResponse<Product>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(201, Type = typeof(GeneralResponse<Product>))]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProduct request)
        {
            var response = await _productService.AddProductAsync(request);

            if (response.Data == null)
                return StatusCode(response.Code, response);

            return CreatedAtAction(nameof(GetProduct),
                new { id = response.Data.Id }, response);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(Cart))]
        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProductsAsync();

            if (response == null)
                return StatusCode(400, response);

            return Ok(response);
        }

        /// <summary>
        /// Add a product to Cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GeneralResponse<CartItem>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(201, Type = typeof(GeneralResponse<CartItem>))]
        [HttpPost()]
        public async Task<IActionResult> AddProductToCart(AddProductToCart request)
        {
            var response = await _cartService.AddToCart(request);

            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Get Cart products
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(GeneralResponse<Cart>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(GeneralResponse<Cart>))]
        [HttpGet()]
        public async Task<IActionResult> GetCartProducts()
        {
            var cart = await _cartService.GetCartProducts();

            return StatusCode(cart.Code, cart);
        }

        /// <summary>
        /// Get the sum of all products added to Cart
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(GeneralResponse<CartSum>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(GeneralResponse<CartSum>))]
        [HttpGet()]
        public IActionResult GetCartProductsTotalPrice()
        {
            var sum = _cartService.GetCartSum();

            return StatusCode(sum.Code, sum);
        }


        /// <summary>
        /// Search Product by name
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [HttpPost()]
        public async Task<IActionResult> SearchProduct(SearchProduct request)
        {
            var response = await _productService.SearchProductsAsync(request);

            if (response == null)
                return StatusCode(400, response);

            return Ok(response);
        }

        /// <summary>
        /// Remove Product from Cart
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(GeneralResponse<CartSum>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(GeneralResponse<CartSum>))]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            var response = await _cartService.Delete(id);

            return StatusCode(response.Code, response);
        }

    }
}
