using SLMS.Dto.User;

namespace SLMS.Dto.SocialNetwork.Comments
{
    public class CreateCommentDto : BaseDto
    {
        public string CommentContext { get; set; }=string.Empty;
        public Guid PostId { get; set; }
        public Guid? ParentId { get; set; }
    }
}
