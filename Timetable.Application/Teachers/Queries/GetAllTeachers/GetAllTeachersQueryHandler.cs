using MediatR;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Teachers.Queries.GetAllTeachers;

public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherDto>>
{
    private readonly ITeacherRepository _teacherRepository;

    public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<List<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await _teacherRepository.GetAllAsync(cancellationToken);

        return teachers
            .Select(t => new TeacherDto(t.Id, t.FirstName, t.LastName))
            .ToList();
    }
}