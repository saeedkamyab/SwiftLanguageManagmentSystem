using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Group : BaseEntity
    {
        public Guid InstituteId { get; set; }
        [ForeignKey(nameof(InstituteId))]
        public Institute Institute { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
