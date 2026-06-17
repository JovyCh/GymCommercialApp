using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllInstructorsQueryHandler : IRequestHandler<GetAllInstructorsQuery, List<Instructor>>
{
    private readonly IApplicationDbContext _context;

    public GetAllInstructorsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Instructor>> Handle(GetAllInstructorsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Instructors.ToListAsync(cancellationToken);
    }
}
