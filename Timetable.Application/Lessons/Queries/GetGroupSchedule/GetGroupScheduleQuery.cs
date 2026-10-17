using MediatR;


namespace Timetable.Application.Lessons.Queries.GetGroupSchedule
{
    public record GetGroupScheduleQuery(
        Guid GroupId,
        DateOnly StartDate,
        DateOnly EndDate) : IRequest<IList<LessonDto>>;
}
