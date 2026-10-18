using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    internal class TeacherRepository : ITeacherRepository
    {
        public Task AddAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}