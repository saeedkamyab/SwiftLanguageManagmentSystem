using SLMS.Shared.Enums;

namespace SLMS.ApplicationCore.Domain.InstituteManagment
{
    public class InstituteMember : BaseEntity
    {
        public Guid InstituteId { get; set; }
        public Guid PersonId { get; set; }
        public MemberType MemberType { get; set; }
    }
}
