namespace SLMS.Shared.Enums
{
    public enum MemberType:byte
    {
        None=0,
        Pupil=1,
        Teacher=2,
        Admin=3,
        Founder=4
    }
    public enum WeekDay : byte
    {
        None = 0,
        Saturday=1, 
        Sunday=2,
        Monday=3, 
        Tuesday=4,   
        Wednesday=5,
        Thursday=6,
        Friday=7,
    }
    public enum CertificateStatus : byte
    {
        None = 0,
        Passed = 1,
        Failed = 2,
    }
    public enum MembershipRequestStatus : byte
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2,
    }
}
