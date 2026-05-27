using System.ComponentModel.DataAnnotations;

namespace SLMS.Dto
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid? LastUpdateById { get; set; }
    }
}
