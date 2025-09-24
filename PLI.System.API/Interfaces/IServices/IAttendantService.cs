using PLI.System.API.Entities.Business;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IAttendantService : IBaseService<AttendantViewModel>
    {
        Task<AttendantViewModel> Create(AttendantCreateViewModel model, CancellationToken cancellationToken);
        Task<List<AttendantViewModel>> CreateMany(List<AttendantCreateViewModel> models, CancellationToken cancellationToken);
        Task<IEnumerable<AttendantViewModel>> GetAllByTeamId(Guid teamId, CancellationToken cancellation);
    }
}
