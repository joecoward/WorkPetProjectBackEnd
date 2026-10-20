using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Classrooms.Commands.CreateClassroom;
using Timetable.Application.Classrooms.Queries;

namespace Timetable.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomsController : ControllerBase
{
    private readonly ISender _sender;

    public ClassroomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClassroomCommand command, CancellationToken cancellationToken)
    {
        var classroomId = await _sender.Send(command, cancellationToken);
        return Ok(classroomId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var classrooms = await _sender.Send(new GetClassroomsQuery(), cancellationToken);
        return Ok(classrooms);
    }
}