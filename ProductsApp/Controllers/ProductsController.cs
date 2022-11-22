using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Domain.Entities;
using ProductsApp.Domain.Repositories;
using ProductsApp.Domain.Requets;
using ProductsApp.Domain.Services;
using System.Net;

namespace ProductsApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public IProductService _productService { get; }

        /// <summary>
        /// 
        /// </summary>
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(Product))]
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
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        [ProducesResponseType(201, Type = typeof(Product))]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProduct request)
        {
            var response = await _productService.AddProductAsync(request);

            if (response == null)
                return StatusCode(400, response);

            return CreatedAtAction(nameof(GetProduct),
                new { id = response.Id }, response);
        }

        /// <summary>
        /// Add a product to Cart
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.Created)]
        [ProducesResponseType(201, Type = typeof(Cart))]
        [HttpPost("AddProductToCart")]
        public IActionResult AddProductToCart(AddProductToCart request)
        {
            return Ok();
        }

        /// <summary>
        /// Get all products Added to Cart
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Cart), (int)HttpStatusCode.Created)]
        [ProducesResponseType(200, Type = typeof(Cart))]
        [HttpGet("GetCartProducts")]
        public IActionResult GetCartProducts()
        {
            return Ok();
        }
       
        /// <summary>
        /// Get the sum of all products added to Cart
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCartProductsTotalPrice")]
        public IActionResult GetCartProductsTotalPrice()
        {
            return Ok();
        }


        /// <summary>
        /// Search Product by name
        /// </summary>
        /// <returns></returns>
        [HttpPost("SearchProduct")]
        public IActionResult SearchProduct(SearchProduct searchProduct)
        {
            return Ok();
        } 
        
        /// <summary>
        /// Remove Product from Cart
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteCartItem/{id:guid}")]
        public IActionResult DeleteCartItem(Guid id)
        {
            return Ok();
        }

    }
}
