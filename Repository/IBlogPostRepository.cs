using CodePulse.API.Models.DomainModels;

namespace CodePulse.API.Repository
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost);
        Task<BlogPost?> UpdateBlogPostAsync(Guid id, BlogPost blogPost);
        Task<BlogPost?> DeleteBlogPostAsync(Guid id);
        Task<List<BlogPost>> GetAllBlogPostAsync();
        Task<BlogPost?> GetBlogPostByIdAsync(Guid id);

    }
}
