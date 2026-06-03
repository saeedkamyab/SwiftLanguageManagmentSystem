using Microsoft.AspNetCore.Http;
using SLMS.Dto.Media;

namespace SLMS.Application.Contracts.FileService
{
    public interface IMediaUploadService
    {
        Task<MediaAssetDto> UploadAsync(IFormFile file, CancellationToken cancellationToken);
    }
}
