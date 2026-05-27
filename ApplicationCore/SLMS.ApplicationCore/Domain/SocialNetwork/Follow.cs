using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("Follow", Schema = "SocialNetwork")]
    public class Follow:BaseEntity
    {
        public Guid FollowerUserId {  get; set; }
        public Domain.User.User FollowerUser {  get; set; } = null!;
        public Guid FollowingUserId {  get; set; }
        public Domain.User.User FollowingUser {  get; set; } = null!;
    }
}
