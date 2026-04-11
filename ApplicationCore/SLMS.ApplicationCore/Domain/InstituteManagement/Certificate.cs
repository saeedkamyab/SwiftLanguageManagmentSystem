using SLMS.Shared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Certificate", Schema = "InstituteManagement")]
    public class Certificate 
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public int Reading { get; set; }
        public int Writting { get; set; }
        public int Listening { get; set; }
        public int Speaking { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
        public CertificateStatus Status { get; set; }
        
        public Guid ClassificationId { get; set; }
        public Classification Classification { get; set; }
    }
}
