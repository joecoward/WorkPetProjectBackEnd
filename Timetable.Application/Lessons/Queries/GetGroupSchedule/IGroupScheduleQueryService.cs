using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule
{
    public interface IGroupScheduleQueryService
    {
        Task<IList<LessonDto>> GetScheduleAsync(Guid groupId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);
    }
}
