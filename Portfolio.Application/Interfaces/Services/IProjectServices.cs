using Portfolio.Application.Dtos.Projects;

namespace Portfolio.Application.Interfaces.Services
{
    public interface IProjectServices
    {
        Task<IReadOnlyList<GetProjectDto>> GetAllProjectsAsync(string? searchText);

        Task<GetProjectDto> GetProjectByIdAsync(string id);

        Task<bool> CreateProjectAsync(CreateProjectDto dto);

        Task<bool> UpdateProjectAsync(string id, UpdateProjectDto dto);

        Task<bool> DeleteProjectAsync(string id);
    }
}
