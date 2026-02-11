namespace SLMS.Dto.PersonManagement
{
    public class PersonDto : BaseDto
    {
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
    }
}
