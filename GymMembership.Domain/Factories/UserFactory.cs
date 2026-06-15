using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Domain;
using GymMembership.Domain.Enums;

public class UserFactory : IUserFactory
{
    public Admin CreateAdmin(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, AdminLevel adminLevel)
    {
        return new Admin
        {
            Name = name,
            IdentityUserId = identityUserId,
            Email = email,
            Phone = phone,
            Address = address,
            DateJoined = dateJoined,
            EmergencyContact = emergencyContact,
            EmergencyContactPhone = emergencyContactPhone,
            Level = adminLevel
        };
    }

    public Instructor CreateInstructor(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, List<string> certifications)
    {
        return new Instructor
        {
            Name = name,
            IdentityUserId = identityUserId,
            Email = email,
            Phone = phone,
            Address = address,
            DateJoined = dateJoined,
            EmergencyContact = emergencyContact,
            EmergencyContactPhone = emergencyContactPhone,
            Certifications = certifications
        };
    }

    public Member CreateMember(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, MembershipPlan membershipPlan)
    {
        return new Member
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
            Membership = membershipPlan
        };
    }
}
