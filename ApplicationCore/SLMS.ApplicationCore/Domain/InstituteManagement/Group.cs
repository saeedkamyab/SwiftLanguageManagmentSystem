using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Group : BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
