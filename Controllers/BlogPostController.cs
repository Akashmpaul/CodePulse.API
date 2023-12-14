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
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IMapper mapper;

        public BlogPostController(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            this.blogPostRepository = blogPostRepository;
            this.mapper = mapper;
        }

        // Create blogpost
        // POST
        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] AddBlogPostDto addBlogPostDto)
        {
            //map dto to domain model
            var blogPostDomainModel = mapper.Map<BlogPost>(addBlogPostDto);

            blogPostDomainModel = await blogPostRepository.CreateBlogPostAsync(blogPostDomainModel);

            //map domail model to dto
            var blogPostDto = mapper.Map<BlogPostDto>(blogPostDomainModel);
            return Ok(blogPostDto);
        }
    }
}
