using GymMembership.Domain;
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
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMembershipPlan([FromBody] CreateMembershipPlanCommand command, CancellationToken cancellationToken)
    {
        var membershipId = await _mediator.Send(command, cancellationToken);

        return CreatedAtAction(nameof(CreateMembershipPlan), new { id = membershipId });
    }

    [HttpGet("getMembershipPlan")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MembershipPlan>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<MembershipPlan>>> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllMembershipPlansQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}
