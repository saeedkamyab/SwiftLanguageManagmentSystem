using SLMS.Dto.User;

namespace SLMS.WebApplicationComponents.Services.Api.Users.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
