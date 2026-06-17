using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class SearchMemberQueryHandler : IRequestHandler<SearchMembersQuery, List<Member>?>
{
    private readonly IApplicationDbContext _context;

    public SearchMemberQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> Handle(SearchMembersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Members.AsQueryable();

        if (request.Id.HasValue)
        {
            query = query.Where(m => m.Id == request.Id.Value);
        }
        else if (!string.IsNullOrWhiteSpace(request.Name))
        {
            query = query.Where(m => m.Name.Contains(request.Name));
        }

        return await query.ToListAsync(cancellationToken);
    }
}