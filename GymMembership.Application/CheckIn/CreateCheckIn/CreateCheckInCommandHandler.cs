using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using MediatR;

public class CreateCheckInCommandHandler : IRequestHandler<CreateCheckInCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCheckInCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCheckInCommand request, CancellationToken cancellationToken)
    {
        var checkInID = Guid.NewGuid();
        var newCheckIn = new CheckIn
        {
            LoggedAt = DateTime.UtcNow,
            Id = checkInID,
            MemberId = request.MemberId
        };

        _context.CheckIns.Add(newCheckIn);

        await _context.SaveChangesAsync(cancellationToken);

        return checkInID;
    }
}
