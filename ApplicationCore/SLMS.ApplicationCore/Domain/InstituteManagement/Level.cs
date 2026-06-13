using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Level", Schema = "InstituteManagement")]
    public class Level : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        
        
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; } = null!;
    }
}
