using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.Application.Exceptions;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Persistence.Repositories.Common;

namespace SLMS.Persistence.Repositories.InstituteManagment
{
    public class ClassificationRepository : BaseRepository<Classification>, IClassificationRepository
    {
        private readonly SLMSDbContext _context;

        public ClassificationRepository(SLMSDbContext context) : base(context)
        {

            _context = context;
        }

        public async Task<Classification?> GetByIdWithAbsentPresentCertificate(Guid ClassificationId, CancellationToken cancellationToken)
        {
            return await _context.Set<Classification>()
                   .Include(x => x.AbsentPresents).Include(x => x.Certificate)
                   .FirstOrDefaultAsync(x => x.Id == ClassificationId && !x.IsDeleted, cancellationToken);
        }

        public async Task<Classification?> GetScheduleConflictAsync(Guid PupilMembershipId, 
            Guid termCourseId, Guid instititueId, CancellationToken cancellationToken)
        {

            var termCourse =await _context.Set<TermCourse>().Include(x => x.TermCourseSessionDays)
                .FirstOrDefaultAsync(x => 
                x.Id == termCourseId && 
                x.InstituteId == instititueId && 
                x.IsActive && 
                !x.IsDeleted,cancellationToken);
           
            if (termCourse is null)
                throw new NotFoundException();

            var weekDays = termCourse.TermCourseSessionDays
      .Select(x => x.WeekDay)
      .ToHashSet();

            var confilict =await _context.Set<Classification>().Include(x => x.TermCourse)
                .ThenInclude(x => x.TermCourseSessionDays)
                .Where(x =>
                       x.PupilMembershipId == PupilMembershipId &&
                       !x.IsDeleted &&
                       !x.TermCourse!.IsDeleted &&
                       x.TermCourse.IsActive &&
                       x.TermCourse!.InstituteId == instititueId &&
                       x.TermCourse.StartDate <= termCourse.EndDate &&
                       x.TermCourse.EndDate >= termCourse.StartDate &&
                       x.TermCourse.StartTime < termCourse.EndTime &&
                       x.TermCourse.EndTime > termCourse.StartTime)
                .FirstOrDefaultAsync(x =>
                                     x.TermCourse!.TermCourseSessionDays
                .Any(d => weekDays.Contains(d.WeekDay)),
                     cancellationToken);

            return confilict;
        }

       
    }

}
