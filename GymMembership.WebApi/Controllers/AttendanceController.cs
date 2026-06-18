using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly ISender _mediator;

    public AttendanceController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAttendance([FromBody] CreateAttendanceCommand command, CancellationToken cancellationToken)
    {
        var attendanceClassId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateAttendance), new { id = attendanceClassId });
    }
    [HttpPatch("markAttendance")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<IActionResult> MarkAttendance([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var query = new MarkAttendanceCommand(id);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
    [HttpPatch("cancelAttendance")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<IActionResult> CancelAttendance([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var query = new CancelledAttendanceCommand(id);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
