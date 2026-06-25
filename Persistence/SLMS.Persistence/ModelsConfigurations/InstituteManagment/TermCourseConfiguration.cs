using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Persistence.ModelsConfigurations.InstituteManagment
{
    public class TermCourseConfiguration : IEntityTypeConfiguration<TermCourse>
    {
        public void Configure(EntityTypeBuilder<TermCourse> termCourse)
        {

            termCourse.HasOne(tc => tc.Level)
                .WithMany()
                .HasForeignKey(tc => tc.LevelId)
;
            termCourse.HasOne(tc => tc.Institute)
             .WithMany()
             .HasForeignKey(tc => tc.InstituteId);

            termCourse.HasOne(tc => tc.Room)
          .WithMany(r => r.TermCourses)
          .HasForeignKey(tc => tc.RoomId)


;
        }
    }
}
