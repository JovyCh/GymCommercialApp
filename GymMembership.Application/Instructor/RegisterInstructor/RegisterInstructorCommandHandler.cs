using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using MediatR;

    public class RegisterInstructorCommandHandler : IRequestHandler<RegisterInstructorCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUserFactory _userFactory;
        public RegisterInstructorCommandHandler(IApplicationDbContext context, IUserFactory userFactory) {
            _context = context;
            _userFactory = userFactory;
        }

        public async Task<Guid> Handle(RegisterInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructorId = Guid.NewGuid();
            var newInstructor = _userFactory.CreateInstructor(
            
                request.Name,
                request.IdentityUserId,
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
