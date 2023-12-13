using CodePulse.API.Models.DomainModels;

namespace CodePulse.API.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<Category> CreatecategoryAsync(Category category);
        Task<Category?> UpdatecategoryAsync(Guid id, Category category);
        Task<Category?> DeletecategoryAsync(Guid id);
    }
}
