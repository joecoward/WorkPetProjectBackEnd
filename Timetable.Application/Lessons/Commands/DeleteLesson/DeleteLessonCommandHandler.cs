using MediatR;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Lessons.Commands.DeleteLesson;

public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand>
{
    private readonly ILessonRepository _lessonRepository;

    public DeleteLessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonRepository.GetByIdAsync(request.LessonId, cancellationToken);

        if (lesson == null)
            throw new Exception($"Id {request.LessonId} not found.");

        await _lessonRepository.DeleteAsync(lesson, cancellationToken);
    }
}