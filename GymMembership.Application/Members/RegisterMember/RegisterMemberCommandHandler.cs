using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using GymMembership.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public RegisterMemberCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        var plan = await _context.MembershipPlans
            .FirstOrDefaultAsync(p => p.Id == request.SelectedPlanId, cancellationToken);

        if (plan == null)
        {
            throw new Exception("The selected membership plan does not exist.");
        }

        var memberId = Guid.NewGuid();
        var newMember = new Member
        {
            Id = memberId,
            Name = request.Name,
            IdentityUserId = request.IdentityUserId,
            Email = request.Email,
            Phone = request.Phone,
            Address = request.Address,
            EmergencyContact = request.EmergencyContact,
            EmergencyContactPhone = request.EmergencyContactPhone,
            DateJoined = DateTime.UtcNow
        };

        var subscription = new Subscription
        {
            Id = Guid.NewGuid(),
            MemberId = memberId,
            MembershipPlanId = plan.Id,
            MonthlyCost = plan.Price,
            NextBillingDate = DateTime.UtcNow.AddMonths(plan.DurationMonths),
            Status = SubscriptionStatus.Active
        };

        _context.Members.Add(newMember);
        _context.Subscriptions.Add(subscription);

        await _context.SaveChangesAsync(cancellationToken);

        return memberId;
    }
}