namespace SLMS.Dto.SocialNetwork.Post
{
    public class CreatePostDto
    {
        public string Caption { get; set; } = string.Empty;
        public Guid PostOwnerId { get; set; }
        public CreatePostMediaDto? PostMedia { get; set; }
    }
   
}
