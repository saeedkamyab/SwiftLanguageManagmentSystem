using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post.Property(p=>p.Title).HasMaxLength(100);
            post.Property(p=>p.Caption).HasMaxLength(500);
            post.Property(p=>p.ImageUrl).HasMaxLength(1500).IsRequired(false);
           

            post.HasOne(p=>p.PostOwner)
                .WithMany(u=>u.Posts)
                .HasForeignKey(p=>p.PostOwnerId)
                .HasConstraintName("FK_Post_PosterUser");
        }
    }
}
