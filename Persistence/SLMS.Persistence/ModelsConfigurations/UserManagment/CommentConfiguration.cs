using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> comment)
        {

            comment.Property(c => c.CommentContext).HasMaxLength(350);

            comment.HasOne(c => c.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.PostId)
                .HasConstraintName("FK_Comment_Post");

            comment.HasOne(c => c.Parent)
                .WithMany(c => c.ChildComments)
                .HasForeignKey(c => c.ParentId)
                .IsRequired(false)
                .HasConstraintName("FK_Comment_ParentComment");

            comment.HasOne(c => c.User)
                .WithMany(c => c.Comments)//Maybe I will remove
                .HasForeignKey(c => c.UserId)
                .HasConstraintName("FK_Comment_User");

        }
    }
}
