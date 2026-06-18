namespace GymMembership.Domain
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IdentityUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; } = DateTime.MinValue;
        public string EmergencyContact { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public Subscription CurrentSubscription { get; set; } = null!;
        public ICollection<ScheduledClass> BookedClasses { get; set; } = new List<ScheduledClass>();
        public ICollection<Attendance> ClassAttendances { get; set; } = new List<Attendance>();
    }
}
