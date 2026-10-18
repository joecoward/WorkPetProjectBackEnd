using System;

using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Application.Groups.Queries.GetGroups
{
    public interface IGroupQueryService
    {
        public Task<IList<GroupDto>> GetGroupsAsync(CancellationToken cancellationToken = default);
    }
}
