using Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Repository;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AutoMapper;

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
        public async Task<IEnumerable<Product>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            return await _productService.GetAllProducts(desc, minPrice, maxPrice, categoryIds);
          //להחזיר מה סוג הפעולה מה הסטטוס

        }

    }
}
