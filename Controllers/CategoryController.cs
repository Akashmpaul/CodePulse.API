using AutoMapper;
using CodePulse.API.Models.DomainModels;
using CodePulse.API.Models.DTO_S;
using CodePulse.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddcategoryDto addcategoryDto)
        {
            // map add category dto with category model
            var categoryModel = mapper.Map<Category>(addcategoryDto);

            categoryModel = await categoryRepository.CreatecategoryAsync(categoryModel);

            // map category model to DTO
            var categoryDto = mapper.Map<CategoryDto>(categoryModel);

            return Ok(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await categoryRepository.GetAllCategoryAsync();

            //map domain model to DTO
            var categoriesDto = mapper.Map<List<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }
    }
}
