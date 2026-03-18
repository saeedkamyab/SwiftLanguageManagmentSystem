namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class InstituteMemberGroup : BaseEntity
    {
        public Guid InstituteMemberId { get; set; }
        public Guid GroupId { get; set; }
    }
}
