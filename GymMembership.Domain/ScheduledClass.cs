using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Domain
{
    public class ScheduledClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Room { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public int MaxCapacity { get; set; } = 0;
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public int AppliedMembers => Attendances?.Count(a => !a.IsCancelled) ?? 0;
        public Guid? InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public bool IsCancelled { get; set; } = false;
        public string DifficultyLevel { get; set; } = "All Levels";
        public int DurationInMinutes { get; set; }
    }
}   
