using MediatR;
using Timetable.Domain.Aggregates;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand>
{
    private readonly ILessonRepository _lessonRepository;

    public UpdateLessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        var lesson = await _lessonRepository.GetByIdAsync(request.LessonId, cancellationToken);

        if (lesson == null)
            throw new Exception($"Id {request.LessonId} not found.");

        var newTimeSlot = new TimeSlot(request.NewStartTime, request.NewEndTime);

        lesson.Reschedule(request.NewDate, newTimeSlot);

        await _lessonRepository.UpdateAsync(lesson, cancellationToken);
    }
}