using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Core.Interfaces;
using Products.Infrastructure.Repositories;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var Products = await _productRepository.GetProducts();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var Product = await _productRepository.GetProduct(id);
            return Ok(Product);
        }
    }
}
