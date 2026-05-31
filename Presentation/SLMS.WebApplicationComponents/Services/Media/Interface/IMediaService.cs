using SLMS.Dto.User;

namespace SLMS.WebApplicationComponents.Services.Media.Interface
{
    public interface IMediaService
    {
        Task<HttpResponseMessage> UploadFileAsync(MultipartFormDataContent content);
    }
}
