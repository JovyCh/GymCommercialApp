using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery ,List<Admin>?>
{
    private readonly IApplicationDbContext _context;

    public GetAllAdminsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Admin>?> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Admins.ToListAsync();
    }
}
