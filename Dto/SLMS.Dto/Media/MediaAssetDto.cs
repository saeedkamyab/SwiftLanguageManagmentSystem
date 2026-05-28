using SLMS.Shared.Enums;

namespace SLMS.Dto.Media
{
    public class MediaAssetDto : BaseDto
    {
        public string FileName { get; set; } = string.Empty;
        public string StoredName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public MediaType MediaType { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public string? MetaData { get; set; }
    }
}
