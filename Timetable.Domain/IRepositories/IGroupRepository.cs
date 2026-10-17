using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Entities;

namespace Timetable.Domain.IRepositories
{
    public interface IGroupRepository
    {
        Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Group>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
