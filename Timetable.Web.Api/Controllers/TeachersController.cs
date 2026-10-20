using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Teachers.Commands.CreateTeacher;
using Timetable.Application.Teachers.Queries.GetAllTeachers;

namespace Timetable.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ISender _sender;

    public TeachersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherCommand command, CancellationToken cancellationToken)
    {
        var teacherId = await _sender.Send(command, cancellationToken);
        return Ok(teacherId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var teachers = await _sender.Send(new GetAllTeachersQuery(), cancellationToken);
        return Ok(teachers);
    }
}