using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("ConversationMember", Schema = "UserManagment")]
    public class ConversationMember:BaseEntity
    {
        public DateTime? LastReadMessageTimestamp { get; set; }
        
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
      
        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
