using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Timetable.Domain.Aggregates;
using Timetable.Domain.IRepositories;

namespace Timetable.Infrastructure.Repositories;

public class LessonRepository : ILessonRepository
{
    private readonly string _connectionString;

    public LessonRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    public async Task<Lesson?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT * FROM Lessons WHERE Id = @Id;";

        using var connection = new SqliteConnection(_connectionString);
        var result = await connection.QuerySingleOrDefaultAsync<dynamic>(sql, new { Id = id });

        if (result == null) return null;

        var timeSlot = new TimeSlot(
            TimeSpan.Parse(result.StartTime.ToString()),
            TimeSpan.Parse(result.EndTime.ToString()));

        return new Lesson(
            Guid.Parse(result.Id.ToString()),
            Guid.Parse(result.SubjectId.ToString()),
            Guid.Parse(result.TeacherId.ToString()),
            Guid.Parse(result.GroupId.ToString()),
            Guid.Parse(result.ClassroomId.ToString()),
            DateOnly.Parse(result.Date.ToString()),
            timeSlot);
    }

    public async Task AddAsync(Lesson lesson, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            INSERT INTO Lessons (Id, SubjectId, TeacherId, GroupId, ClassroomId, Date, StartTime, EndTime)
            VALUES (@Id, @SubjectId, @TeacherId, @GroupId, @ClassroomId, @Date, @StartTime, @EndTime);";

        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(sql, new
        {
            lesson.Id,
            lesson.SubjectId,
            lesson.TeacherId,
            lesson.GroupId,
            lesson.ClassroomId,
            Date = lesson.Date.ToString("yyyy-MM-dd"),
            StartTime = lesson.Time.StartTime.ToString(),
            EndTime = lesson.Time.EndTime.ToString()
        });
    }

    public async Task UpdateAsync(Lesson lesson, CancellationToken cancellationToken = default)
    {
        const string sql = @"
            UPDATE Lessons
            SET SubjectId = @SubjectId, TeacherId = @TeacherId, GroupId = @GroupId, 
                ClassroomId = @ClassroomId, Date = @Date, StartTime = @StartTime, EndTime = @EndTime
            WHERE Id = @Id;";

        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(sql, new
        {
            lesson.Id,
            lesson.SubjectId,
            lesson.TeacherId,
            lesson.GroupId,
            lesson.ClassroomId,
            Date = lesson.Date.ToString("yyyy-MM-dd"),
            StartTime = lesson.Time.StartTime.ToString(),
            EndTime = lesson.Time.EndTime.ToString()
        });
    }

    public async Task DeleteAsync(Lesson lesson, CancellationToken cancellationToken = default)
    {
        const string sql = "DELETE FROM Lessons WHERE Id = @Id;";

        using var connection = new SqliteConnection(_connectionString);
        await connection.ExecuteAsync(sql, new { lesson.Id });
    }
}