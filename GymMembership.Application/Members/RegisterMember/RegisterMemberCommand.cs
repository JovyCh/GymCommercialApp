using MediatR;

public record RegisterMemberCommand(
    string Name,
    string Email,
    string Phone,
    string Address,
    string EmergencyContact,
    string EmergencyContactPhone,
    Guid SelectedPlanId,
    string Password
) : IRequest<Guid>;
