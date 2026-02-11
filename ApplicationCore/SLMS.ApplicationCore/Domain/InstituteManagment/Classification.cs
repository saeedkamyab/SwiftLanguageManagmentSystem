namespace SLMS.ApplicationCore.Domain.InstituteManagment
{
    public class Classification : BaseEntity
    {
        public Guid TermCourseId {  get; set; }
        public Guid PersonId {  get; set; }
    }
}
