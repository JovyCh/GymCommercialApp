using GymMembership.Domain;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Member> Members { get; }
        DbSet<Instructor> Instructors { get; }
        DbSet<Admin> Admins { get; }
        DbSet<CheckIn> CheckIns { get; }
        DbSet<MembershipPlan> MembershipPlans { get; }
        DbSet<ScheduledClass> ScheduledClasses { get; }
        DbSet<Subscription> Subscriptions { get; }
        DbSet<PaymentLog> PaymentLogs { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
