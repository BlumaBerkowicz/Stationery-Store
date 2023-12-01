using AutoMapper;
using Dto;
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
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;

        }


        // GET api/<RegisterAndLogin>/5
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            IEnumerable<Category> categories=await _categoryService.GetAllCategories();
            IEnumerable<CategoryDto> categoryDtos = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
            return Ok(categoryDtos);
        }

    }
}
