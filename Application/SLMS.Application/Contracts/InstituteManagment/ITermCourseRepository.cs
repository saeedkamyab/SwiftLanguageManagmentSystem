using SLMS.Application.Contracts.Persistance;
using SLMS.ApplicationCore.Domain.InstituteManagement;
using SLMS.Shared.Enums;

namespace SLMS.Application.Contracts.InstituteManagment
{
    public interface ITermCourseRepository : IBaseRepository<TermCourse>
    {

        public Task<bool> HasTeacherConflictAsync(
            Guid teacherId, 
           TimeOnly startTime, TimeOnly endTime,
           DateOnly startDate, DateOnly endDate,
           ICollection<WeekDay> weekDay,
           CancellationToken cancellationToken,
           Guid? excludeTermCourseId = null);

        public Task<bool> HasRoomConflictAsync(
            Guid roomId,
            TimeOnly startTime,TimeOnly endTime,
            DateOnly startDate,DateOnly endDate,
             ICollection<WeekDay> weekDay,
            CancellationToken cancellationToken,
            Guid? excludeTermCourseId = null);

       
    }
}
