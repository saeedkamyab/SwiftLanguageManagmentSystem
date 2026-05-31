using SLMS.WebApplicationComponents.Services.Media.Interface;

namespace SLMS.WebApplicationComponents.Services.Media
{

    public class MediaService : IMediaService
    {
        private readonly HttpClient _httpClient;

        public MediaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> UploadFileAsync(MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync("api/v1/UploadFile/upload", content);
            return response;
        }
    }


}
