namespace SLMS.Dto.InstituteManagement
{
    public class MembershipRequestDto : BaseDto
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
    }
}
