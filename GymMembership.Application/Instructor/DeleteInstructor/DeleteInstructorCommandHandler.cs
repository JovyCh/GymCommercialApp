using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteInstructorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = await _context.Instructors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (instructor == null)
        {
            throw new Exception($"Member with ID {request.Id} was not found.");
        }

        _context.Instructors.Remove(instructor);

        await _context.SaveChangesAsync(cancellationToken);

        return request.Id;
    }
}

