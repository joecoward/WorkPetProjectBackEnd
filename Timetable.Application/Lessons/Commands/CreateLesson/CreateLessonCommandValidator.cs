using FluentValidation;

namespace Timetable.Application.Lessons.Commands.CreateLesson;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommand>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(x => x.SubjectId).NotEmpty().WithMessage("SubjectId is required .");
        RuleFor(x => x.TeacherId).NotEmpty().WithMessage("TeacherId is required.");
        RuleFor(x => x.GroupId).NotEmpty().WithMessage("GroupId is required.");
        RuleFor(x => x.ClassroomId).NotEmpty().WithMessage("ClassroomId is required.");
    }
}