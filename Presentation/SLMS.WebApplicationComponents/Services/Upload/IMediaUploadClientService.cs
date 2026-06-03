using Microsoft.AspNetCore.Components.Forms;
using SLMS.Dto.Media;

namespace SLMS.WebApplicationComponents.Services.Upload
{
    public interface IMediaUploadClientService
    {
        Task<MediaAssetDto?> UploadFileAsync(IBrowserFile file, CancellationToken cancellationToken = default);
        Task<List<MediaAssetDto>> UploadFilesAsync(IEnumerable<IBrowserFile> files, CancellationToken cancellationToken = default);
        bool IsSupportedMediaType(IBrowserFile file);
    }
}
