namespace SLMS.Dto.nstituteManagement
{
    public class ClassificationDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
       

        public Guid TermCourseId {  get; set; }
        public TermCourseDto TermCourse { get; set; }
        public Guid ClassificationMemberId {  get; set; }//InstituteMembershipId
        public InstituteMembershipDto ClassificationMember { get; set; }
        public CertificateDto? Certificate { get; set; }
        public ICollection<AbsentPresentDto> AbsentPresents { get; set; } = [];
    }
}
