using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Guid>
{
    private readonly IUserFactory _userFactory;
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IEmailService _emailService;
    private readonly IConfiguration _configuration;
    public RegisterMemberCommandHandler(IApplicationDbContext context, IUserFactory userFactory, IIdentityService identityService, IEmailService emailService, IConfiguration configuration)
    {
        _context = context;
        _userFactory = userFactory;
        _identityService = identityService;
        _emailService = emailService;
        _configuration = configuration;
    }

    public async Task<Guid> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
    {
        var selectedPlan = await _context.MembershipPlans.FindAsync(new object[] { request.SelectedPlanId }, cancellationToken);

        if (selectedPlan == null)
        {
            throw new Exception("The selected membership plan does not exist.");
        }
        bool emailSent = await _emailService.SendEmail(_configuration["Emails:Main"] ?? "");
        if (!emailSent)
        {
            throw new Exception($"Could not send welcome email to {request.Email}");
        }
        string identityUserId = await _identityService.CreateUserAsync(request.Email, request.Password);

        Member newMember = _userFactory.CreateMember(
            request.Name,
            identityUserId,
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