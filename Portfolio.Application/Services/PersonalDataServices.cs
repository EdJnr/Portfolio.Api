using AutoMapper;
using MongoDB.Bson;
using Portfolio.Application.Dtos.PersonalData;
using Portfolio.Application.Interfaces;
using Portfolio.Application.Interfaces.Services;
using Portfolio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Application.Services
{
    public class PersonalDataServices : IPersonalDataServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonalDataServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private ObjectId parseId(string id)
        {
            var Id = ObjectId.Parse(id);
            return Id;
        }

        public async Task<bool> CreatePersonalDataAsync(CreatePersonalDataDto dto)
        {
            //initial check if record exists
            var PersonalDataRecord = await _unitOfWork.PersonalData.GetAllAsync();
            if (PersonalDataRecord.Count == 0)
            {
                var model = _mapper.Map<PersonalDataEntity>(dto);
                bool response = await _unitOfWork.PersonalData.CreateAsync(model);

                return response;
            }

            throw new ValidationException("A record already exist for Personal Data.Please delete the existing to add a new one or update it.\n Personal data accepts only one record at a time");
        }

        public async Task<bool> DeletePersonalDataAsync(string id)
        {
            var result = await _unitOfWork.PersonalData.DeleteAsync(parseId(id));

            return result;
        }

        public async Task<IReadOnlyList<GetPersonalDataDto>> GetPersonalDataAsync()
        {
            var FromDb = await _unitOfWork.PersonalData.GetAllAsync();

            var result = _mapper.Map<IReadOnlyList<GetPersonalDataDto>>(FromDb);
            return result;
        }

        public Task<bool> UpdatePersonalDataAsync(string id, UpdatePersonalDataDto dto)
        {
            var model = _mapper.Map<PersonalDataEntity>(dto);

            var result = _unitOfWork.PersonalData.UpdateAsync(parseId(id), model);
            return result;
        }
    }
}
