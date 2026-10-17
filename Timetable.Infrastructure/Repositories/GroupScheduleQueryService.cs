using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Application.Lessons.Queries.GetGroupSchedule;

namespace Timetable.Infrastructure.Queries;

public class GroupScheduleQueryService : IGroupScheduleQueryService
{
    private readonly string _connectionString;

    public GroupScheduleQueryService(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    public async Task<IList<LessonDto>> GetScheduleAsync(Guid groupId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            SELECT 
                l.Id, 
                'Mock Subject' AS SubjectName,
                'Mock Teacher' AS TeacherName,
                'Mock Room' AS ClassroomName,
                l.Date, 
                l.StartTime, 
                l.EndTime
            FROM Lessons l
            WHERE l.GroupId = @GroupId 
              AND l.Date >= @StartDate 
              AND l.Date <= @EndDate
            ORDER BY l.Date, l.StartTime;";

        using var connection = new SqliteConnection(_connectionString);

        return (await connection.QueryAsync<LessonDto>(sql, new
        {
            GroupId = groupId,
            StartDate = startDate.ToString("yyyy-MM-dd"),
            EndDate = endDate.ToString("yyyy-MM-dd")
        })).AsList();
    }
}