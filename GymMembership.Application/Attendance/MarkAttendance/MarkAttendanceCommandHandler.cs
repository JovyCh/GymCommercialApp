using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class MarkAttendanceCommandHandler : IRequestHandler<MarkAttendanceCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<MarkAttendanceCommandHandler> _logger;
    public MarkAttendanceCommandHandler(IApplicationDbContext context, ILogger<MarkAttendanceCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> Handle(MarkAttendanceCommand request, CancellationToken cancellationToken)
    {
        var attendance = await _context.Attendances
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (attendance == null)
        {
            _logger.LogWarning($"Attendance with ID {request.Id} was not found.");
            throw new KeyNotFoundException($"Attendance with ID {request.Id} was not found.");
        }

        attendance.Attended = true;

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
