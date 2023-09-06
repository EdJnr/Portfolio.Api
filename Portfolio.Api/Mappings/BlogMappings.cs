using AutoMapper;
using Portfolio.Application.Dtos.Blog;
using Portfolio.Domain.Entities;

namespace Portfolio.Api.Mappings
{
    public class BlogMappings : Profile
    {
        public BlogMappings()
        {
            CreateMap<GetBlogDto, BlogEntity>().ReverseMap();

            CreateMap<CreateBlogDto, BlogEntity>().ReverseMap();

            CreateMap<UpdateBlogDto, BlogEntity>().ReverseMap();
        }
    }
}
