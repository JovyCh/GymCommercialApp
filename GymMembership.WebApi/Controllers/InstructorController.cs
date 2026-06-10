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
    [HttpPost("register_instructor")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterInstructor([FromBody] RegisterInstructorCommand command, CancellationToken cancellationToken)
    {
        var instructorId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(RegisterInstructor), new { id = instructorId });
    }
}

