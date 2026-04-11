using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Follow", Schema = "UserManagment")]
    public class Follow:BaseEntity
    {
        public Guid FollowerUserId {  get; set; }
        public User FollowerUser {  get; set; }
        public Guid FollowingUserId {  get; set; }
        public User FollowingUser {  get; set; }
    }
}
