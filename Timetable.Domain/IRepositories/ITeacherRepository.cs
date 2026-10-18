using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;

namespace Timetable.Domain.IRepositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task UpdateAsync(Teacher teacher, CancellationToken cancellationToken = default);
        Task DeleteAsync(Teacher teacher, CancellationToken cancellationToken = default);
    }
}
