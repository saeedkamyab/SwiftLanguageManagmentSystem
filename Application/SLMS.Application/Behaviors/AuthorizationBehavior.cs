using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Behaviors
{
    public class AuthorizationBehavior<TRequest,TResponse>:
        IPipelineBehavior<TRequest,TResponse> where TRequest :IAuthorizedRequest
    {
        private readonly ICurrentUserService _currentUserService;

        public AuthorizationBehavior(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            if(_currentUserService.Id is null || _currentUserService.Id == Guid.Empty)
            {
                throw new UnauthorizedException();
            }
            return await next();
        }
    }
}
