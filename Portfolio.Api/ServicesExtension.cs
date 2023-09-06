using Portfolio.Api.Middleawares;
using System.Reflection;

namespace Portfolio.Api
{
    public static class ServicesExtension
    {
        public static IServiceCollection ApiServices(this IServiceCollection services)
        {
            services.AddLogging();

            services.AddTransient<GlobalErrorHandlerMiddleware>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
