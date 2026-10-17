using Microsoft.EntityFrameworkCore;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;

namespace Timetable.Infrastructure.Database;

public class SqliteConnectionContext : DbContext
{
    public SqliteConnectionContext(DbContextOptions<SqliteConnectionContext> options) : base(options) { }

    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(SqliteConnectionContext).Assembly);
        base.OnModelCreating(builder);
    }
}