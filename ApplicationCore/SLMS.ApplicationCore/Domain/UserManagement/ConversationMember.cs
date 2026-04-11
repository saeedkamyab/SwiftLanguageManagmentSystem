using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("ConversationMember", Schema = "UserManagment")]
    public class ConversationMember:BaseEntity
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
      
        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public DateTime? LastReadMessageTimestamp { get; set; }
    }
}
