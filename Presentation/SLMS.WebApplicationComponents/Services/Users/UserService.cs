using SLMS.Dto.User;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.Users.Interface;

namespace SLMS.WebApplicationComponents.Services.Users
{

    public class UserService : IUserService
    {
        private readonly BaseApiService _baseApiService;
        public UserService(BaseApiService baseApiService)
        {
            _baseApiService = baseApiService;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await _baseApiService.GetAllAsync<List<UserDto>>("/api/v1/user");
        }
    }


}
