using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    
    public CreateAttendanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
    {
        var scheduledClass = await _context.ScheduledClasses
            .Include(c => c.Attendances)
            .FirstOrDefaultAsync(c => c.Id == request.ScheduledClassId, cancellationToken);

        if (scheduledClass == null)
        {
            throw new Exception("The selected class does not exist.");
        }

        if (scheduledClass.AppliedMembers >= scheduledClass.MaxCapacity)
        {
            throw new Exception("The class is full.");

        }
        else if (scheduledClass.StartTime < DateTime.UtcNow)
        {
            throw new Exception("Class has already passed!");
        }

        Guid AttendId = Guid.NewGuid();

        Attendance newAttendance = new Attendance 
        { 
            Id = AttendId,
            MemberId = request.MemberId,
            ScheduledClassId = request.ScheduledClassId
        };

        await _context.Attendances.AddAsync(newAttendance);

        await _context.SaveChangesAsync(cancellationToken);

        return AttendId;
    }
}
