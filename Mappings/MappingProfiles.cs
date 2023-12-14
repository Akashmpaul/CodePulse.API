using AutoMapper;
using CodePulse.API.Models.DomainModels;
using CodePulse.API.Models.DTO_S;

namespace CodePulse.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddcategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            CreateMap<AddBlogPostDto, BlogPost>().ReverseMap();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
        }
    }
}
