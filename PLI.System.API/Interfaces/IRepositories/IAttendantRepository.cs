using PLI.System.API.Entities.General;

namespace PLI.System.API.Interfaces.IRepositories
{
    public interface IAttendantRepository : IBaseRepository<Attendant>
    {
        // 🚀 New method for bulk creation
        Task<List<Attendant>> CreateMany(List<Attendant> entities, CancellationToken cancellationToken);
        Task<IEnumerable<Attendant>> GetAllByTeamId(Guid teamId, CancellationToken cancellationToken); 
    }
}
