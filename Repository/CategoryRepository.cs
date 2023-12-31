﻿using CodePulse.API.Data;
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

        public async Task<Category?> DeletecategoryAsync(Guid id)
        {
            var categoryId = await codePulseDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(categoryId == null)
            {
                return null;
            }

             codePulseDbContext.Categories.Remove(categoryId);
            await codePulseDbContext.SaveChangesAsync();
            return categoryId;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await codePulseDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);

            //if(categoryId == null)
            //{
            //    return null;
            //}

            //return await codePulseDbContext.Categories.FindAsync(categoryId);

        }

        public async Task<Category?> UpdatecategoryAsync(Guid id, Category category)
        {
            var categoryId = await codePulseDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(categoryId == null) 
            {
                return null;
            }
            categoryId.Name = category.Name;
            categoryId.UrlHandle = category.UrlHandle;
            await codePulseDbContext.SaveChangesAsync();
            return categoryId;
        }
    }
}
