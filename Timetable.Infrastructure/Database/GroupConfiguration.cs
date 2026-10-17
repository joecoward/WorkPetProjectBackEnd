using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timetable.Domain.Entities;

namespace Timetable.Infrastructure.Database;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).IsRequired();
    }
}