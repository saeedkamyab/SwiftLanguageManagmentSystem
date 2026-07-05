using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteCategory", Schema = "InstituteManagement")]
    public class InstituteCategory :BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
