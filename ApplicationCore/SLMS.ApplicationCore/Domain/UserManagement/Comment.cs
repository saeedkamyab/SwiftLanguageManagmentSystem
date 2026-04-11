using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Comment", Schema = "UserManagment")]
    public class Comment : BaseEntity
    {
       
        public Guid PostId { get; set; }
        public Post Post { get; set; }
       
        public Guid? ParentId { get; set; }
        public Comment? Parent { get; set; }
       
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<Comment> ChildComments { get; set; }
    }
}
