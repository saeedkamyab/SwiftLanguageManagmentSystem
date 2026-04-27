using SLMS.Dto.User;

namespace SLMS.WebApplicationComponents.Services.Users.Interface
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
