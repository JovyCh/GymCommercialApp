using GymMembership.Application.Common.Interfaces;
using GymMembership.Infrastructure.Data;
using GymMembership.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;
namespace GymMembership.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, builder =>
                builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddResend(options =>
        {
            options.ApiToken = configuration["Resend:ApiKey"] ?? "";
        });
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}