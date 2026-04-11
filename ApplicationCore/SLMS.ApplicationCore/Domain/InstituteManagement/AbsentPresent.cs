using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("AbsentPresent", Schema = "InstituteManagement")]
    public class AbsentPresent:BaseEntity
    {
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        public string Description { get; set; } = string.Empty;

        
        public Guid ClassifictionId { get; set; }
        public Classification Classifiction { get; set; }
        
    }
}
