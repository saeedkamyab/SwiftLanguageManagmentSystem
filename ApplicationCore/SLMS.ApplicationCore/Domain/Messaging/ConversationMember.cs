using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.Messaging
{
    [Table("ConversationMember", Schema = "Messaging")]
    public class ConversationMember:BaseEntity
    {
        public DateTime? LastReadMessageTimestamp { get; set; }
        
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
      
        public Guid UserId { get; set; }
        public Domain.User.User User { get; set; }
        
    }
}
