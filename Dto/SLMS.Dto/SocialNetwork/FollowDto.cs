using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork
{
    public class FollowDto:BaseDto
    {
        public Guid FollowerUserId {  get; set; }
        public UserDto FollowerUser { get; set; } = null!;
        public Guid FollowingUserId {  get; set; }
        public UserDto FollowingUser { get; set; } = null!;
    }
}
