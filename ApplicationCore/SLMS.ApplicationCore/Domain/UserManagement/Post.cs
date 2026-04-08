using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class Post : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }=string.Empty;
        [StringLength(500)]
        public string Caption { get; set; } = string.Empty;
        [StringLength(1500)]
        public string ImageUrl { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public bool IsDeleted { get; set; }


        public ICollection<Like> Likes { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
