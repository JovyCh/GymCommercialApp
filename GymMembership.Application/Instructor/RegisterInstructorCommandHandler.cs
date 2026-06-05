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
        public RegisterInstructorCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Guid> Handle(RegisterInstructorCommand request, CancellationToken cancellationToken)
        {
            var instructorId = Guid.NewGuid();
            var newInstructor = new Instructor
            {
                Id = instructorId,
                Name = request.Name,
                IdentityUserId = request.IdentityUserId,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                EmergencyContact = request.EmergencyContact,
                EmergencyContactPhone = request.EmergencyContactPhone,
                Certifications = request.Certifications,
                DateJoined = DateTime.UtcNow
            };

            _context.Instructors.Add(newInstructor);

            await _context.SaveChangesAsync(cancellationToken);

            return instructorId;
        }
    
}
