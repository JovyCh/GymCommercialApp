using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ScheduledClassController : ControllerBase
{
    private readonly ISender _mediator;

    public ScheduledClassController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("CreateClass")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMembershipPlan([FromBody] CreateScheduledClassCommand command, CancellationToken cancellationToken)
    {
        var scheduledClassId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateMembershipPlan), new { id = scheduledClassId });
    }
    [HttpGet("getClasses")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ScheduledClass>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<ScheduledClass>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllClassesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
    [HttpDelete("classDelete/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteClassCommand(id);

        var classId = await _mediator.Send(command, cancellationToken);

        return Ok(classId);
    }
    [HttpGet("searchClasses")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ScheduledClass>))]
    public async Task<ActionResult<List<ScheduledClass>>> Search([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var query = new SearchClassesQuery(id, name);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
    [HttpPatch("cancelClass")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<ActionResult<List<ScheduledClass>>> CancelClass([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var query = new CancelClassCommand(id);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
