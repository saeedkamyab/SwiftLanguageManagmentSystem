using AutoMapper;
using SLMS.ApplicationCore.Domain.UserManagement;
using SLMS.Dto.UserManagement;

namespace SLMS.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region  UserManagment
            CreateMap<User, UserDto>().ReverseMap();
            #endregion
        }
    }
}
