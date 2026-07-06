using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Membership.Commands
{
    public class ActiveMembershipCommandHandler : IRequestHandler<ActiveMembershipCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ActiveMembershipCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
         
        }

        public async Task<bool> Handle(ActiveMembershipCommand request,
            CancellationToken cancellationToken)
        {
           

            var membership = await _unitOfWork.InstituteMembershipRepository.
                GetUserMembersShipByIdAsync(request.Id,request.InstituteId, cancellationToken);

            if (membership == null)
                throw new NotFoundException("عضویت یافت نشد.");

            if (membership.MembershipRoles.Any(x => x.MemberType == MemberType.Founder)
                || membership.IsActived==true)
                throw new ConflictException("عملیات بر روی این عضو امکان پذیر نمیباشد.");


            membership.IsActived = true;
           // _unitOfWork.InstituteMembershipRepository.Update(membership);

            await _unitOfWork.CommitAsync();
            return true;
        }

    }

}
