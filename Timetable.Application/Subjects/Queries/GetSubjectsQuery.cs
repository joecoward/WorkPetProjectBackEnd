using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Timetable.Application.Subjects.Queries
{
    public record SubjectDto(Guid Id, string Name);

    public record GetSubjectsQuery : IRequest<List<SubjectDto>>;
}
