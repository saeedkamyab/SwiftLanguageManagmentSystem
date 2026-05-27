using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid? LastUpdatedById { get; set; }
    }
}
