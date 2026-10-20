using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Subjects.Commands.CreateSubject;
using Timetable.Application.Subjects.Queries;

namespace Timetable.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectsController : ControllerBase
{
    private readonly ISender _sender;

    public SubjectsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subjectId = await _sender.Send(command, cancellationToken);
        return Ok(subjectId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var subjects = await _sender.Send(new GetSubjectsQuery(), cancellationToken);
        return Ok(subjects);
    }
}