namespace SLMS.Dto.SocialNetwork.Post
{
    public class CreatePostDto
    {
        public string Caption { get; set; } = string.Empty;
        public Guid? MediaAssetId { get; set; }
    }
   
}
