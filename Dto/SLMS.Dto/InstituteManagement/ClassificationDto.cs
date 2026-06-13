namespace SLMS.Dto.InstituteManagement
{
    public class ClassificationDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
       

        public Guid TermCourseId {  get; set; }
        public TermCourseDto TermCourse { get; set; } = null!;
        public Guid ClassificationMemberId {  get; set; }//InstituteMembershipId
        public InstituteMembershipDto ClassificationMember { get; set; } = null!;
        public CertificateDto? Certificate { get; set; }
        public ICollection<AbsentPresentDto> AbsentPresents { get; set; } = [];
    }
}
