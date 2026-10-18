using MediatR;

namespace Timetable.Application.Classrooms.Commands.CreateClassroom;

public record CreateClassroomCommand(string Name, int Capacity) : IRequest<Guid>;