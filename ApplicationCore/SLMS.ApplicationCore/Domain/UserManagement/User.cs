namespace SLMS.ApplicationCore.Domain.UserManagement
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
    }
}
