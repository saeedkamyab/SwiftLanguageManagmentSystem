using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Institute", Schema = "InstituteManagement")]
    public class Institute : BaseEntity
    {

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }


        public ICollection<InstituteMembership> InstituteMemberships { get; set; } = [];
        public ICollection<MembershipRequest> MembershipRequests { get; set; } = [];
        public ICollection<Level> Levels { get; set; } = [];
        public ICollection<Room> Rooms { get; set; } = [];
        public ICollection<InstituteCategory> InstituteCategories { get; set; } = [];
    }
}
