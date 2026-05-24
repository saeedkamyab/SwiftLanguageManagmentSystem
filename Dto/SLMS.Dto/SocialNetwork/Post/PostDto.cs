using SLMS.Dto.SocialNetwork.Comments;
using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork.Post
{
    public class CreatePostDto : BaseDto
    {
        public string Title { get; set; }=string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public Guid PostOwnerId { get; set; }
    }
}
