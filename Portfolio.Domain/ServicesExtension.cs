using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Domain
{
    public static class ServicesExtension
    {
        public static IServiceCollection DomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}