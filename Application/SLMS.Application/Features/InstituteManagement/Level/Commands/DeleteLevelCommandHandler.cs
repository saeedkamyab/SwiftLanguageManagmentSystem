using AutoMapper;
using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Features.InstituteManagement.Level.Commands
{
    public class DeleteLevelCommandHandler : IRequestHandler<DeleteLevelCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLevelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
        {
            var level = await _unitOfWork.LevelRepository.GetByIdAsync(request.Id, cancellationToken);
            if (level == null)
                throw new NotFoundException(nameof(Level),request.Id);

            var result = _unitOfWork.LevelRepository.SoftDelete(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}
