using MediatR;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Classrooms.Commands.CreateClassroom;

public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, Guid>
{
    private readonly IClassroomRepository _classroomRepository;

    public CreateClassroomCommandHandler(IClassroomRepository classroomRepository)
    {
        _classroomRepository = classroomRepository;
    }

    public async Task<Guid> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
    {
        var classroom = new Classroom(
            Guid.NewGuid(),
            request.Name,
            request.Capacity
            );

        await _classroomRepository.AddAsync(classroom, cancellationToken);

        return classroom.Id;
    }
}