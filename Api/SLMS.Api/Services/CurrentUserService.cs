using SLMS.Application.Contracts.Identity;
using System.Security.Claims;

namespace SLMS.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid Id
        {
            get
            {
                var userId = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return Guid.TryParse(userId, out var id) ? id : Guid.Empty;
            }
        }

        public string UserName =>
      _contextAccessor.HttpContext?
          .User?
          .Identity?
          .Name ?? string.Empty;


    }
}
