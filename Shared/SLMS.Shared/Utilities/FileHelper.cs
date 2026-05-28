using SLMS.Shared.Enums;

namespace SLMS.Shared.Utilities
{
    public static class FileHelper
    {
        public static MediaType GetMediaType(string contentType, string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            contentType = contentType.ToLowerInvariant();

            if (contentType.StartsWith("image/")) return MediaType.Image;
            if (contentType.StartsWith("video/")) return MediaType.Video;
            if (contentType.StartsWith("audio/")) return MediaType.Audio;

            // لیست پسوندهای اسناد
            var docExtensions = new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".txt" };
            if (docExtensions.Contains(extension) || contentType.Contains("application/pdf"))
                return MediaType.Document;

            return MediaType.Other;
        }
    }
}
