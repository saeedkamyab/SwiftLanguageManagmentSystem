namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Classification : BaseEntity
    {
        public string Title { get; set; }
        public Guid TermCourseId {  get; set; }
        public Guid StudentId {  get; set; }//InstituteMemberId
        public Certificate? Certificate { get; set; }
    }
}
