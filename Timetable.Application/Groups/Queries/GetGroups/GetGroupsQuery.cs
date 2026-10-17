using MediatR;

namespace Timetable.Domain.Groups.Queries.GetGroups
{
    public record GetGroupsQuery() : IRequest<IList<GroupDto>>;
}
