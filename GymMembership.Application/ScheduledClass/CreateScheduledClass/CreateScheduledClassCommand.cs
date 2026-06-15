using MediatR;

public record CreateScheduledClassCommand(
    string Name,
    string Description,
    string Room,
    int DurationInMinutes,
    DateTime StartTime,
    int MaxCapacity,
    Guid InstructorId
) : IRequest<Guid>;
