using AutoMapper;
using SLMS.ApplicationCore.Domain.PersonManagment;
using SLMS.Dto.PersonManagment;

namespace SLMS.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region  PersonMapping
            CreateMap<Person, PersonDto>().ReverseMap();
            #endregion
        }
    }
}
