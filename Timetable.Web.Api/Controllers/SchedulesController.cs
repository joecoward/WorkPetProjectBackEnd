using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Lessons.Queries.GetGroupSchedule;

namespace Timetable.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly ISender _sender;

    public SchedulesController(ISender sender)
    {
        _sender = sender;
    }

    // GET: api/schedules/group/{groupId}?startDate=2026-09-01&endDate=2026-09-07
    [HttpGet("group/{groupId:guid}")]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetGroupSchedule(
        Guid groupId,
        [FromQuery] DateOnly startDate,
        [FromQuery] DateOnly endDate,
        CancellationToken cancellationToken)
    {
        var query = new GetGroupScheduleQuery(groupId, startDate, endDate);
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result);
    }
}