using SLMS.ApplicationCore.Domain.Media;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("PostMedia", Schema = "SocialNetwork")]
    public class PostMedia : BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
        public Guid MediaAssetId { get; set; }
        public MediaAsset MediaAsset { get; set; } = null!;
        public int SortOrder { get; set; }
    }
}
