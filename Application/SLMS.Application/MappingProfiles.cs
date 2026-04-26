using AutoMapper;
using SLMS.ApplicationCore.Domain.User;
using SLMS.Dto.User;

namespace SLMS.Application
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region  UserManagment
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, UserDto>().ReverseMap();
            #endregion
        }
    }
}
