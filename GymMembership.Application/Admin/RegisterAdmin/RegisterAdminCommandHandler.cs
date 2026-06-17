using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using GymMembership.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


public class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserFactory _userFactory;
    private readonly IIdentityService _identityService;
    public RegisterAdminCommandHandler(IApplicationDbContext context, IUserFactory userFactory, IIdentityService identityService)
    {
        _context = context;
        _userFactory = userFactory;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
    {
        string identityUserId = await _identityService.CreateUserAsync(request.Email, request.Password);

        var newAdmin = _userFactory.CreateAdmin(
            request.Name,
            identityUserId,
            request.Email,
            request.Phone,
            request.Address,
            request.EmergencyContact,
            request.EmergencyContactPhone,
            request.Level
        );

        _context.Admins.Add(newAdmin);

        await _context.SaveChangesAsync(cancellationToken);

        return newAdmin.Id;
    }
}
