namespace SLMS.Application.Features.SocialNetwork.Comments.Commands
{
    public class CommentCommandResponse
    {
        public string CommentContext { get; set; } = string.Empty;
        public Guid PostId { get; set; }
        public Guid? ParentId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
