using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public DeleteInstructorCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = await _context.Instructors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (instructor == null)
        {
            throw new Exception($"Member with ID {request.Id} was not found.");
        }

        string identityUserId = instructor.IdentityUserId;

        _context.Instructors.Remove(instructor);

        await _context.SaveChangesAsync(cancellationToken);

        if (!string.IsNullOrEmpty(identityUserId))
        {
            await _identityService.DeleteUserAsync(identityUserId);
        }

        return request.Id;
    }
}

