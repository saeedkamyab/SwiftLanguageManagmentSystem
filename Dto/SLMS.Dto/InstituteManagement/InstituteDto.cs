namespace SLMS.Dto.nstituteManagement
{
    public class InstituteDto : BaseDto
    {

        public string Title { get; set; } = string.Empty;
        public string Fields { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public ICollection<InstituteMembershipDto> InstituteMemberships { get; set; } = [];
        public ICollection<MembershipRequestDto> MembershipRequests { get; set; } = [];
        public ICollection<GroupDto> Groups { get; set; } = [];
        public ICollection<LevelDto> Levels { get; set; } = [];
        public ICollection<RoomDto> Rooms { get; set; } = [];
    }
}
