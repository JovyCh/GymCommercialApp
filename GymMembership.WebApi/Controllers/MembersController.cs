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
    public async Task<IActionResult> Register([FromBody] RegisterMemberCommand command, CancellationToken cancellationToken)
    {
        var memberId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(Register), new { id = memberId }, new { Id = memberId });
    }
}