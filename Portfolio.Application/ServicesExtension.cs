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

            services.AddScoped<IBlogCategoryServices, BlogCategoryServices>();

            services.AddScoped<IBlogServices, BlogServices>();

            return services;
        }
    }
}