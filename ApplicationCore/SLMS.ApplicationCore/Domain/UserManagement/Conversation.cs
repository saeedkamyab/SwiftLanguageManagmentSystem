using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Conversation", Schema = "UserManagment")]
    public class Conversation:BaseEntity
    {
        public DateTime LastMessageTimestamp { get; set; }
        public ICollection<ConversationMember> ConversationMembers { get; set; } = [];
        public ICollection<Message> Messages { get; set; } = [];
    }
}
