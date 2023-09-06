using AutoMapper;
using Portfolio.Application.Dtos.PersonalData;
using Portfolio.Domain.Entities;

namespace Portfolio.Api.Mappings
{
    public class PersonalDataMappings : Profile
    {
        public PersonalDataMappings()
        {
            CreateMap<GetPersonalDataDto, PersonalDataEntity>().ReverseMap();

            CreateMap<CreatePersonalDataDto, PersonalDataEntity>().ReverseMap();

            CreateMap<UpdatePersonalDataDto, PersonalDataEntity>().ReverseMap();
        }
    }
}
