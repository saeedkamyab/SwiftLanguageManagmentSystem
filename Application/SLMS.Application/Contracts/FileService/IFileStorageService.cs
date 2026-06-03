using Microsoft.AspNetCore.Http;

namespace SLMS.Application.Contracts.FileService
{
    public interface IFileStorageService
    {
        Task<string> SaveAsync(IFormFile file, string targetFolder, string fileName, CancellationToken cancellationToken);
        Task DeleteAsync(string filePath, CancellationToken cancellationToken);
    }
}
