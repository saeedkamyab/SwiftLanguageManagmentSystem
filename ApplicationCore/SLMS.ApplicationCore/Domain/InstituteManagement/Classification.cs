using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Classification", Schema = "InstituteManagement")]
    public class Classification : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId {  get; set; }
        public TermCourse? TermCourse { get; set; }
        public Guid ClassificationMemberId {  get; set; }//InstituteMembershipId
        public InstituteMembership ClassificationMember { get; set; } = null!;
        public Certificate? Certificate { get; set; }
        public ICollection<AbsentPresent> AbsentPresents { get; set; } = [];
    }
}
