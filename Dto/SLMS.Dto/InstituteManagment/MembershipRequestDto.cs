namespace SLMS.Dto.InstituteManagment
{
    public class MembershipRequestDto : BaseDto
    {
        public DateTime RequestDate { get; set; }
        public Guid PersonId { get; set; }
    }
}
