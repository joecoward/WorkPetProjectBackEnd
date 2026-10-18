using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Application.Groups.Queries.GetGroups;
using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Infrastructure.Repositories;

public class GroupQueryService : IGroupQueryService
{
    private readonly string _connectionString;

    public GroupQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    }

    public async Task<IList<GroupDto>> GetGroupsAsync(CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, Name FROM Groups ORDER BY Name;";

        using var connection = new SqliteConnection(_connectionString);

        return (await connection.QueryAsync<GroupDto>(sql)).AsList();
    }
}