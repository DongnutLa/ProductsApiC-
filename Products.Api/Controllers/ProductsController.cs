using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Products.Core.DTOs;
using Products.Core.Entities;
using Products.Core.Interfaces;

namespace Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.PostProduct(product);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.UpdateProduct(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _productService.DeleteProduct(id);
            return Ok(res);
        }
    }
}
