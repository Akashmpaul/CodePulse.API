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

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var categoryId = await categoryRepository.GetCategoryByIdAsync(Id);
            if(categoryId == null)
            {
                return NotFound();
            }

            return Ok(categoryId);
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> Deletecategory(Guid Id)
        {
            var categoryId = await categoryRepository.DeletecategoryAsync(Id);
            if(categoryId == null) 
            {
                return NotFound();
            }
            return Ok(categoryId);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            //map dto to domain model
            var categoryDomainModel = mapper.Map<Category>(updateCategoryDto);

            categoryDomainModel = await categoryRepository.UpdatecategoryAsync(id, categoryDomainModel);
            if(categoryDomainModel == null) 
            {
                return NotFound();
            }

            //map domain model to DTO
            var categoryDto = mapper.Map<CategoryDto>(categoryDomainModel);
            return Ok(categoryDto);
        }
    }
}
