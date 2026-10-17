using MediatR;

namespace Timetable.Application.Lessons.Queries.GetGroupSchedule;

public class GetGroupScheduleQueryHandler : IRequestHandler<GetGroupScheduleQuery, IList<LessonDto>>
{
    private readonly IGroupScheduleQueryService _queryService;

    public GetGroupScheduleQueryHandler(IGroupScheduleQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IList<LessonDto>> Handle(GetGroupScheduleQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetScheduleAsync(request.GroupId, request.StartDate, request.EndDate, cancellationToken);
    }
}