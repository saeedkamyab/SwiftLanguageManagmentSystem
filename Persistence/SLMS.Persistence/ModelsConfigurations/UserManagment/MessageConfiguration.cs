using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message.HasOne(m => m.Conversation)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ConversationId)
                .HasConstraintName("FK_Message_Conversation");

            message.HasOne(m => m.SenderUser)
                        .WithMany(u => u.Messages)
                        .HasForeignKey(m => m.SenderUserId)
                        .HasConstraintName("FK_Message_User");
        }
    }
}
