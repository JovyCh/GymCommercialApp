using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using GymMembership.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Guid>
{
    private readonly IUserFactory _userFactory;
    private readonly IApplicationDbContext _context;
    public RegisterMemberCommandHandler(IApplicationDbContext context, IUserFactory userFactory)
    {
        _context = context;
        _userFactory = userFactory;
    }

    public async Task<Guid> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        var selectedPlan = await _context.MembershipPlans.FindAsync(new object[] { request.SelectedPlanId }, cancellationToken);

        if (selectedPlan == null)
        {
            throw new Exception("The selected membership plan does not exist.");
        }

        Member newMember = _userFactory.CreateMember(
            request.Name,
            request.IdentityUserId,
            request.Email,
            request.Phone,
            request.Address,
            request.EmergencyContact,
            request.EmergencyContactPhone,
            selectedPlan
        );


        _context.Members.Add(newMember);

        await _context.SaveChangesAsync(cancellationToken);

        return newMember.Id;
    }
}