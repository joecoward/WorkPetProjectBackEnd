using MediatR;

namespace Timetable.Application.Lessons.Commands.CreateLesson
{
    public record CreateLessonCommand(
        Guid SubjectId,
        Guid TeacherId,
        Guid GroupId,
        Guid ClassroomId,
        DateOnly Date,
        TimeSpan StartTime,
        TimeSpan EndTime) : IRequest<Guid>;
}
