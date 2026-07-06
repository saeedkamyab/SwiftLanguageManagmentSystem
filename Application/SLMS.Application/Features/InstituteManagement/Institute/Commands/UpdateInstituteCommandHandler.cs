using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Identity;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Features.InstituteManagement.Institute.Commands
{
    public class UpdateInstituteCommandHandler : IRequestHandler<UpdateInstituteCommand, InstituteCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;

        public UpdateInstituteCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }

        public async Task<InstituteCommandResponse> Handle(UpdateInstituteCommand request,
            CancellationToken cancellationToken)
        {
            
            var loginedUserMembership = await _unitOfWork.InstituteMembershipRepository.GetUserMembersShipByUserIdAsync(
              _currentUser.Id!.Value, request.Id, cancellationToken) ?? throw new NotFoundException();
           
            if (!loginedUserMembership.MembershipRoles.Any(r => r.MemberType == MemberType.Founder))
                throw new UnauthorizedException("شما اجازه پردازش درخواست را ندارید.");

            var instituteToUpdate = await _unitOfWork.InstituteRepository.GetByIdAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException();

            _mapper.Map(request, instituteToUpdate);

            var oldCategories =  _unitOfWork.InstituteCategoryRepository.GetQueryable()
                .Where(x => x.InstituteId == request.Id)
                .ToList();

            _unitOfWork.InstituteCategoryRepository.HardDeleteRange(oldCategories);

            var newInstituteCategories = request.CategoryIds.Select(categoryId => new InstituteCategory
            {
                InstituteId = request.Id,
                CategoryId = categoryId
            }).ToList();

            await _unitOfWork.InstituteCategoryRepository.AddRangeAsync(newInstituteCategories, cancellationToken);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<InstituteCommandResponse>(instituteToUpdate);

        }
    }
}
