using GymMembership.Domain; 
using MediatR;

public record GetAllMembersQuery : IRequest<List<Member>>;