using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class CancelClassCommandHandler : IRequestHandler<CancelClassCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CancelClassCommandHandler(IApplicationDbContext context) {
        _context = context;
    }

    public async Task<Guid> Handle(CancelClassCommand request, CancellationToken cancellationToken)
    {
        var scheduledClass = await _context.ScheduledClasses
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (scheduledClass == null)
        {
            throw new KeyNotFoundException($"Scheduled class with ID {request.Id} was not found.");
        }

        scheduledClass.IsCancelled = true;

        await _context.SaveChangesAsync(cancellationToken);

        return scheduledClass.Id;
    }
}
