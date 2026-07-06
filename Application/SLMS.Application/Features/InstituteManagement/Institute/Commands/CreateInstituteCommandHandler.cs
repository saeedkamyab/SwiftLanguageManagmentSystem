using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

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

            var institute = _mapper.Map<ApplicationCore.Domain.InstituteManagement.Institute>(request);
          
            var result = await _unitOfWork.InstituteRepository.AddAsync(institute, cancellationToken);

            var categories = await _unitOfWork.CategoryRepository
    .GetByIdsAsync(request.CategoryIds,cancellationToken);

            if (categories.Count != request.CategoryIds.Count)
            {
                throw new NotFoundException();
            }

            foreach (var category in request.CategoryIds)
            {
                await _unitOfWork.InstituteCategoryRepository.AddAsync(new InstituteCategory
                {
                    InstituteId = result.Id,
                    CategoryId = category
                }, cancellationToken);
            }

            await _unitOfWork.InstituteMembershipRepository.AddAsync(new InstituteMembership
            {
                InstituteId = result.Id,
                UserId = _currentUser.Id!.Value,
                IsActived=true,
                MembershipRoles = new List<InstituteMembershipRole>
                {
                    new InstituteMembershipRole
                    {
                       MemberType = MemberType.Founder
                    }
                }
            }, cancellationToken);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<InstituteCommandResponse>(result);

        }
    }
}
