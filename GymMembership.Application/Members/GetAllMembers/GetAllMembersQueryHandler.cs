using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, List<Member>>
{
    private readonly IApplicationDbContext _context;

    public GetAllMembersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
    {
        return await _context.Members.ToListAsync(cancellationToken);
    }
}