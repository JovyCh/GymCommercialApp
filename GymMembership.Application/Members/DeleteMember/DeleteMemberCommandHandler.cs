using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteMemberCommandHandler(IApplicationDbContext context)
    {
    _context = context;
    }

    public async Task<Guid> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _context.Members
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (member == null)
        {
            throw new Exception($"Member with ID {request.Id} was not found.");
        }

        _context.Members.Remove(member);

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}
