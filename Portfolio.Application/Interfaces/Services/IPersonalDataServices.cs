using Portfolio.Application.Dtos.PersonalData;
using Portfolio.Application.Dtos.Projects;

namespace Portfolio.Application.Interfaces.Services
{
    public interface IPersonalDataServices
    {
        Task<IReadOnlyList<GetPersonalDataDto>> GetPersonalDataAsync();

        Task<bool> CreatePersonalDataAsync(CreatePersonalDataDto dto);

        Task<bool> UpdatePersonalDataAsync(string id, UpdatePersonalDataDto dto);

        Task<bool> DeletePersonalDataAsync(string id);
    }
}
