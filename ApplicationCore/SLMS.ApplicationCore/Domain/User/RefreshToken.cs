namespace SLMS.ApplicationCore.Domain.User
{
    public class RefreshToken:BaseEntity
    {
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        public string Token { get; set; }=string.Empty;

        public DateTime ExpireDate { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime? RevokedAt { get; set; }
    }
}
