using MediatR;
using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Application.Groups.Queries.GetGroups;

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, IList<GroupDto>>
{
    private readonly IGroupQueryService _queryService;

    public GetGroupsQueryHandler(IGroupQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IList<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetGroupsAsync(cancellationToken);
    }
}