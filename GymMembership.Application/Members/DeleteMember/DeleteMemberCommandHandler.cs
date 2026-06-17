using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public DeleteMemberCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _context.Members
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (member == null)
        {
            throw new Exception($"Member with ID {request.Id} was not found.");
        }

        string identityUserId = member.IdentityUserId;

        _context.Members.Remove(member);

        await _context.SaveChangesAsync(cancellationToken);

        if (!string.IsNullOrEmpty(identityUserId))
        {
            await _identityService.DeleteUserAsync(identityUserId);
        }

        return request.Id;
    }
}
