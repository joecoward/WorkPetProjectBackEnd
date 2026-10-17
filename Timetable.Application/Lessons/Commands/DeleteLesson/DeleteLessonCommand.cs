using MediatR;

namespace Timetable.Application.Lessons.Commands.DeleteLesson
{
    public record DeleteLessonCommand(Guid LessonId) : IRequest;
}
