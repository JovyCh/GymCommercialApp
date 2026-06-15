using GymMembership.Domain;

public class ScheduledClassBuilder
{
    private readonly Guid _id;
    private readonly string _name;
    private readonly DateTime _startTime;
    private readonly string _room;
    private readonly int _durationInMinutes;

    private Guid? _instructorId = null;
    private int _maxCapacity = 20;
    private string _difficultyLevel = "All Levels";

    public ScheduledClassBuilder(Guid id, string name, string roomName, DateTime startTime, int durationInMinutes)
    {
        _id = id;
        _name = name;
        _room = roomName;
        _startTime = startTime;
        _durationInMinutes = durationInMinutes;
    }
    public ScheduledClassBuilder WithInstructor(Guid instructorId)
    {
        _instructorId = instructorId;
        return this;
    }

    public ScheduledClassBuilder WithMaxCapacity(int capacity)
    {
        _maxCapacity = capacity;
        return this;
    }

    public ScheduledClassBuilder ForDifficultyLevel(string level)
    {
        _difficultyLevel = level;
        return this;
    }
    public ScheduledClass Build()
    {
        if (_maxCapacity <= 0)
            throw new InvalidOperationException("Class capacity must be greater than zero.");

        return new ScheduledClass
        {
            Id = _id,
            Name = _name,
            Room = _room,
            StartTime = _startTime,
            DurationInMinutes = _durationInMinutes,
            InstructorId = _instructorId,
            MaxCapacity = _maxCapacity,
            DifficultyLevel = _difficultyLevel
        };
    }
}
