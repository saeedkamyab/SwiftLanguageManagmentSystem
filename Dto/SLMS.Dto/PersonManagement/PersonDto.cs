namespace SLMS.Dto.UserManagement
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
    }
}
