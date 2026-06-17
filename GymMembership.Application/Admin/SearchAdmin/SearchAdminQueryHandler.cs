using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class SearchAdminQueryHandler : IRequestHandler<SearchAdminQuery, List<Admin>?>
{
    private readonly IApplicationDbContext _context;

    public SearchAdminQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Admin>?> Handle(SearchAdminQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Admins.AsQueryable();

        if (request.Id.HasValue)
        {
            query = query.Where(a => a.Id == request.Id.Value);
        }
        else if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(a => a.Name.Contains(request.Name));
        }
        else
        {
            return null;
        }

        return await query.ToListAsync(cancellationToken);
    }
}
