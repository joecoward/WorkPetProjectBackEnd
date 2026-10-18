using MediatR;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Teachers.Commands.CreateTeacher;

public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
{
    private readonly ITeacherRepository _teacherRepository;

    public CreateTeacherCommandHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher(
            Guid.NewGuid(),
            request.FirstName,
            request.LastName
            );

        await _teacherRepository.AddAsync(teacher, cancellationToken);

        return teacher.Id;
    }
}