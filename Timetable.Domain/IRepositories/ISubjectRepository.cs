using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Entities;

namespace Timetable.Domain.IRepositories
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Subject?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Subject subject, CancellationToken cancellationToken = default);
        Task UpdateAsync(Subject subject, CancellationToken cancellationToken = default);
        Task DeleteAsync(Subject subject, CancellationToken cancellationToken = default);
    }
}
