using GymMembership.Domain.Enums;
using MediatR;

public record RegisterAdminCommand(
    string Name,
    string IdentityUserId,
    string Email,
    string Phone,
    string Address,
    string EmergencyContact,
    string EmergencyContactPhone,
    AdminLevel Level) 
    : IRequest<Guid>;
