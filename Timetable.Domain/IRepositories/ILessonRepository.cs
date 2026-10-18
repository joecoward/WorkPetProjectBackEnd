using System;
using System.Collections.Generic;
using System.Text;
using Timetable.Domain.Aggregates;

namespace Timetable.Domain.IRepositories
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Lesson?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Lesson lesson, CancellationToken cancellationToken = default);
        Task UpdateAsync(Lesson lesson, CancellationToken cancellationToken = default);
        Task DeleteAsync(Lesson lesson, CancellationToken cancellationToken = default);
    }
}
