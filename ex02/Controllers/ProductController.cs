using Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using AutoMapper;
using Entities;
using Dto;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;

        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {

            IEnumerable<Product> products = await _productService.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
            if (productsDto.Count() == 0)
            {
                return NoContent();
            }

            return Ok(productsDto);
            //להחזיר מה סוג הפעולה מה הסטטוס

        }

    }
}
