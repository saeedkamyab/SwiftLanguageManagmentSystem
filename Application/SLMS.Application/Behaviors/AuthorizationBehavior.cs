using MediatR;
using SLMS.Application.Attributes;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.Application.Exceptions;
using System.Reflection;

namespace SLMS.Application.Behaviors
{
    public class AuthorizationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IAuthorizedRequest
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IInstituteMembershipRepository _membershipRepository;
        public AuthorizationBehavior(ICurrentUserService currentUserService,
    IInstituteMembershipRepository membershipRepository)
        {
            _currentUserService = currentUserService;
            _membershipRepository = membershipRepository;
        }

        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_currentUserService.Id is null || _currentUserService.Id == Guid.Empty)
            {
                throw new UnauthorizedException();
            }
            var rolesAttribute = request.GetType().GetCustomAttribute<RequireRolesAttribute>();
            if (rolesAttribute is not null)
            {
                var hasPermission =
           await _membershipRepository.UserHasAnyRoleAsync(
               _currentUserService.Id!.Value,
               request.InstituteId,
               rolesAttribute.MemberTypes,
               cancellationToken);

                if (!hasPermission)
                    throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");
            }
            return await next();
        }
    }
}