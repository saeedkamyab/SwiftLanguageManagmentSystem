using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class InstituteMembershipRoleConfiguration : IEntityTypeConfiguration<InstituteMembershipRole>
    {
        public void Configure(EntityTypeBuilder<InstituteMembershipRole> instituteMembershipRole)
        {

            instituteMembershipRole.HasOne(im => im.InstituteMembership)
                .WithMany(i => i.MembershipRoles)
                .HasForeignKey(im => im.InstituteMembershipId);
        }
    }
}

              
