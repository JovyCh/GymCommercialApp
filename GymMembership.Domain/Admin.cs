using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Domain
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IdentityUserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; } = DateTime.MinValue;
        public string EmergencyContact { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public MembershipPlan Membership = new MembershipPlan();
    }
}
