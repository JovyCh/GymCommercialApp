using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteClassCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        var scheduledClass = await _context.ScheduledClasses
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (scheduledClass == null)
        {
            throw new Exception($"scheduledClass with ID {request.Id} was not found.");
        }

        _context.ScheduledClasses.Remove(scheduledClass);

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
