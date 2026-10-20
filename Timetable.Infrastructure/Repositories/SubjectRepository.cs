using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly string _connectionString;

        public SubjectRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }
        public async Task AddAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            const string sql = "INSERT INTO Subjects (Id, Name) VALUES (@Id, @Name);";

            using var connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(sql, new
            {
                Id = subject.Id.ToString().ToUpper(),
                Name = subject.Name
            });
        }

        public Task DeleteAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subject>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT Id, Name FROM Subjects ORDER BY Name;";

            using var connection = new SqliteConnection(_connectionString);
            var rawRows = await connection.QueryAsync(sql);

            return rawRows.Select(r => new Subject(
                Guid.Parse((string)r.Id),
                (string)r.Name
            )).ToList();
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