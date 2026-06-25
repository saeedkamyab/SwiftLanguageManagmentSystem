using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("TermCourseSessionDay", Schema = "InstituteManagement")]
    public class TermCourseSessionDay:BaseEntity
    {
        public Guid TermCourseId { get; set; }
        public TermCourse TermCourse { get; set; } = null!;
        public WeekDay WeekDay { get; set; }
    }
}
