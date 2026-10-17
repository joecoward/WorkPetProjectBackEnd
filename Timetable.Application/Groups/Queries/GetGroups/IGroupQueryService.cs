using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Application.Groups.Queries.GetGroups
{
    public interface IGroupQueryService
    {
        Task<IList<GroupDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
