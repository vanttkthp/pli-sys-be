using PLI.System.API.Entities.Business;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IAttendantService : IBaseService<AttendantViewModel>
    {
        Task<AttendantViewModel> Create(AttendantCreateViewModel model, CancellationToken cancellationToken);
    }
}
