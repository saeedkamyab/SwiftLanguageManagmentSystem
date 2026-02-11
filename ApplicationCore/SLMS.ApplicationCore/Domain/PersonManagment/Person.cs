namespace SLMS.ApplicationCore.Domain.PersonManagment
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
    }
}
