using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace SLMS.ApplicationCore.Domain.InstituteManagement
{
    [Table("Category", Schema = "InstituteManagement")]
    public class Category:BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid? ParentId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<InstituteCategory> InstituteCategories { get; set; } = [];
    }
}
