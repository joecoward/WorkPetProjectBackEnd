using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Application.Teachers.Queries.GetAllTeachers;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Subjects.Queries
{
    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, List<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;

        public GetSubjectsQueryHandler(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<List<SubjectDto>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _subjectRepository.GetAllAsync(cancellationToken);

            return teachers
                .Select(t => new SubjectDto(t.Id, t.Name))
                .ToList();
        }
    }
}
