using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    public class Certificate 
    {
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }

        public int Reading { get; set; }
        public int Writting { get; set; }
        public int Listening { get; set; }
        public int Speaking { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
        public byte Status { get; set; }
        

        [Key, ForeignKey("Classification")]
        public Guid ClassificationId { get; set; }
        public Classification? Classification { get; set; }
    }
}
