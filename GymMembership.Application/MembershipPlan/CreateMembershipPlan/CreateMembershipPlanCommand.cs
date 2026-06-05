using MediatR;

public record CreateMembershipPlanCommand(
    string Name,
    string Description,
    int Tier,
    int DurationMonths,
    decimal Price
) : IRequest<Guid>;
