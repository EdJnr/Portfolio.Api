using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Interfaces.Services;
using Portfolio.Application.Services;

namespace Portfolio.Application
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectServices, ProjectServices>();

            services.AddScoped<IPersonalDataServices, PersonalDataServices>();

            return services;
        }
    }
}