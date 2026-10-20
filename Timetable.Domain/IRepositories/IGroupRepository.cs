using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;

namespace Timetable.Domain.IRepositories
{
    public interface IGroupRepository
    {
        Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Group group, CancellationToken cancellationToken = default);
        Task DeleteAsync(Group group, CancellationToken cancellationToken = default);

    }
}
