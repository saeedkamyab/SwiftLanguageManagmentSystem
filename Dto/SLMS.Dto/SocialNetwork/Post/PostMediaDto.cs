using SLMS.Dto.Media;
using SLMS.Dto.SocialNetwork.Post;

namespace SLMS.Dto.SocialNetwork
{
    public class PostMediaDto : BaseDto
    {
        public Guid PostId { get; set; }
        public virtual PostDto Post { get; set; }
        public Guid MediaAssetId { get; set; }
        public virtual MediaAssetDto MediaAsset { get; set; }
        public int SortOrder { get; set; }
    }
}
