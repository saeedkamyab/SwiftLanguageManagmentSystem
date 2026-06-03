namespace SLMS.Dto.SocialNetwork.Post
{
    public class CreatePostMediaDto:BaseDto
    {
        public Guid PostId { get; set; }
        public Guid MediaAssetId { get; set; }
    }
}
