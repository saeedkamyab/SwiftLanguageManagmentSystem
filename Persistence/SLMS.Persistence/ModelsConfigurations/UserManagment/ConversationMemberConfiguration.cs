using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class ConversationMemberConfiguration : IEntityTypeConfiguration<ConversationMember>
    {
        public void Configure(EntityTypeBuilder<ConversationMember> conversationMember)
        {
            conversationMember.HasOne(c => c.Conversation)
                .WithMany(c => c.ConversationMembers)
                .HasForeignKey(c => c.ConversationId)
                .HasConstraintName("FK_ConversationMember_Conversation");

            conversationMember.HasOne(c => c.User)
                        .WithMany(u => u.ConversationMembers)
                        .HasForeignKey(c => c.UserId)
                        .HasConstraintName("FK_ConversationMember_User");
        }
    }
}
