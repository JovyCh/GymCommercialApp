using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class SearchClassesQueryHandler : IRequestHandler<SearchClassesQuery, List<ScheduledClass>>
{
    private readonly IApplicationDbContext _context;

    public SearchClassesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ScheduledClass>> Handle(SearchClassesQuery request, CancellationToken cancellationToken)
    {

        var query = _context.ScheduledClasses.AsQueryable();

        if (request.Id.HasValue)
        {
            query = query.Where(s => s.Id == request.Id.Value);
        }
        else if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(s => s.Name.Contains(request.Name));
        }

        return await query.ToListAsync(cancellationToken);
    }
}
