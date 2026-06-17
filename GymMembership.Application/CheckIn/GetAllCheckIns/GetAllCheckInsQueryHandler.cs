using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllCheckInsQueryHandler : IRequestHandler<GetAllCheckInsQuery, List<CheckIn>>
{
    private readonly IApplicationDbContext _context;

    public GetAllCheckInsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

   public async Task<List<CheckIn>> Handle(GetAllCheckInsQuery request, CancellationToken cancellationToken)
    {
        return await _context.CheckIns.ToListAsync(cancellationToken);
    }
}
