using MediatR;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.TermCourse.Commands
{
    public class DeleteTermCourseCommandHandler : IRequestHandler<DeleteTermCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTermCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteTermCourseCommand request, CancellationToken cancellationToken)
        {
            var termCourse = await _unitOfWork.TermCourseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (termCourse == null)
                throw new NotFoundException(nameof(TermCourse),request.Id);

            var result = _unitOfWork.TermCourseRepository.SoftDelete(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}
