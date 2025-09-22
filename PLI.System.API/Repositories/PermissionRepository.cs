using Microsoft.EntityFrameworkCore;
using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;

namespace PLI.System.API.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _db;
        public PermissionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        => await _db.Permissions.ToListAsync();

        public async Task<Permission?> GetByIdAsync(int id)
            => await _db.Permissions.FindAsync(id);

        public async Task AddAsync(Permission permission)
        {
            _db.Permissions.Add(permission);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Permission permission)
        {
            _db.Permissions.Update(permission);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Permission permission)
        {
            _db.Permissions.Remove(permission);
            await _db.SaveChangesAsync();
        }
    }
}
