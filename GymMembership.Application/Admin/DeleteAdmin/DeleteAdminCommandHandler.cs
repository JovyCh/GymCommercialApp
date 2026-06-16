using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteAdminCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (admin == null)
        {
            throw new Exception($"Admin with ID {request.Id} was not found.");
        }

        _context.Admins.Remove(admin);

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
