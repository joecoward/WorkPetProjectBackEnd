using MediatR;
using Timetable.Domain.Aggregates;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, Guid>
{
    private readonly ILessonRepository _lessonRepository;

    public CreateLessonCommandHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<Guid> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        //Value Object
        var timeSlot = new TimeSlot(request.StartTime, request.EndTime);

        //Aggregate Root
        var lesson = new Lesson(
            Guid.NewGuid(),
            request.SubjectId,
            request.TeacherId,
            request.GroupId,
            request.ClassroomId,
            request.Date,
            timeSlot);

        await _lessonRepository.AddAsync(lesson, cancellationToken);

        return lesson.Id;
    }
}