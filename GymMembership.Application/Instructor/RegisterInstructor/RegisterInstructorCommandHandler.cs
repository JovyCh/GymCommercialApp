using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Common.Interfaces;
using GymMembership.Domain;
using MediatR;

public class RegisterInstructorCommandHandler : IRequestHandler<RegisterInstructorCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserFactory _userFactory;
    private readonly IIdentityService _identityService;
    public RegisterInstructorCommandHandler(IApplicationDbContext context, IUserFactory userFactory, IIdentityService identityService) 
    {
        _context = context;
        _userFactory = userFactory;
        _identityService = identityService;
    }

    public async Task<Guid> Handle(RegisterInstructorCommand request, CancellationToken cancellationToken)
    {
        string identityUserId = await _identityService.CreateUserAsync(request.Email, request.Password);
        var instructorId = Guid.NewGuid();
        var newInstructor = _userFactory.CreateInstructor(
            
            request.Name,
            identityUserId,
            request.Email,
            request.Phone,
            request.Address,
            request.EmergencyContact,
            request.EmergencyContactPhone,
            request.Certifications
        );

        _context.Instructors.Add(newInstructor);

        await _context.SaveChangesAsync(cancellationToken);

        return instructorId;
    }
    
}
