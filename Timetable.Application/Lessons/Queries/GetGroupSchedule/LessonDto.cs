using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule
{
    public record LessonDto(
        Guid Id,
        string SubjectName,
        string TeacherName,
        string ClassroomName,
        DateOnly Date,
        TimeSpan StartTime,
        TimeSpan EndTime);
}
