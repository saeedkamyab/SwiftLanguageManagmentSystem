namespace SLMS.Dto.UserManagement
{
    public class LikeDto:BaseDto
    {
        public Guid PostId { get; set; }
        public PostDto Post { get; set; }
       
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
