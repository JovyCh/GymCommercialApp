using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.Domain;
using GymMembership.Domain.Enums;

public interface IUserFactory
{
    Member CreateMember(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, MembershipPlan membershipPlan);
    Instructor CreateInstructor(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, List<string> certifications);
    Admin CreateAdmin(string name, string identityUserId, string email, string phone, string address, DateTime dateJoined, string emergencyContact, string emergencyContactPhone, AdminLevel adminLevel);
}