using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class AdminController : ControllerBase
{
    private readonly ISender _mediator;

    public AdminController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("adminRegister")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterAdminCommand command, CancellationToken cancellationToken)
    {
        var adminId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Register), new { id = adminId });
    }
    [HttpGet("getAdmins")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Admin>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<Admin>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllAdminsQuery();

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
    [HttpDelete("instructorAdmin/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteAdminCommand(id);

        var adminId = await _mediator.Send(command, cancellationToken);

        return Ok(adminId);
    }

    [HttpGet("searchAdmin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Admin>))]
    public async Task<ActionResult<List<Admin>>> Search([FromQuery] Guid? id, [FromQuery] string? name, CancellationToken cancellationToken)
    {
        var query = new SearchAdminQuery(id, name);

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
