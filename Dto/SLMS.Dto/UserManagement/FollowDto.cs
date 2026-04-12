namespace SLMS.Dto.UserManagement
{
    public class FollowDto:BaseDto
    {
        public Guid FollowerUserId {  get; set; }
        public UserDto FollowerUser {  get; set; }
        public Guid FollowingUserId {  get; set; }
        public UserDto FollowingUser {  get; set; }
    }
}
