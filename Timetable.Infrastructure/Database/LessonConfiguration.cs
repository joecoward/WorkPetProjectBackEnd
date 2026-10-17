using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timetable.Domain.Aggregates;

namespace Timetable.Infrastructure.Database;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(l => l.Id);

        builder.OwnsOne(l => l.Time, ts =>
        {
            ts.Property(t => t.StartTime).HasColumnName("StartTime");
            ts.Property(t => t.EndTime).HasColumnName("EndTime");
        });
    }
}