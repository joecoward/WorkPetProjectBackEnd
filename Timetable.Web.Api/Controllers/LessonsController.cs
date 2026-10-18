using MediatR;
using Microsoft.AspNetCore.Mvc;
using Timetable.Application.Lessons.Commands.CreateLesson;
using Timetable.Application.Lessons.Commands.DeleteLesson;
using Timetable.Application.Lessons.Commands.UpdateLesson;

namespace Timetable.Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LessonsController : ControllerBase
{
    private readonly ISender _sender;

    public LessonsController(ISender sender)
    {
        _sender = sender;
    }


    // POST: api/lessons
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateLessonCommand command, CancellationToken cancellationToken)
    {
        var lessonId = await _sender.Send(command, cancellationToken);
        return Created(string.Empty, lessonId);
    }


    // PUT: api/lessons/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLessonCommand command, CancellationToken cancellationToken)
    {
        if (id != command.LessonId)
            return BadRequest("ID у URL не збігається з ID у тілі запиту.");

        await _sender.Send(command, cancellationToken);
        return NoContent();
    }


    // DELETE: api/lessons/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _sender.Send(new DeleteLessonCommand(id), cancellationToken);
        return NoContent();
    }
}