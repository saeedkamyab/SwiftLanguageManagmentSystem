using SLMS.Dto.SocialNetwork.Post;
using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork
{
    public class LikeDto:BaseDto
    {
        public Guid PostId { get; set; }
        public PostDto Post { get; set; } = null!;
       
        public Guid UserId { get; set; }
        public UserDto User { get; set; }=null!;
    }
}
