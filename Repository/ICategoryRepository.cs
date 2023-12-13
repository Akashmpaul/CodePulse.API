using CodePulse.API.Models.DomainModels;

namespace CodePulse.API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> CreatecategoryAsync(Category category);
    }
}
