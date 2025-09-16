using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Repositories;

namespace Project.Infrastructure.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}