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
                //cfg.CreateMap<Product, ProductViewModel>();
                //cfg.CreateMap<ProductCreateViewModel, Product>();
                //cfg.CreateMap<ProductUpdateViewModel, Product>();

                //cfg.CreateMap<Role, RoleViewModel>();
                //cfg.CreateMap<RoleCreateViewModel, Role>();

                //cfg.CreateMap<User, UserViewModel>();
                //cfg.CreateMap<UserViewModel, User>();

                cfg.CreateMap<Attendant, AttendantViewModel>();
                cfg.CreateMap<AttendantViewModel, Attendant>();
                cfg.CreateMap<AttendantCreateViewModel, Attendant>();

            }).CreateMapper());

            // Register the IMapperService implementation with your dependency injection container
            //services.AddSingleton<IBaseMapper<Product, ProductViewModel>, BaseMapper<Product, ProductViewModel>>();
            //services.AddSingleton<IBaseMapper<ProductCreateViewModel, Product>, BaseMapper<ProductCreateViewModel, Product>>();
            //services.AddSingleton<IBaseMapper<ProductUpdateViewModel, Product>, BaseMapper<ProductUpdateViewModel, Product>>();

            //services.AddSingleton<IBaseMapper<Role, RoleViewModel>, BaseMapper<Role, RoleViewModel>>();
            //services.AddSingleton<IBaseMapper<RoleCreateViewModel, Role>, BaseMapper<RoleCreateViewModel, Role>>();

            //services.AddSingleton<IBaseMapper<User, UserViewModel>, BaseMapper<User, UserViewModel>>();
            //services.AddSingleton<IBaseMapper<UserViewModel, User>, BaseMapper<UserViewModel, User>>();

            services.AddSingleton<IBaseMapper<Attendant, AttendantViewModel>, BaseMapper<Attendant, AttendantViewModel>>();
            services.AddSingleton<IBaseMapper<AttendantViewModel, Attendant>, BaseMapper<AttendantViewModel, Attendant>>();
            services.AddSingleton<IBaseMapper<AttendantCreateViewModel, Attendant>, BaseMapper<AttendantCreateViewModel, Attendant>>();

            #endregion

            return services;
        }
    }
}