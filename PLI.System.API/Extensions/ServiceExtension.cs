using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Repositories;
using PLI.System.API.Services;

namespace PLI.System.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddSingleton<IUserContext, UserContext>();
            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            #endregion

            return services;
        }
    }
}