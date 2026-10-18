namespace Timetable.Domain.Groups.Queries.GetGroups
{
    public record GroupDto {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
