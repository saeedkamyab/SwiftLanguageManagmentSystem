using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class ClassificationConfiguration : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> classification)
        {

            classification.Property(c => c.Title).HasMaxLength(100);

            classification.HasOne(c => c.TermCourse)
                .WithMany(tc => tc.Classifications)
                .HasForeignKey(c => c.TermCourseId)
                .HasConstraintName("FK_Classification_TermCourse");

            classification.HasOne(c => c.ClassificationMember)
        .WithMany(im => im.Classifications)
        .HasForeignKey(c => c.ClassificationMemberId)
        .HasConstraintName("FK_Classification_ClassificationMember");
        }
    }
}
