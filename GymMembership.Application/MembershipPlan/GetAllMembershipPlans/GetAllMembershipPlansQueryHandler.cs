using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllMembershipPlansQueryHandler : IRequestHandler<GetAllMembershipPlansQuery, List<MembershipPlan>>
{
    private readonly IApplicationDbContext _context;

    public GetAllMembershipPlansQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MembershipPlan>> Handle(GetAllMembershipPlansQuery request, CancellationToken cancellationToken)
    {
        return await _context.MembershipPlans.ToListAsync(cancellationToken);
    }
}
