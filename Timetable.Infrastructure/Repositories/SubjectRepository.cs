using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    internal class SubjectRepository : ISubjectRepository
    {
        public Task AddAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subject>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Subject?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}