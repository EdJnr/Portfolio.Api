using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.Infrastructure
{
    public static class ServicesExtension
    {
        public static IServiceCollection InfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}