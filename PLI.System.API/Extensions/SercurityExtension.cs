using AutoMapper;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Mapper;

namespace PLI.System.API.Extensions
{
    public static class MapperExtension
    {
        public static IServiceCollection RegisterMapperService(this IServiceCollection services)
        {

            #region Mapper

            services.AddSingleton<IMapper>(sp => new MapperConfiguration(cfg =>
            {


                cfg.CreateMap<Role, RoleViewModel>();
                cfg.CreateMap<RoleCreateViewModel, Role>();
                cfg.CreateMap<RoleUpdateViewModel, Role>();

                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();

            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container

            services.AddSingleton<IBaseMapper<Role, RoleViewModel>, BaseMapper<Role, RoleViewModel>>();
            services.AddSingleton<IBaseMapper<RoleCreateViewModel, Role>, BaseMapper<RoleCreateViewModel, Role>>();
            services.AddSingleton<IBaseMapper<RoleUpdateViewModel, Role>, BaseMapper<RoleUpdateViewModel, Role>>();

            services.AddSingleton<IBaseMapper<User, UserViewModel>, BaseMapper<User, UserViewModel>>();
            services.AddSingleton<IBaseMapper<UserViewModel, User>, BaseMapper<UserViewModel, User>>();

            #endregion

            return services;
        }
    }
}