using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
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

            var userId = _currentUser.Id ?? throw new UnauthorizedException();
            var institute = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Institute>(request);
            var result = await _unitOfWork.InstituteRepository.AddAsync(institute, cancellationToken);

            var fields = await _unitOfWork.FieldRepository
    .GetByIdsAsync(request.FieldIds,cancellationToken);

            if (fields.Count != request.FieldIds.Count)
            {
                throw new NotFoundException();
            }

            foreach (var field in request.FieldIds)
            {
                await _unitOfWork.InstituteFieldRepository.AddAsync(new InstituteField
                {
                    InstituteId = result.Id,
                    FieldId = field
                }, cancellationToken);
            }

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
