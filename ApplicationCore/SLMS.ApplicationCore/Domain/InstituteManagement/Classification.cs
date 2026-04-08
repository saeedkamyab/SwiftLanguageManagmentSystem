using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Classification : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId {  get; set; }
        public TermCourse TermCourse { get; set; }
        public Guid ClassificationMemberId {  get; set; }//InstituteMembershipId
        public InstituteMembership ClassificationMember { get; set; }
        public Certificate? Certificate { get; set; }
        public List<AbsentPresent> AbsentPresents { get; set; } = [];
    }
}
