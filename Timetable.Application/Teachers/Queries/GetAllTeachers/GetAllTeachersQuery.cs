using MediatR;

namespace Timetable.Application.Teachers.Queries.GetAllTeachers;

public record TeacherDto(Guid Id, string FirstName, string LastName);

public record GetAllTeachersQuery : IRequest<List<TeacherDto>>;