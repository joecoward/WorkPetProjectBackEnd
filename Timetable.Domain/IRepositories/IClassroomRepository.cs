using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;

namespace Timetable.Domain.IRepositories
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Classroom?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Classroom classroom, CancellationToken cancellationToken = default);
        Task UpdateAsync(Classroom classroom, CancellationToken cancellationToken = default);
        Task DeleteAsync(Classroom classroom, CancellationToken cancellationToken = default);
    }
}
