using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Like", Schema = "UserManagment")]
    public class Like:BaseEntity
    {
        public Guid PostId { get; set; }
        public Post Post { get; set; }
       
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
