using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Room", Schema = "InstituteManagement")]
    public class Room : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public Guid InstituteId { get; set; }
        public Institute Institute {  get; set; }
        public ICollection<TermCourse> TermCourses {  get; set; }
    }
}
