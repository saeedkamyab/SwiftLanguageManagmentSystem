using System.ComponentModel.DataAnnotations.Schema;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Category", Schema = "InstituteManagement")]
    public class Category:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public ICollection<Field> Fields { get; set; } = [];
    }
}
