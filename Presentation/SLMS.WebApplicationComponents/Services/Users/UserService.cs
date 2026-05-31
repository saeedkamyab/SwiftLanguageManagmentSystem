using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.User;
using SLMS.WebApplicationComponents.Services.Base;
using SLMS.WebApplicationComponents.Services.Users.Interface;
using System.Net.Http.Json;

namespace SLMS.WebApplicationComponents.Services.Users
{

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("api/v1/user");
            return result ?? throw new InvalidOperationException("API returned empty response.");
        }
    }


}
