using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Infrastructure.Repositories;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var Product = new ProductRepository().GetProducts();
            return Ok(Product);
        }
    }
}
