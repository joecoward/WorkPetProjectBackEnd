using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule
{
    public record LessonDto
    {
        public Guid Id { get; init; }
        public string SubjectName { get; init; } = string.Empty;
        public string TeacherName { get; init; } = string.Empty;
        public string ClassroomName { get; init; } = string.Empty;
        public DateOnly Date { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
    }
}
