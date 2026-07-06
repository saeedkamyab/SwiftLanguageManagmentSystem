using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.MembershipRequest.Commands
{
    public class CreateMembershipRequestCommandHandler : IRequestHandler<CreateMembershipRequestCommand, MembershipRequestCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public CreateMembershipRequestCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<MembershipRequestCommandResponse> Handle(CreateMembershipRequestCommand request,
            CancellationToken cancellationToken)
        {


            if (await _unitOfWork.MembershipRequestRepository.
                ExistsRequestAsync(_currentUser.Id!.Value, request.InstituteId, cancellationToken))
            {
                throw new ConflictException("درخواست از قبل ثبت شده است.");
            }
            if (!await _unitOfWork.InstituteRepository.ExistsAsync(request.InstituteId, cancellationToken))
            {
                throw new NotFoundException();
            }

            var membershipRequest = _mapper.Map<ApplicationCore.Domain.InstituteManagement.MembershipRequest>(request);
            membershipRequest.UserId = _currentUser.Id!.Value;
            membershipRequest.Status = MembershipRequestStatus.Pending;
            membershipRequest.RequestDate = DateTime.UtcNow;

            var result = await _unitOfWork.MembershipRequestRepository.AddAsync(membershipRequest, cancellationToken);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<MembershipRequestCommandResponse>(result);

        }
    }
}
