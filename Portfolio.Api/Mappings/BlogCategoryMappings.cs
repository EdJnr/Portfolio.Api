using AutoMapper;
using Portfolio.Application.Dtos.BlogCategories;
using Portfolio.Domain.Entities;

namespace Portfolio.Api.Mappings
{
    public class BlogCategoryMappings : Profile
    {
        public BlogCategoryMappings() 
        {
            CreateMap<GetBlogCategoryDto, BlogCategoryEntity>().ReverseMap();

            CreateMap<CreateBlogCategoryDto, BlogCategoryEntity>().ReverseMap();

            CreateMap<UpdateBlogCategoryDto, BlogCategoryEntity>().ReverseMap();
        }
    }
}
