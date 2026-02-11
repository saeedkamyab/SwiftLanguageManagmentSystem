using AutoMapper;
using SLMS.ApplicationCore.Domain.PersonManagement;
using SLMS.Dto.PersonManagement;

namespace SLMS.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region  PersonManagment
            CreateMap<Person, PersonDto>().ReverseMap();
            #endregion
        }
    }
}
