namespace SLMS.Dto.InstituteManagment
{
    public class MembershipRequest : BaseDto
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
    }
}
