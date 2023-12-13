using CodePulse.API.Data;
using CodePulse.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly CodePulseDbContext codePulseDbContext;

        public BlogPostRepository(CodePulseDbContext codePulseDbContext)
        {
            this.codePulseDbContext = codePulseDbContext;
        }

        public async Task<BlogPost> CreateBlogPostAsync(BlogPost blogPost)
        {
           await codePulseDbContext.BlogPosts.AddAsync(blogPost);
            await codePulseDbContext.SaveChangesAsync();    
            return blogPost;
        }

        public async Task<BlogPost?> DeleteBlogPostAsync(Guid id)
        {
            var blogPost = await codePulseDbContext.BlogPosts.FirstOrDefaultAsync(c => c.Id == id);
            if (blogPost == null) 
            {
                return null;
            }
            codePulseDbContext.BlogPosts.Remove(blogPost);
            await codePulseDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<List<BlogPost>> GetAllBlogPostAsync()
        {
            return await codePulseDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost?> GetBlogPostByIdAsync(Guid id)
        {
            return await codePulseDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost?> UpdateBlogPostAsync(Guid id, BlogPost blogPost)
        {
            var updateBlogPost = await codePulseDbContext.BlogPosts.FirstOrDefaultAsync(c => c.Id ==id);
            if (blogPost == null) 
            {
                return null;
            }

            updateBlogPost.Title = blogPost.Title;
            updateBlogPost.ShortDescription = blogPost.ShortDescription;
            updateBlogPost.Content = blogPost.Content;
            updateBlogPost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
            updateBlogPost.UrlHandle = blogPost.UrlHandle;
            updateBlogPost.PublishedDate = blogPost.PublishedDate;
            updateBlogPost.Author = blogPost.Author;
            updateBlogPost.IsVisible = blogPost.IsVisible;

            await codePulseDbContext.SaveChangesAsync();
            return blogPost;
        }
    }
}
