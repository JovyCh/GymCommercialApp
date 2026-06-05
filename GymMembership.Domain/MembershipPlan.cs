using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMembership.Domain
{
    public class MembershipPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Tier { get; set; } = 0;
        public int DurationMonths { get; set; }
        public decimal Price { get; set; }
    }
}
