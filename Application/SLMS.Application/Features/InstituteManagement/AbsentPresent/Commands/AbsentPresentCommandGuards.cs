using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.AbsentPresent.Commands
{
    internal static class AbsentPresentCommandGuards
    {
        public static async Task EnsureClassificationBelongsToInstituteAsync(
            IUnitOfWork unitOfWork,
            Guid classifictionId,
            Guid instituteId,
            CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.ClassificationRepository.GetQueryable()
                .AnyAsync(x =>
                    x.Id == classifictionId &&
                    x.TermCourse != null &&
                    x.TermCourse.InstituteId == instituteId,
                    cancellationToken);

            if (!exists)
                throw new NotFoundException("Classification was not found for this institute.");
        }

        public static async Task EnsureAbsentPresentBelongsToInstituteAsync(
            IUnitOfWork unitOfWork,
            Guid absentPresentId,
            Guid instituteId,
            CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.AbsentPresentRepository.GetQueryable()
                .AnyAsync(x =>
                    x.Id == absentPresentId &&
                    x.Classifiction.TermCourse != null &&
                    x.Classifiction.TermCourse.InstituteId == instituteId,
                    cancellationToken);

            if (!exists)
                throw new NotFoundException("AbsentPresent was not found for this institute.");
        }
    }
}
