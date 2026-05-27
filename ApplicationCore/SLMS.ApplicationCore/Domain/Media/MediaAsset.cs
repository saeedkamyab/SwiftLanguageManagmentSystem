using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.Media
{
    [Table("MediaAsset", Schema = "Media")]
    public class MediaAsset : BaseEntity
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
