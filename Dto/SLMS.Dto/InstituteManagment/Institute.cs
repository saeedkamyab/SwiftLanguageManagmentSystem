namespace SLMS.Dto.InstituteManagment
{
    public class Institute : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public List<InstituteMembers> InstituteMembers {  get; set; }
    }
}
