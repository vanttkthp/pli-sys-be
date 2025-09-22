using Microsoft.EntityFrameworkCore;
using PLI.System.API.Entities.General;

namespace PLI.System.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSet Section
        // Ví dụ:
        public DbSet<User> Users { get; set; }
        public DbSet<Attendant> Attendants { get; set; }
        // public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplicationDbContextConfigurations.Configure(modelBuilder);

            // Cấu hình Fluent API
            // Ví dụ:
            // modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}
