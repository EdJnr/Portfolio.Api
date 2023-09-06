using AutoMapper;
using MongoDB.Bson;
using Portfolio.Application.Dtos.Projects;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Interfaces.Services;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ObjectId parseId(string id)
        {
            var Id = ObjectId.Parse(id);
            return Id;
        }

        public async Task<bool> CreateProjectAsync(CreateProjectDto dto)
        {
            var model = _mapper.Map<ProjectEntity>(dto);

            var result = await _unitOfWork.Project.CreateAsync(model);
            return result;
        }

        public async Task<bool> DeleteProjectAsync(string id)
        {
            var Id = this.parseId(id);

            var result = await _unitOfWork.Project.DeleteAsync(Id);
            return result;
        }

        public async Task<IReadOnlyList<GetProjectDto>> GetAllProjectsAsync(string? searchText)
        {
            var FromDb = (searchText == null) ?
            await _unitOfWork.Project.GetAllAsync()
            :
            await _unitOfWork.Project.Query("Title", searchText);

            var results = _mapper.Map<IReadOnlyList<GetProjectDto>>(FromDb);
            return results;
        }

        public async Task<GetProjectDto> GetProjectByIdAsync(string id)
        {
            var Id = this.parseId(id);
            var FromDb = await _unitOfWork.Project.GetByIdAsync(Id);

            var result = _mapper.Map<GetProjectDto>(FromDb);
            return result;
        }

        public async Task<bool> UpdateProjectAsync(string id, UpdateProjectDto dto)
        {
            var Id = this.parseId(id);
            var model = _mapper.Map<ProjectEntity>(dto);

            var result = await _unitOfWork.Project.UpdateAsync(Id, model);
            return result;
        }
    }
}
