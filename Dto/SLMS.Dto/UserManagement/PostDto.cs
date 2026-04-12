namespace SLMS.Dto.UserManagement
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; }=string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;

        public Guid PostOwnerId { get; set; }
        public UserDto PostOwner { get; set; }
       

        public ICollection<LikeDto> Likes { get; set; }
        public ICollection<CommentDto> Comments { get; set; }

    }
}
