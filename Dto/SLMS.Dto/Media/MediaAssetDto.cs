using SLMS.Shared.Enums;

namespace SLMS.Dto.Media
{
    public class MediaAssetDto : BaseDto
    {
        public string FileName { get; set; }
        public string StoredName { get; set; }
        public string FileUrl { get; set; }
        public string Extension { get; set; }
        public MediaType MediaType { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public string? MetaData { get; set; }


    }
}
