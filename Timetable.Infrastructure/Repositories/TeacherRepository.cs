using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }
        public async Task AddAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            const string sql = "INSERT INTO Teachers (Id, FirstName, LastName) VALUES (@Id, @FirstName, @LastName);";

            using var connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(sql, new
            {
                Id = teacher.Id.ToString().ToUpper(),
                FirstName = teacher.FirstName,
                LastName = teacher.LastName
            });
        }

        public Task DeleteAsync(Teacher teacher, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Teacher>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT Id, FirstName, LastName FROM Teachers ORDER BY LastName, FirstName;";

            using var connection = new SqliteConnection(_connectionString);
            var rawRows = await connection.QueryAsync(sql);

            return rawRows.Select(r => new Teacher(
                Guid.Parse((string)r.Id),
                (string)r.FirstName,
                (string)r.LastName
            )).ToList();
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