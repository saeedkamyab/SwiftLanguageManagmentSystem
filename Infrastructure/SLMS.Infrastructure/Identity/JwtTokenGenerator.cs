using SLMS.Application.Contracts.Identity;
using SLMS.ApplicationCore.Domain.User;

namespace SLMS.Infrastructure.Identity
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
