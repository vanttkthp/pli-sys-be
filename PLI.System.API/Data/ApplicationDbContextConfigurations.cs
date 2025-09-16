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

            // Add any additional entity configurations here

        }
    }
}
