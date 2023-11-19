using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
