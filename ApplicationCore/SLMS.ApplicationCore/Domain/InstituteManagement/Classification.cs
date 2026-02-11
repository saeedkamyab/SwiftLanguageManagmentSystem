namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Classification : BaseEntity
    {
        public Guid TermCourseId {  get; set; }
        public Guid PersonId {  get; set; }
    }
}
