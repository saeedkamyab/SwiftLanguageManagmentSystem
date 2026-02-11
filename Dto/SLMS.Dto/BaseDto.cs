namespace SLMS.Dto
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
