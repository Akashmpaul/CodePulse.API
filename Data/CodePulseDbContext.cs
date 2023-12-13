using CodePulse.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data
{
    public class CodePulseDbContext : DbContext
    {
        private readonly DbContextOptions dbContext;

        public CodePulseDbContext(DbContextOptions<CodePulseDbContext> dbContextOptions) : base(dbContextOptions)
        {
            this.dbContext = dbContext;
        }

        public DbSet<Category> Categories { get; set; } 
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
