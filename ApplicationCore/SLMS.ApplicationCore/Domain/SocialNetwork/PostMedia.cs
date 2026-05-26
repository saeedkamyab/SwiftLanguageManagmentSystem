using SLMS.ApplicationCore.Domain.Media;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    public class PostMedia : BaseEntity
    {
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public Guid MediaAssetId { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
        public int SortOrder { get; set; }
    }
}
