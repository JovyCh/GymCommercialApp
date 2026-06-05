using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Domain
{
    public class CheckIn
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}
