using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post.HasOne(p=>p.PostOwner)
                .WithMany(u=>u.Posts)
                .HasForeignKey(p=>p.PostOwnerId)
                .HasConstraintName("FK_Post_PosterUser");
        }
    }
}
