using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Domain.Entities;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly string _connectionString;

    public GroupRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public async Task<Group?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Groups WHERE Id = @Id;";

        using var connection = new SqliteConnection(_connectionString);
        return await connection.QuerySingleOrDefaultAsync<Group>(sql, new { Id = id });
    }

    public async Task<List<Group>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Groups ORDER BY Name;";

        using var connection = new SqliteConnection(_connectionString);
        return (await connection.QueryAsync<Group>(sql)).AsList();
    }
}