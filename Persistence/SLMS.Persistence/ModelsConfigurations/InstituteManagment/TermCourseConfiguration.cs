using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.UserManagment
{
    public class TermCourseConfiguration : IEntityTypeConfiguration<TermCourse>
    {
        public void Configure(EntityTypeBuilder<TermCourse> termCourse)
        {

            termCourse.HasOne(tc => tc.Level)
                .WithMany()
                .HasForeignKey(tc => tc.LevelId)
                .HasConstraintName("FK_TermCourse_Level");

            termCourse.HasOne(tc => tc.Institute)
             .WithMany()
             .HasForeignKey(tc => tc.InstituteId)
             .HasConstraintName("FK_TermCourse_Institute");

            termCourse.HasOne(tc => tc.Room)
          .WithMany(r=>r.TermCourses)
          .HasForeignKey(tc => tc.Room)
          .HasConstraintName("FK_TermCourse_Room");
        }
    }
}
