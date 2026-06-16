using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using GymMembership.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class RegisterAdminCommandHandler : IRequestHandler<RegisterAdminCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserFactory _userFactory;
    public RegisterAdminCommandHandler(IApplicationDbContext context, IUserFactory userFactory)
    {
        _context = context;
        _userFactory = userFactory;
    }

    public async Task<Guid> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
    {

        var newAdmin = _userFactory.CreateAdmin(
            request.Name,
            request.IdentityUserId,
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
