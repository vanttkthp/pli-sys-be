﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using System.Text;

namespace PLI.System.API.Extensions
{
    public static class SecurityExtension
    {
        public static IServiceCollection RegisterSecurityService(this IServiceCollection services, IConfiguration configuration)
        {
            #region Identity
            //services.AddIdentity<User, Role>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequiredLength = 6;
            //}).AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            #endregion

            #region JWT
            //services.AddAuthentication(options =>
            //{
            //    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(jwt =>
            //{
            //    var key = Encoding.ASCII.GetBytes(configuration["AppSettings:JwtConfig:Secret"]);
            //    jwt.SaveToken = true;
            //    jwt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidAudience = configuration["AppSettings:JwtConfig:ValidAudience"],
            //        ValidIssuer = configuration["AppSettings:JwtConfig:ValidIssuer"],
            //        ValidateLifetime = true,
            //        RequireExpirationTime = true,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});
            #endregion

            return services;
        }
    }
}