using Microsoft.EntityFrameworkCore;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Persistence.Repositories.Common;
using SLMS.Shared.Enums;

namespace SLMS.Persistence.Repositories.InstituteManagment
{
    public class TermCourseRepository : BaseRepository<TermCourse>, ITermCourseRepository
    {
        private readonly SLMSDbContext _context;

        public TermCourseRepository(SLMSDbContext context) : base(context)
        {

            _context = context;
        }
        public async Task<bool> HasTeacherConflictAsync(Guid teacherId,
           TimeOnly startTime, TimeOnly endTime,
           DateOnly startDate, DateOnly endDate,
           ICollection<WeekDay> weekDay, 
           CancellationToken cancellationToken,
             Guid? excludeTermCourseId = null)
        {

            var query = _context.Set<TermCourse>().Where(x =>
                x.TeacherId == teacherId &&
                x.StartTime < endTime && x.EndTime > startTime &&
                x.StartDate <= endDate && x.EndDate >= startDate &&
                x.IsActive==true);

            if (excludeTermCourseId.HasValue)
            {
                query = query.Where(x => x.Id != excludeTermCourseId.Value);
            }


            var result=await query.SelectMany(x => x.TermCourseSessionDays)
                .AnyAsync(d => weekDay.Contains(d.WeekDay), cancellationToken);
            
            return result;
        }
        public async Task<bool> HasRoomConflictAsync(Guid roomId,
            TimeOnly startTime, TimeOnly endTime,
            DateOnly startDate, DateOnly endDate,
            ICollection<WeekDay> weekDay,
            CancellationToken cancellationToken,
            Guid? excludeTermCourseId = null)
        {
            var query = _context.Set<TermCourse>().Where(x =>
                           x.RoomId == roomId &&
                           x.StartTime < endTime && x.EndTime > startTime &&
                           x.StartDate <= endDate && x.EndDate >= startDate &&
                           x.IsActive == true);

            if (excludeTermCourseId.HasValue)
            {
                query = query.Where(x => x.Id != excludeTermCourseId.Value);
            }


            var result = await query.SelectMany(x => x.TermCourseSessionDays)
                           .AnyAsync(d => weekDay.Contains(d.WeekDay), cancellationToken);
            return result;
        }

        public async Task<TermCourse?> GetByIdWithSessionDaysAsync(Guid id, 
            CancellationToken cancellationToken = default)
        {
            return await _context.Set<TermCourse>()
                .Include(x => x.TermCourseSessionDays)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
        }
    }

}
