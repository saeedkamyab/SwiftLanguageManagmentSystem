using System.Net.Http.Json;

namespace SLMS.WebApplicationComponents.Services.Base
{
    public class BaseApiService
    {
        private readonly HttpClient _httpClient;

        public BaseApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAllAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public async Task PostAsync(string endpoint)
        {
            var response = await _httpClient.PostAsync(endpoint, null);
            response.EnsureSuccessStatusCode();
        }
        public async Task<bool>PostAsync<T>(string endpoint, T data)
        {
            var response=await _httpClient.PostAsJsonAsync(endpoint,data);
            return response.IsSuccessStatusCode;
        }
    }
}
