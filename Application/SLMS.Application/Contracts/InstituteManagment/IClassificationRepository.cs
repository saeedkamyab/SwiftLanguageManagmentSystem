using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;

namespace SLMS.Application.Contracts.InstituteManagment
{
    public interface IClassificationRepository : IBaseRepository<Classification>
    {

        public Task<Classification?> GetScheduleConflictAsync(
            Guid PupilMembershipId, Guid termCourseId, Guid instititueId,
    CancellationToken cancellationToken);

        public Task<Classification?> GetByIdWithAbsentPresentCertificate(
            Guid ClassificationId,CancellationToken cancellationToken);

    }
}
