using Microsoft.EntityFrameworkCore;
using GymMembership.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GymMembership.Application.Common.Interfaces;

namespace GymMembership.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<Member> Members => Set<Member>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<CheckIn> CheckIns => Set<CheckIn>();
    public DbSet<MembershipPlan> MembershipPlans => Set<MembershipPlan>();
    public DbSet<ScheduledClass> ScheduledClasses => Set<ScheduledClass>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();
    public DbSet<PaymentLog> PaymentLogs => Set<PaymentLog>();
    public DbSet<Attendance> Attendances => Set<Attendance>();


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.Entity<ScheduledClass>().Ignore(c => c.AppliedMembers);
        modelBuilder.Entity<Attendance>().ToTable("Attendances");
    }
}