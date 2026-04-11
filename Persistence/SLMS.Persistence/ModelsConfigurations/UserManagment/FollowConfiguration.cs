using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.UserManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> follow)
        {
            follow.HasOne(f => f.FollowerUser)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerUserId)
                .HasConstraintName("FK_Follow_FollowerUser");

            follow.HasOne(f => f.FollowingUser)
                        .WithMany(u => u.Followings)
                        .HasForeignKey(f => f.FollowingUserId)
                        .HasConstraintName("FK_Follow_FollowingsUser");
        }
    }
}
