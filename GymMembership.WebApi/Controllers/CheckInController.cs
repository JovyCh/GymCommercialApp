using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CheckInController : ControllerBase
{
    private readonly ISender _mediator;

    public CheckInController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("checkIn")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] CreateCheckInCommand command, CancellationToken cancellationToken)
    {
        var checkInId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Register), new { id = checkInId });
    }
    [HttpGet("getCheckIns")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CheckIn>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<CheckIn>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllCheckInsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
