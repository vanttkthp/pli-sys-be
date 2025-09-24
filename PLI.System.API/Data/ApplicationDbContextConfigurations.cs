using Microsoft.AspNetCore.Identity;
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
            builder.Entity<UserToken>().ToTable("UserToken");
            builder.Entity<Permission>().ToTable("Permission");
            builder.Entity<UserPermission>().ToTable("UserPermission");
            builder.Entity<Attendant>().ToTable("Attendants");

            // Add any additional entity configurations here

        }
    }
}
