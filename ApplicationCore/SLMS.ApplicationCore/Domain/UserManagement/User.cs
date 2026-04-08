using System.ComponentModel.DataAnnotations;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class User : BaseEntity
    {
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(100)]
        public string FatherName { get; set; } = string.Empty;
        [StringLength(250)]
        public string UserName { get; set; } = string.Empty;
        [StringLength(300)]
        public string Password { get; set; } = string.Empty;

        public ICollection<Follow> Followings { get; set; } = [];
        public ICollection<Follow> Followers { get; set; } = [];
    }
}
