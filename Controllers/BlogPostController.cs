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

        // Get all blog post
        // Get
        [HttpGet]
        public async Task<IActionResult> GetAllBlogPost()
        {
            var blogPost = await blogPostRepository.GetAllBlogPostAsync();

            //map domain  model with dto
            var blogPostDto = mapper.Map<List<BlogPostDto>>(blogPost);
            return Ok(blogPostDto);
        }

        //Get blog post by id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var blogPostId = await blogPostRepository.GetBlogPostByIdAsync(id);
            if(blogPostId == null)
            {
                return NotFound();
            }
            return Ok(blogPostId);
        }

        //update blog post
    }
}
