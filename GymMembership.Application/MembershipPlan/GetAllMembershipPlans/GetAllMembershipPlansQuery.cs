using GymMembership.Domain;
using MediatR;

public record GetAllMembershipPlansQuery : IRequest<List<MembershipPlan>>;
