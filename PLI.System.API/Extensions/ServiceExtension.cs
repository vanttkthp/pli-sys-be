using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
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
            // Register mapper first

            // Then register the service that depends on it
            #region Services
            services.AddSingleton<IUserContext, UserContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAttendantService, AttendantService>();
            //services.AddScoped<IAuthService, AuthService>();

            #endregion

            #region Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAttendantRepository, AttendantRepository>();
            //services.AddTransient<IAuthRepository, AuthRepository>();


            #endregion

            return services;
        }
    }
}