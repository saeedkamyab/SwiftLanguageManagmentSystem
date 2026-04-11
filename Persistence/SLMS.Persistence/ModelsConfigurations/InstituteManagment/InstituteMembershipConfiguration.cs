using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class InstituteMembershipConfiguration : IEntityTypeConfiguration<InstituteMembership>
    {
        public void Configure(EntityTypeBuilder<InstituteMembership> instituteMembership)
        {

            instituteMembership.HasOne(im => im.Institute)
                .WithMany(i => i.InstituteMemberships)
                .HasForeignKey(im => im.InstituteId)
                .HasConstraintName("FK_InstituteMembership_Institute");


            instituteMembership.HasOne(im => im.User)
                .WithMany(u => u.InstituteMemberships)
                .HasForeignKey(im => im.UserId)
                .HasConstraintName("FK_InstituteMembership_User");


            instituteMembership.HasOne(im => im.Level)
                .WithMany()
                .HasForeignKey(im => im.LevelId)
                .HasConstraintName("FK_InstituteMembership_Level");

        }
    }
}
