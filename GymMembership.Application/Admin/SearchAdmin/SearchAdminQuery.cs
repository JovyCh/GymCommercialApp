using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Domain;
using MediatR;

public record SearchAdminQuery(Guid? Id, string? Name) : IRequest<List<Admin>?>;
