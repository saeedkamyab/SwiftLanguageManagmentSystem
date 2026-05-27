using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.SocialNetwork;

namespace SLMS.Persistence.ModelsConfigurations.SocialNetwork
{
    public class FollowConfiguration : BaseEntityConfiguration<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> follow)
        {
            follow.HasOne(f => f.FollowerUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerUserId)
;
            follow.HasOne(f => f.FollowingUser)
                        .WithMany(u => u.Followings)
                        .HasForeignKey(f => f.FollowingUserId)
;        }
    }
}
