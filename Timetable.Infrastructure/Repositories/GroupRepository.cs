// src/Timetable.Infrastructure/Repositories/GroupRepository.cs
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
        const string sql = "SELECT Id, Name FROM Groups WHERE UPPER(Id) = UPPER(@Id);";

        using var connection = new SqliteConnection(_connectionString);
        var rawGroup = await connection.QuerySingleOrDefaultAsync(sql, new { Id = id.ToString().ToUpper() });

        if (rawGroup == null)
            return null;

        return new Group(Guid.Parse((string)rawGroup.Id), (string)rawGroup.Name);
    }

    public async Task AddAsync(Group group, CancellationToken cancellationToken = default)
    {
        const string sql = "INSERT INTO Groups (Id, Name) VALUES (@Id, @Name);";

        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(sql, new
        {
            Id = group.Id.ToString().ToUpper(),
            Name = group.Name
        });
    }

    public async Task DeleteAsync(Group group, CancellationToken cancellationToken = default)
    {
        const string sql = "DELETE FROM Groups WHERE Id = @Id;";

        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(sql, new
        {
            Id = group.Id.ToString().ToUpper()
        });
    }
}