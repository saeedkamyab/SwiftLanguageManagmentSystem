using SLMS.Dto.SocialNetwork.Post;
using SLMS.Dto.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SLMS.Dto.SocialNetwork.Comments
{
    public class CommentDto : BaseDto
    {

        public string CommentContext { get; set; } = string.Empty;

        public Guid PostId { get; set; }
        public PostDto Post { get; set; }

        public Guid? ParentId { get; set; }
        [JsonIgnore]
        public CommentDto? Parent { get; set; }

        public Guid UserId { get; set; }
        public UserDto User { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<CommentDto> ChildComments { get; set; }
    }
}
