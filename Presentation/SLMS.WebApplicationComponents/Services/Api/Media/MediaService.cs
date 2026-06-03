using SLMS.WebApplicationComponents.Services.Api.Media.Interface;

namespace SLMS.WebApplicationComponents.Services.Api.Media
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
            var response = await _httpClient.PostAsync("api/v1/File/upload", content);
            return response;
        }
    }


}
