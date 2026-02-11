namespace SLMS.Dto.InstituteManagment
{
    public class Certificate : BaseDto
    {
        public int Reading { get; set; }
        public int Writting { get; set; }
        public int Listening { get; set; }
        public int Speaking { get; set; }
        public int MidTerm { get; set; }
        public int Final { get; set; }
    }
}
