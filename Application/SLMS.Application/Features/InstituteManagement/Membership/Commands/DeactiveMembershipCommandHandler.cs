using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Membership.Commands
{
    public class DeactiveMembershipCommandHandler : IRequestHandler<DeactiveMembershipCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeactiveMembershipCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
         
        }

        public async Task<bool> Handle(DeactiveMembershipCommand request,
            CancellationToken cancellationToken)
        {
           

            var membership = await _unitOfWork.InstituteMembershipRepository.
                GetUserMembersShipByIdAsync(request.Id,request.InstituteId, cancellationToken);

            if (membership == null)
                throw new NotFoundException("عضویت یافت نشد.");

            if (membership.MembershipRoles.Any(x => x.MemberType == MemberType.Founder)
                || membership.IsActived==false)
                throw new ConflictException("عملیات بر روی این عضو امکان پذیر نمیباشد.");


            membership.IsActived = false;
           
            await _unitOfWork.CommitAsync();
            return true;
        }

    }

}
