using MediatR;

namespace Timetable.Application.Lessons.Commands.UpdateLesson
{
    public record UpdateLessonCommand(
        Guid LessonId,
        DateOnly NewDate,
        TimeSpan NewStartTime,
        TimeSpan NewEndTime) : IRequest;
}
