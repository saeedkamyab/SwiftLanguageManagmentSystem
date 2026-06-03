using SLMS.Shared.Enums;

namespace SLMS.Dto.Media
{
    public class CreateMediaAssetDto
    {
        public string FileName { get; set; } = string.Empty;
        public string StoredName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string? MetaData { get; set; }
        public bool IsAttached { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
