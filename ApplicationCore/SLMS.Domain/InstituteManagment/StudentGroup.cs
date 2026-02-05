namespace SLMS.Domain.InstituteManagment
{
    public class StudentGroup : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Guid GroupId { get; set; }
    }
}
