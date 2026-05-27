using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.SocialNetwork
{
    [Table("Like", Schema = "SocialNetwork")]
    public class Like:BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; } = null!;
       
        public Guid UserId { get; set; }
        public Domain.User.User User { get; set; } = null!;
    }
}
