using MediatR;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule;

public class GetGroupScheduleQueryHandler : IRequestHandler<GetGroupScheduleQuery, IEnumerable<LessonDto>>
{
    private readonly IGroupScheduleQueryService _queryService;

    public GetGroupScheduleQueryHandler(IGroupScheduleQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IEnumerable<LessonDto>> Handle(GetGroupScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetScheduleAsync(request.GroupId, request.StartDate, request.EndDate, cancellationToken);
    }
}