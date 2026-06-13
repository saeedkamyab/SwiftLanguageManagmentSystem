namespace SLMS.Dto.InstituteManagement
{
    public class LevelDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        
        
        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; } = null!; 
    }
}
