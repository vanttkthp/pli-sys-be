using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;

namespace PLI.System.API.Services
{
    public class AttendantService : BaseService<Attendant, AttendantViewModel>, IAttendantService
    {
        private readonly IBaseMapper<Attendant, AttendantViewModel> _attendantViewModelMapper;
        private readonly IBaseMapper<AttendantCreateViewModel, Attendant> _attendantCreateMapper;
        private readonly IAttendantRepository _attendantRepository;
        private readonly IUserContext _userContext;

        public AttendantService(
            IBaseMapper<Attendant, AttendantViewModel> attendantViewModelMapper,
            IBaseMapper<AttendantCreateViewModel, Attendant> attendantCreateMapper,
            IAttendantRepository attendantRepository)
            : base(attendantViewModelMapper, attendantRepository)
        {
            _attendantCreateMapper = attendantCreateMapper;
            _attendantViewModelMapper = attendantViewModelMapper;
            _attendantRepository = attendantRepository;
        }

        public async Task<AttendantViewModel> Create(AttendantCreateViewModel model, CancellationToken cancellationToken)
        {
            //Mapping through AutoMapper
            var entity = _attendantCreateMapper.MapModel(model);

            // Set additional properties or perform other logic as needed
            entity.EntryDate = DateTime.Now;

            return _attendantViewModelMapper.MapModel(await _attendantRepository.Create(entity, cancellationToken));
        }

    }
}
