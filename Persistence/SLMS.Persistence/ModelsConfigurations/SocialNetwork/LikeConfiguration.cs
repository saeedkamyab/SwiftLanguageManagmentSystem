using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class LikeConfiguration : BaseEntityConfiguration<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> Like)
        {
            Like.HasOne(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
;
            Like.HasOne(l => l.User)
                        .WithMany(u => u.Likes)// you can have empty
                        .HasForeignKey(l => l.UserId)
;        }
    }
}
