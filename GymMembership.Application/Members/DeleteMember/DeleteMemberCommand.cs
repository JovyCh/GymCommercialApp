using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

public record DeleteMemberCommand(Guid Id) : IRequest<Guid>;
