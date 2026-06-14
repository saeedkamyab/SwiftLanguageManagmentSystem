using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class CreateInstituteCommandHandler : IRequestHandler<CreateInstituteCommand, InstituteCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public CreateInstituteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<InstituteCommandResponse> Handle(CreateInstituteCommand request,
            CancellationToken cancellationToken)
        {

                var userId = _currentUser.Id ?? throw new UnauthorizedAccessException();
                var institute = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Institute>(request);
                var result = await _unitOfWork.InstituteRepository.AddAsync(institute, cancellationToken);
                await _unitOfWork.InstituteMembershipRepository.AddAsync(new InstituteMembership
                {
                    MemberType = Shared.Enums.MemberType.Founder,
                    InstituteId = result.Id,
                    UserId = userId
                }, cancellationToken);
                await _unitOfWork.CommitAsync();
                return _mapper.Map<InstituteCommandResponse>(result);
           
        }
    }
}
