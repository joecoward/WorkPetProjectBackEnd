using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Groups.Commands.CreateGroup;
using Timetable.Application.Groups.Commands.DeleteLesson;
using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupsController : ControllerBase
{
    private readonly ISender _sender;

    public GroupsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups(CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetGroupsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateGroup(
        [FromBody] CreateGroupCommand command,
        CancellationToken cancellationToken)
    {
        var groupId = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetGroups), new { id = groupId }, groupId);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteGroupCommand(id), cancellationToken);
        return NoContent();
    }
}