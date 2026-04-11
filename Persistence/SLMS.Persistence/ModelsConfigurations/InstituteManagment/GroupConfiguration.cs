using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> group)
        {

            group.Property(g => g.Title).HasMaxLength(100);
            group.Property(g => g.Description).HasMaxLength(250).IsRequired(false);

            group.HasOne(g => g.Institute)
                .WithMany(i=>i.Groups)
                .HasForeignKey(g=>g.InstituteId)
                .HasConstraintName("FK_Group_Institute");
        }
    }
}
