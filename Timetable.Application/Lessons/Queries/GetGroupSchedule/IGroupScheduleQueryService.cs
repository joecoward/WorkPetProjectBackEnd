using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule
{
    public interface IGroupScheduleQueryService
    {
        Task<IList<LessonDto>> GetScheduleAsync(Guid Id,DateOnly startdate, DateOnly enddate, CancellationToken cancellationToken = default);
    }
}
