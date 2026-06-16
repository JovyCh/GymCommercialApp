using MediatR;

public record CreateScheduledClassCommand(
    string Name,
    string Description,
    DateTime StartTime,
    int MaxCapacity,
    Guid InstructorId,
    string DifficultyLevel,
    int DurationInMinutes,
    string Room
) : IRequest<Guid>;
