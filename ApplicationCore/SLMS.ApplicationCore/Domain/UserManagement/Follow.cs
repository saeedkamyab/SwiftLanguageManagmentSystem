using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class Follow:BaseEntity
    {
        public Guid FollowerUserId {  get; set; }
        [ForeignKey(nameof(FollowerUserId))]
        public User FollowerUser {  get; set; }
        public Guid FollowingUserId {  get; set; }
        [ForeignKey(nameof(FollowingUserId))]
        public User FollowingUser {  get; set; }
    }
}
