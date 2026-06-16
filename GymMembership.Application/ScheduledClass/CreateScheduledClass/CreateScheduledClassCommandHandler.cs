using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Application.Interfaces;
using GymMembership.Domain;
using MediatR;

public class CreateScheduledClassCommandHandler : IRequestHandler<CreateScheduledClassCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateScheduledClassCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateScheduledClassCommand request, CancellationToken cancellationToken)
    {
        Guid classId = Guid.NewGuid();
        ScheduledClass newClass = new ScheduledClassBuilder(
            classId,
            request.Name,
            request.Room,
            request.StartTime,
            request.DurationInMinutes)
            .WithInstructor(request.InstructorId)   
            .WithMaxCapacity(request.MaxCapacity)   
            .ForDifficultyLevel(request.DifficultyLevel)
            .Build();                               

        _context.ScheduledClasses.Add(newClass);

        await _context.SaveChangesAsync(cancellationToken);

        return classId;
    }
}
