using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post.Property(p=>p.Title).HasMaxLength(100);
            post.Property(p=>p.Caption).HasMaxLength(500);
          

            post.HasOne(p=>p.PostOwner)
                .WithMany(u=>u.Posts)
                .HasForeignKey(p=>p.PostOwnerId)
;        }
    }
}
