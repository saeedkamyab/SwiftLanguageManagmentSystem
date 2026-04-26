using System.ComponentModel.DataAnnotations;

namespace SLMS.Dto.User
{
    public class CreateUserDto: BaseDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
