using SLMS.ApplicationCore.Domain.User;

namespace SLMS.Application.Contracts.Identity
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
