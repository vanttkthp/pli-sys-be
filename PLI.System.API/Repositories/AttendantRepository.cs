using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace PLI.System.API.Repositories
{
    public class AttendantRepository : BaseRepository<Attendant>, IAttendantRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AttendantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // 🚀 Bulk create implementation
        public async Task<List<Attendant>> CreateMany(List<Attendant> entities, CancellationToken cancellationToken)
        {
            if (entities == null || entities.Count == 0)
                return new List<Attendant>();

            await _dbContext.Attendants.AddRangeAsync(entities, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entities;
        }

        public async Task<IEnumerable<Attendant>> GetAllByTeamId(Guid teamId, CancellationToken cancellationToken)
        {
            return await _dbContext.Attendants
                .Where(a => a.TeamId == teamId)
                .ToListAsync(cancellationToken);
        }
    }
}
