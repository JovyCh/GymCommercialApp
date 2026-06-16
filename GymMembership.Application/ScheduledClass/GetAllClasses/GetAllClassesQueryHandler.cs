using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, List<ScheduledClass>>
{
    private readonly IApplicationDbContext _context;

    public GetAllClassesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ScheduledClass>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        return await _context.ScheduledClasses.ToListAsync(cancellationToken);
    }
}
