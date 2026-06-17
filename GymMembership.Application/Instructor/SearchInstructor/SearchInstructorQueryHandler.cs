using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class SearchInstructorQueryHandler : IRequestHandler<SearchInstructorQuery, List<Instructor>?>
{
    private readonly IApplicationDbContext _context;

    public SearchInstructorQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Instructor>?> Handle(SearchInstructorQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Instructors.AsQueryable();

        if (request.Id.HasValue)
        {
            query = query.Where(i => i.Id == request.Id.Value);
        }
        else if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(i => i.Name.Contains(request.Name));
        }
        else
        {
            return null;
        }

        return await query.ToListAsync(cancellationToken);
    }
}
