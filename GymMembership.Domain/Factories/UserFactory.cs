using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Domain;
using GymMembership.Domain.Enums;

public class UserFactory : IUserFactory
{
    public Admin CreateAdmin(string name, string identityUserId, string email, string phone, string address, string emergencyContact, string emergencyContactPhone, AdminLevel adminLevel)
    {
        return new Admin
        {
            Id = Guid.NewGuid(),
            Name = name,
            IdentityUserId = identityUserId,
            Email = email,
            Phone = phone,
            Address = address,
            DateJoined = DateTime.UtcNow,
            EmergencyContact = emergencyContact,
            EmergencyContactPhone = emergencyContactPhone,
            Level = adminLevel
        };
    }

    public Instructor CreateInstructor(string name, string identityUserId, string email, string phone, string address, string emergencyContact, string emergencyContactPhone, List<string> certifications)
    {
        return new Instructor
        {
            Id = Guid.NewGuid(),
            Name = name,
            IdentityUserId = identityUserId,
            Email = email,
            Phone = phone,
            Address = address,
            DateJoined = DateTime.UtcNow,
            EmergencyContact = emergencyContact,
            EmergencyContactPhone = emergencyContactPhone,
            Certifications = certifications
        };
    }

    public Member CreateMember(string name, string identityUserId, string email, string phone, string address, string emergencyContact, string emergencyContactPhone, MembershipPlan plan)
    {
        var memberId = Guid.NewGuid();
        var subscriptionId = Guid.NewGuid();
        var rightNow = DateTime.UtcNow;

        var member = new Member
        {
            Id = Guid.NewGuid(),
            Name = name,
            IdentityUserId = identityUserId,
            Email = email,
            Phone = phone,
            Address = address,
            DateJoined = DateTime.UtcNow,
            EmergencyContact = emergencyContact,
            EmergencyContactPhone = emergencyContactPhone
        };
        var subscription = new Subscription
        {
            Id = subscriptionId,
            MemberId = memberId,            
            MembershipPlanId = plan.Id,       
            MonthlyCost = plan.Price,         
            NextBillingDate = rightNow.AddMonths(1),
            Status = SubscriptionStatus.Active,
            CreatedAt = rightNow,
            StartDate = rightNow,
            EndDate = rightNow.AddMonths(1),
            IsRecurring = plan.IsRecurring
        };
        member.CurrentSubscription = subscription;

        return member;
    }
}
