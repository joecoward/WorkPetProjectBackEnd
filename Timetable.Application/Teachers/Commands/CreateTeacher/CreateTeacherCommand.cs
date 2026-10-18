using MediatR;


namespace Timetable.Application.Teachers.Commands.CreateTeacher
{
    public record CreateTeacherCommand(string FirstName, string LastName) : IRequest<Guid>;
}
