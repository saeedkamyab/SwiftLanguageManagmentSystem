using Microsoft.AspNetCore.Http;
using SLMS.Application.Contracts.FileService;

namespace SLMS.Infrastructure.FileServices
{
    public class FileStorageService : IFileStorageService
    {
       
        public async Task<string> SaveAsync(IFormFile file, string targetFolder, 
            string fileName, CancellationToken cancellationToken)
        {
            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            var filePath = Path.Combine(targetFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream, cancellationToken);
            }

            return filePath;
        }

        public Task DeleteAsync(string filePath, CancellationToken cancellationToken)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

    }
}
