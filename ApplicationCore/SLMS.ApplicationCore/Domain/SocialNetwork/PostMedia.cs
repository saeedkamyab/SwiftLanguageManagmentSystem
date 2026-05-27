using SLMS.ApplicationCore.Domain.Media;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("PostMedia", Schema = "SocialNetwork")]
    public class PostMedia : BaseEntity
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public Guid MediaAssetId { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
        public int SortOrder { get; set; }
    }
}
