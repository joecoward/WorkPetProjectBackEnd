using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    internal class ClassroomRepository : IClassroomRepository
    {
        public Task AddAsync(Classroom classroom, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Classroom classroom, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Classroom>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Classroom?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Classroom classroom, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}