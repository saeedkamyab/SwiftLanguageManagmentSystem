using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class AbsentPresent:BaseEntity
    {
        public Guid ClassifictionId { get; set; }
        public Classification Classifiction { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int SessionNumber { get; set; }
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
