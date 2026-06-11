using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InstructorController : ControllerBase
{
    private readonly ISender _mediator;

    public InstructorController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("registerInstructor")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorCommand command, CancellationToken cancellationToken)
    {
        var instructorId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(RegisterInstructor), new { id = instructorId });
    }
    [HttpGet("getInstructors")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Instructor>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Instructor>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllInstructorsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("instructorDelete/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteInstructorCommand(id);

        var instructorId = await _mediator.Send(command, cancellationToken);

        return Ok(instructorId);
    }

    [HttpGet("searchInstructor")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Instructor>))]
    public async Task<ActionResult<List<Instructor>>> Search([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var query = new SearchInstructorQuery(id, name);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}

