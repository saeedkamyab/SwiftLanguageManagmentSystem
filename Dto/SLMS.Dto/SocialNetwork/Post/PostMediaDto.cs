using SLMS.Dto.Media;

namespace SLMS.Dto.SocialNetwork
{
    public class PostMediaDto : BaseDto
    {
        public Guid PostId { get; set; }
        public Guid MediaAssetId { get; set; }
        public MediaAssetDto MediaAsset { get; set; } = null!;

    }
}
