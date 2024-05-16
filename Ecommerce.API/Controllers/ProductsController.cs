using E_commerce.API.Errors;
using E_commerce.API.Helper;
using E_Commerce.Domain.DataTransfareObject_DTO_;
using E_Commerce.Domain.Interfaces.Services;
using E_Commerce.Domain.Specification;
using E_Commerce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
                _productService = productService;
        }

        [HttpGet]
        [Cash(20)]
        public async Task<ActionResult<IEnumerable<ProductToReturnDTO>>> GetAllProducts([FromQuery]ProductSpesificationParamter product)
        {
          return Ok(await _productService.GetAllProductsAsync(product));   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProductsById(int id)
        {
            if (id == null) return BadRequest();
            var product= await _productService.GetProductByIdAsync(id);
            return  Ok(product) is not null?product:NotFound(new API_Response(404,$"The Product with Id {id} is not found"));
        }

        [HttpGet("Brand")]
        public async Task<ActionResult<IEnumerable<BrandTypeDto>>> GetBrand() 
        {
            return Ok(await _productService.GetAllBrandAsync());
        }

        [HttpGet("Type")]
        public async Task<ActionResult<IEnumerable<BrandTypeDto>>> GetType()
        {
            return Ok(await _productService.GetAllBrandAsync());
        }
    }
}
