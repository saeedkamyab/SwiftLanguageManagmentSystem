using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("InstituteField", Schema = "InstituteManagement")]
    public class InstituteField :BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; } = null!;
        public Guid FieldId { get; set; }
        public Field Field { get; set; } = null!;
    }
}
