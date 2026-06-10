using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly ISender _mediator;

    public MembersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterMemberCommand command, CancellationToken cancellationToken)
    {
        var memberId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Register), new { id = memberId }, new { Id = memberId });
    }

    [HttpGet("getMembers")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Member>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Member>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllMembersQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("memberDelete/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteMemberCommand(id);

        var memberId = await _mediator.Send(command, cancellationToken);

        return Ok(memberId);
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Member>))]
    public async Task<ActionResult<List<Member>>> Search([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var query = new SearchMembersQuery(id, name);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}