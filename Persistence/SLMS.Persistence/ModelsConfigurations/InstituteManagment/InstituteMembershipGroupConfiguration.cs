using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class InstituteMembershipGroupConfiguration : IEntityTypeConfiguration<InstituteMembershipGroup>
    {
        public void Configure(EntityTypeBuilder<InstituteMembershipGroup> instituteMembershipGroup)
        {
            instituteMembershipGroup.HasOne(img => img.InstituteMembership)
                .WithMany(im => im.InstituteMembershipGroups)
                .HasForeignKey(img => img.InstituteMembershipId)
;
            instituteMembershipGroup.HasOne(img => img.Group)
               .WithMany(g => g.InstituteMembershipGroups)
               .HasForeignKey(img => img.GroupId)
;        }
    }
}
