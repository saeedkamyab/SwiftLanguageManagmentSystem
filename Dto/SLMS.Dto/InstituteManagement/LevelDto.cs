namespace SLMS.Dto.nstituteManagement
{
    public class LevelDto : BaseDto
    {
        public string Title { get; set; } = string.Empty;
        
        
        public Guid InstituteId { get; set; }
        public InstituteDto Institute { get; set; }
    }
}
