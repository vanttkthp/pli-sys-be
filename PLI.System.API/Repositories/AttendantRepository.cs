using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;

namespace PLI.System.API.Repositories
{
    public class AttendantRepository : BaseRepository<Attendant>, IAttendantRepository
    {
        public AttendantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}