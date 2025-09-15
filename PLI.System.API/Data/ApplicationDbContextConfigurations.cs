﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PLI.System.API.Entities.General;

namespace PLI.System.API.Data
{
    public class ApplicationDbContextConfigurations
    {
        public static void Configure(ModelBuilder builder)
        {
            // Configure custom entities
            builder.Entity<User>().ToTable("Users");

            // Configure Identity entities
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");

            // Add any additional entity configurations here

        }
    }
}
