using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Institute : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        [StringLength(300)]
        public string Fields { get; set; } = string.Empty;
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;
        public List<InstituteMembership> InstituteMemberships { get; set; } = [];
        public List<MembershipRequest> MembershipRequests { get; set; } = [];
    }
}
