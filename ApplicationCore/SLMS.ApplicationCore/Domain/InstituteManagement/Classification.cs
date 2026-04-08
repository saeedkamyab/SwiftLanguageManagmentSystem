using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Classification : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId {  get; set; }
        [ForeignKey(nameof(TermCourseId))]
        public TermCourse TermCourse { get; set; }
        public Guid ClassificationMemberId {  get; set; }//InstituteMembershipId
        [ForeignKey(nameof(ClassificationMemberId))]
        public InstituteMembership ClassificationMember { get; set; }
        public Certificate? Certificate { get; set; }
        public List<AbsentPresent> AbsentPresents { get; set; } = [];
    }
}
