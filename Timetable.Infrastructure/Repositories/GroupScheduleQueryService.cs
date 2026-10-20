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
            s.Name AS SubjectName,
            t.LastName || ' ' || t.FirstName AS TeacherName,
            c.Name AS ClassroomName,
            l.Date, 
            l.StartTime, 
            l.EndTime
        FROM Lessons l
        LEFT JOIN Subjects s ON l.SubjectId = s.Id
        LEFT JOIN Teachers t ON l.TeacherId = t.Id
        LEFT JOIN Classrooms c ON l.ClassroomId = c.Id
        WHERE l.GroupId = @GroupId 
          AND l.Date >= @StartDate 
          AND l.Date <= @EndDate
        ORDER BY l.Date, l.StartTime;";

        using var connection = new SqliteConnection(_connectionString);


        var rawRows = await connection.QueryAsync(sql, new
        {
            GroupId = groupId.ToString().ToUpper(),
            StartDate = startDate.ToString("yyyy-MM-dd"),
            EndDate = endDate.ToString("yyyy-MM-dd")
        });

        return rawRows.Select(r => new LessonDto
        {
            Id = Guid.Parse((string)r.Id),
            SubjectName = (string)r.SubjectName,
            TeacherName = (string)r.TeacherName,
            ClassroomName = (string)r.ClassroomName,
            Date = DateOnly.Parse((string)r.Date),
            StartTime = TimeSpan.Parse((string)r.StartTime),
            EndTime = TimeSpan.Parse((string)r.EndTime)
        }).ToList();
    }
}