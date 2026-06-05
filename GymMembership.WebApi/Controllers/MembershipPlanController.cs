using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MembershipPlanController : ControllerBase
{
    private readonly ISender _mediator;

    public MembershipPlanController(ISender mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("AdminCreateMembershipPlan")]
    public async Task<IActionResult> CreateMembershipPlan([FromBody] CreateMembershipPlanCommand command, CancellationToken cancellationToken)
    {
        var membershipId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateMembershipPlan), new { id = membershipId });
    }
}
