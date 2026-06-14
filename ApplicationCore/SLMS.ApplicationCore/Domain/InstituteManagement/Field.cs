using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Field", Schema = "InstituteManagement")]
    public class Field:BaseEntity
    {
        public string Title { get; set; }=string.Empty;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<InstituteField> InstituteFields { get; set; } = [];
    }
}
