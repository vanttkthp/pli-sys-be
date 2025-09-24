using Microsoft.EntityFrameworkCore;
using PLI.System.API.Entities.General;
using PLI.System.API.Services;

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
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplicationDbContextConfigurations.Configure(modelBuilder);

            modelBuilder.Entity<User>()
                .HasAlternateKey(u => u.Email);

            modelBuilder.Entity<UserToken>()
                .HasOne(ut => ut.User)
                .WithMany()
                .HasForeignKey(ut => ut.UserEmail)
                .HasPrincipalKey(u => u.Email);

            // Permission

            // Composite Key for UserPermission
            modelBuilder.Entity<UserPermission>()
                .HasKey(up => new { up.UserId, up.PermissionId });

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.PermissionId);
            
        }
    }
}
