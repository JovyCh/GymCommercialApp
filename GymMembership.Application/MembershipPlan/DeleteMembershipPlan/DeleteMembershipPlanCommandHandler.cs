using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteMembershipPlanCommandHandler : IRequestHandler<DeleteMembershipPlanCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteMembershipPlanCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Guid> Handle(DeleteMembershipPlanCommand request, CancellationToken cancellationToken)
    {
        var membershipPlan = await _context.MembershipPlans
        .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (membershipPlan == null)
        {
            throw new Exception($"membershipPlan with ID {request.Id} was not found.");
        }

        _context.MembershipPlans.Remove(membershipPlan);

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
