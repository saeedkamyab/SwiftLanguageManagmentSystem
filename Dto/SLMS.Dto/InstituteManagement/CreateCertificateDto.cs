using SLMS.Shared.Enums;

namespace SLMS.Dto.InstituteManagement
{
    public class CreateCertificateDto
    {
        public int Reading { get; set; }
        public int Writting { get; set; }
        public int Listening { get; set; }
        public int Speaking { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
        public CertificateStatus Status { get; set; }
        public Guid ClassificationId { get; set; }
        public Guid InstituteId { get; set; }
    }
}
