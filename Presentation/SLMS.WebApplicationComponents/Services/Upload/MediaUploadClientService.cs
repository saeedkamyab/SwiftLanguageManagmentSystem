using Microsoft.AspNetCore.Components.Forms;
using SLMS.Dto.Media;
using SLMS.WebApplicationComponents.Services.Api.Media;
using SLMS.WebApplicationComponents.Services.Api.Media.Interface;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace SLMS.WebApplicationComponents.Services.Upload
{
    public class MediaUploadClientService : IMediaUploadClientService
    {
        private const long MaxAllowedSize = 500 * 1024 * 1024;
        private readonly IMediaService _mediaService;
        public MediaUploadClientService(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }
        public bool IsSupportedMediaType(IBrowserFile file)
        {
            return file.ContentType.StartsWith("image/") ||
               file.ContentType.StartsWith("video/");
        }

        public async Task<MediaAssetDto?> UploadFileAsync(IBrowserFile file, CancellationToken cancellationToken = default)
        {
            if (!IsSupportedMediaType(file))
                return null;

            using var content = BuildMultipartFormData(file);

            var response = await _mediaService.UploadFileAsync(content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync(cancellationToken);
                Console.WriteLine($"Upload failed: {response.StatusCode} - {error}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<MediaAssetDto>(cancellationToken: cancellationToken);

        }

        public async Task<List<MediaAssetDto>> UploadFilesAsync(IEnumerable<IBrowserFile> files, CancellationToken cancellationToken = default)
        {
            var results = new List<MediaAssetDto>();

            foreach (var file in files)
            {
                var media = await UploadFileAsync(file, cancellationToken);
                if (media is not null)
                {
                    results.Add(media);
                }
            }

            return results;
        }
        private static MultipartFormDataContent BuildMultipartFormData(IBrowserFile file)
        {
            var content = new MultipartFormDataContent();

            var streamContent = new StreamContent(file.OpenReadStream(MaxAllowedSize));
            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, "file", file.Name);

            return content;
        }
    }
}
