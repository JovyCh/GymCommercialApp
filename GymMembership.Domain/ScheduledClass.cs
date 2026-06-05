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
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public int MaxCapacity { get; set; } = 0;
        public List<Member> Members { get; set; } = new();
        public int AppliedMembers => Members.Count;
        public Guid InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
    }
}   
