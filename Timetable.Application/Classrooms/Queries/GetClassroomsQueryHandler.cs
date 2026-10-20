using MediatR;
using Timetable.Domain.IRepositories;

namespace Timetable.Application.Classrooms.Queries
{
    public class GetClassroomsQueryHandler : IRequestHandler<GetClassroomsQuery, List<ClassroomDto>>
    {
        private readonly IClassroomRepository _classroomRepository;

        public GetClassroomsQueryHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<List<ClassroomDto>> Handle(GetClassroomsQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _classroomRepository.GetAllAsync(cancellationToken);

            return teachers
                .Select(t => new ClassroomDto(t.Id, t.Name, t.Capacity))
                .ToList();
        }
    }
}
