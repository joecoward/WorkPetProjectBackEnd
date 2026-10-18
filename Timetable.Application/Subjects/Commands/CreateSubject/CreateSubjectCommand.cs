using MediatR;

namespace Timetable.Application.Subjects.Commands.CreateSubject;

public record CreateSubjectCommand(string Name) : IRequest<Guid>;