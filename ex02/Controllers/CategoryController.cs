using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ex02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryService.GetAllCategories();
        }

    }
}
