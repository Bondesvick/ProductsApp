using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ProductsController()
        {

        }

        [HttpPost]
        public IActionResult AddProduct()
        {
            return Ok();
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProduct(Guid id)
        {
            return Ok();
        }

        [HttpPost("AddProductToCart")]
        public IActionResult AddProductToCart()
        {
            return Ok();
        }

        [HttpGet("GetCartProducts")]
        public IActionResult GetCartProducts()
        {
            return Ok();
        }
       
        [HttpGet("GetCartProductsTotalPrice")]
        public IActionResult GetCartProductsTotalPrice()
        {
            return Ok();
        }

    }
}
