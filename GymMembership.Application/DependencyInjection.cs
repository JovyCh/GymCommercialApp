using Microsoft.Extensions.DependencyInjection;

namespace GymMembership.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

            return services;
        }
    }
}
