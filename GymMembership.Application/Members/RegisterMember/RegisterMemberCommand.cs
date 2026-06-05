using MediatR;

public record RegisterMemberCommand(
    string Name,
    string IdentityUserId,
    string Email,
    string Phone,
    string Address,
    string EmergencyContact,
    string EmergencyContactPhone,
    Guid SelectedPlanId
) : IRequest<Guid>;
