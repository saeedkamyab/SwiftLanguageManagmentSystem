using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SLMS.Application.Contracts.FileService;
using SLMS.Application.Features.Media.Commands;
using SLMS.Dto.Media;
using SLMS.Shared.Utilities;

namespace SLMS.Application.Services
{
    public class MediaUploadService : IMediaUploadService
    {
        private readonly IFileStorageService _fileStorage;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public MediaUploadService(
           IFileStorageService fileStorage,
           IMediator mediator,
           IConfiguration configuration)
        {
            _fileStorage = fileStorage;
            _mediator = mediator;
            _configuration = configuration;
        }
        public async Task<MediaAssetDto> UploadAsync(IFormFile file, CancellationToken cancellationToken)
        {

            if (file == null)
                throw new ArgumentNullException(nameof(file));

            if (file.Length == 0)
                throw new ArgumentException("فایل خالی است.", nameof(file));

            var id = Guid.NewGuid();
            var now = DateTime.UtcNow;
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var originalFileName = Path.GetFileName(file.FileName);
            var storedName = $"{id}{extension}";

            string baseDir = _configuration["FileStorage:UploadFolder"] ?? @"C:\SlmsUploads";
            string dateSubPath = Path.Combine(
                now.Year.ToString(), 
                now.Month.ToString("00"), 
                now.Day.ToString("00"));

            string fullDirectoryPath = Path.Combine(baseDir, dateSubPath);

            string physicalPath = await _fileStorage.SaveAsync(file, fullDirectoryPath, storedName, cancellationToken);

            string fileUrl = $"/cdn/{dateSubPath.Replace("\\", "/")}/{storedName}";

            var mediaDto = new CreateMediaAssetDto
            {
                FileName = originalFileName,
                StoredName = storedName,
                FileUrl = fileUrl,
                Extension = extension,
                FileSize = file.Length,
                ContentType = file.ContentType,
                MediaType = FileHelper.GetMediaType(file.ContentType, originalFileName),
            };
            try
            {
                var command = new CreateMediaAssetRequest { Media = mediaDto };
                var isSavedInDb = await _mediator.Send(command, cancellationToken);

                // ۷. مدیریت خطا (Rollback)
                // اگر در دیتابیس ذخیره نشد، فایلی که روی دیسک ذخیره شده را پاک می‌کنیم
                if (isSavedInDb==null)
                {
                    await _fileStorage.DeleteAsync(physicalPath, cancellationToken);
                    throw new Exception("خطا در ثبت اطلاعات فایل در دیتابیس.");
                }

                return isSavedInDb;
            }
            catch
            {
                await _fileStorage.DeleteAsync(physicalPath, cancellationToken);
                throw;
            }

        }

    }
}
