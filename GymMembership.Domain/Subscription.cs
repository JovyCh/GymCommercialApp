using GymMembership.Domain.Enums;

namespace GymMembership.Domain
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public decimal MonthlyCost { get; set; }
        public DateTime NextBillingDate { get; set; }
        public Guid MembershipPlanId { get; set; }
        public MembershipPlan MembershipPlan { get; set; } = null!;
        public SubscriptionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? PaymentProcessorCustomerId { get; set; }
        public string? CardBrand { get; set; }
        public string? CardLast4 { get; set; } 
    }
}
