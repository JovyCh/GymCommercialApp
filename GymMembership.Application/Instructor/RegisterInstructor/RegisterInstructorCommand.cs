using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

public record RegisterInstructorCommand(
    string Name,
    string Email,
    string Phone,
    string Address,
    DateTime DateJoined,
    string EmergencyContact,
    string EmergencyContactPhone,
    List<string> Certifications,
    string Password
) : IRequest<Guid>;

