using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Products.Core.DTOs;
using Products.Core.Entities;
using Products.Core.Interfaces;
using Products.Core.QueryFilters;

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
        public IActionResult GetProducts([FromQuery] ProductQueryFilter filters)
        {
            var products = _productService.GetProducts(filters);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNextPage,
                products.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
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
            return new ObjectResult(product) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productService.UpdateProduct(product);
            return new ObjectResult(product) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
