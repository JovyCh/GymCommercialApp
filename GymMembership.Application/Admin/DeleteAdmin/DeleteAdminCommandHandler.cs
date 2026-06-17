using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public DeleteAdminCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (admin == null)
        {
            throw new Exception($"Admin with ID {request.Id} was not found.");
        }

        var identityUserId = admin.IdentityUserId;

        _context.Admins.Remove(admin);

        await _context.SaveChangesAsync(cancellationToken);

        if (!string.IsNullOrEmpty(identityUserId))
        {
            await _identityService.DeleteUserAsync(identityUserId);
        }
        return request.Id;
    }
}
