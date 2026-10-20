using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Application.Classrooms.Queries
{
    public record ClassroomDto(Guid Id, string Name,int Capacity);

    public record GetClassroomsQuery : IRequest<List<ClassroomDto>>;
}
