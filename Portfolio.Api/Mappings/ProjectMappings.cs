using AutoMapper;
using Portfolio.Application.Dtos.Projects;
using Portfolio.Domain.Entities;

namespace Portfolio.Api.Mappings
{
    public class ProjectMappings : Profile
    {
        public ProjectMappings()
        {
            CreateMap<GetProjectDto, ProjectEntity>().ReverseMap();

            CreateMap<CreateProjectDto, ProjectEntity>().ReverseMap();

            CreateMap<UpdateProjectDto, ProjectEntity>().ReverseMap();
        }
    }
}
