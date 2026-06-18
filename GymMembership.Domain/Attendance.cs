using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Domain;

public class Attendance
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public Guid ScheduledClassId { get; set; }
    public ScheduledClass ScheduledClass { get; set; } = null!;
    public DateTime BookedAt { get; set; } = DateTime.Now;
    public bool Attended { get; set; } = false;
    public bool IsCancelled { get; set; } = false;
}
