using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.Persistance;
using SLMS.Application.Exceptions;

namespace SLMS.Application.Features.InstituteManagement.Certificate.Commands
{
    internal static class CertificateCommandGuards
    {
        public static async Task EnsureClassificationBelongsToInstituteAsync(
            IUnitOfWork unitOfWork,
            Guid classificationId,
            Guid instituteId,
            CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.ClassificationRepository.GetQueryable()
                .AnyAsync(x =>
                    x.Id == classificationId &&
                    x.TermCourse != null &&
                    x.TermCourse.InstituteId == instituteId,
                    cancellationToken);

            if (!exists)
                throw new NotFoundException("Classification was not found for this institute.");
        }

        public static async Task EnsureCertificateBelongsToInstituteAsync(
            IUnitOfWork unitOfWork,
            Guid certificateId,
            Guid instituteId,
            CancellationToken cancellationToken)
        {
            var exists = await unitOfWork.CertificateRepository.GetQueryable()
                .AnyAsync(x =>
                    x.Id == certificateId &&
                    x.Classification.TermCourse != null &&
                    x.Classification.TermCourse.InstituteId == instituteId,
                    cancellationToken);

            if (!exists)
                throw new NotFoundException("Certificate was not found for this institute.");
        }

        public static async Task EnsureClassificationHasNoCertificateAsync(
            IUnitOfWork unitOfWork,
            Guid classificationId,
            Guid? currentCertificateId,
            CancellationToken cancellationToken)
        {
            var query = unitOfWork.CertificateRepository.GetQueryable()
                .Where(x => x.ClassificationId == classificationId);

            if (currentCertificateId.HasValue)
                query = query.Where(x => x.Id != currentCertificateId.Value);

            var exists = await query.AnyAsync(cancellationToken);

            if (exists)
                throw new ConflictException("A certificate already exists for this classification.");
        }
    }
}
