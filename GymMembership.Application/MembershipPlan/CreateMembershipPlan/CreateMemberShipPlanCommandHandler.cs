using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using GymMembership.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreateMemberShipPlanCommandHandler : IRequestHandler<CreateMembershipPlanCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateMemberShipPlanCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateMembershipPlanCommand request, CancellationToken cancellationToken)
    {
        var membershipID = Guid.NewGuid();
        var newMembershipPlan = new MembershipPlan
        {
            Description = request.Description,
            Id = membershipID,
            DurationDays = request.DurationDays,
            Name = request.Name,
            Price = request.Price,
            Tier = request.Tier,
            IsRecurring = request.IsRecurring
        };

        _context.MembershipPlans.Add(newMembershipPlan);

        await _context.SaveChangesAsync(cancellationToken);

        return membershipID;
    }
}
