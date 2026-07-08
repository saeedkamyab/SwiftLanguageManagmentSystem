using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class CreateClassificationDto
    {
        public string Title { get; set; } = string.Empty;
        public Guid TermCourseId { get; set; }
        public Guid PupilMembershipId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
