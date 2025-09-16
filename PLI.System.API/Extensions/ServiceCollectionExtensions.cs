using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Services;

namespace PLI.System.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            // Add other auth-related services here
            return services;
        }
    }
}
