using MediatR;

public record CreateMembershipPlanCommand(
    string Name,
    string Description,
    int Tier,
    int DurationDays,
    decimal Price
) : IRequest<Guid>;
