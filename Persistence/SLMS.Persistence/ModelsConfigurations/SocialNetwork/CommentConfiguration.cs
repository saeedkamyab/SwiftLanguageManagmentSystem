using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {

            comment.Property(c => c.CommentContext).HasMaxLength(350);

            comment.HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
;
            comment.HasOne(c => c.Parent)
                .WithMany(c => c.ChildComments)
                .HasForeignKey(c => c.ParentId)
                .IsRequired(false)
;
            comment.HasOne(c => c.User)
                .WithMany(c => c.Comments)//Maybe I will remove
                .HasForeignKey(c => c.UserId)
;
        }
    }
}
