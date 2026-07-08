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
            var termCourse = await _unitOfWork.TermCourseRepository.GetByIdWithClassificationsAsync(request.Id, cancellationToken);
            if (termCourse == null)
                throw new NotFoundException(nameof(TermCourse), request.Id);

            if (termCourse.Classifications.Count > 0)
            {
                throw new ConflictException("ترم / دوره هایی که کلاس بندی شده اند قابل حذف نمی باشند.");
            }
            var result = _unitOfWork.TermCourseRepository.SoftDeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.CommitAsync();

            return true;

        }
    }
}
