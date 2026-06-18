using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

public record CreateAttendanceCommand(Guid MemberId, Guid ScheduledClassId) : IRequest<Guid>;
