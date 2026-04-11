using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class MembershipRequestConfiguration : IEntityTypeConfiguration<MembershipRequest>
    {
        public void Configure(EntityTypeBuilder<MembershipRequest> membershipRequest)
        {
            membershipRequest.HasOne(msr => msr.User)
                .WithMany(u => u.MembershipRequests)
                .HasForeignKey(msr => msr.UserId)
                .HasConstraintName("FK_MembershipRequest_User");


            membershipRequest.HasOne(msr => msr.Institute)
                .WithMany(i => i.MembershipRequests)
                .HasForeignKey(msr => msr.InstituteId)
                .HasConstraintName("FK_MembershipRequest_Institute");
        }
    }
}
