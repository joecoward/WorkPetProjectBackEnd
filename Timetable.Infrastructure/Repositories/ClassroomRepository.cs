using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly string _connectionString;

        public ClassroomRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found.");
        }
        public async Task AddAsync(Classroom classroom, CancellationToken cancellationToken = default)
        {
            const string sql = "INSERT INTO Classrooms (Id, Name, Capacity) VALUES (@Id, @Name, @Capacity);";

            using var connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(sql, new
            {
                Id = classroom.Id.ToString().ToUpper(),
                Name = classroom.Name,
                Capacity = classroom.Capacity
            });
        }

        public Task DeleteAsync(Classroom classroom, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Classroom>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            const string sql = "SELECT Id, Name, Capacity FROM Classrooms ORDER BY Name;";

            using var connection = new SqliteConnection(_connectionString);
            var rawRows = await connection.QueryAsync(sql);

            return rawRows.Select(r => new Classroom(
                Guid.Parse((string)r.Id),
                (string)r.Name,
                Convert.ToInt32(r.Capacity)
            )).ToList();
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