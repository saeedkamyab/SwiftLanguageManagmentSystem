using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    [Table("Post", Schema = "UserManagment")]
    public class Post : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }=string.Empty;
        [StringLength(500)]
        public string Caption { get; set; } = string.Empty;
        [StringLength(1500)]
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }

        public Guid PostOwnerId { get; set; }
        public User PostOwner { get; set; }
       

        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
