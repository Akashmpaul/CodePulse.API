using CodePulse.API.Data;
using CodePulse.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CodePulseDbContext codePulseDbContext;

        public CategoryRepository(CodePulseDbContext codePulseDbContext)
        {
            this.codePulseDbContext = codePulseDbContext;
        }
        public async Task<Category> CreatecategoryAsync(Category category)
        {
            await codePulseDbContext.Categories.AddAsync(category);
            await codePulseDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
           return await codePulseDbContext.Categories.ToListAsync();
        }
    }
}
