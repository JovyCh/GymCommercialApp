using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class CancelledAttendanceCommandHandler : IRequestHandler<CancelClassCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CancelledAttendanceCommandHandler> _logger;
    public CancelledAttendanceCommandHandler(IApplicationDbContext context, ILogger<CancelledAttendanceCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> Handle(CancelClassCommand request, CancellationToken cancellationToken)
    {
        var attendance = await _context.Attendances
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (attendance == null)
        {
            _logger.LogWarning($"Attendance with ID {request.Id} was not found.");
            throw new KeyNotFoundException($"Attendance with ID {request.Id} was not found.");
        }

        attendance.IsCancelled = true;

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
