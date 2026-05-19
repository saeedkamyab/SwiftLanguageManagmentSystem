using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork.Comments
{
    public class CreateCommentDto : BaseDto
    {
       
        public string CommentContext { get; set; }=string.Empty;

        public Guid PostId { get; set; }
        public PostDto Post { get; set; }
       
        public Guid? ParentId { get; set; }
        public CommentDto? Parent { get; set; }
       
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
