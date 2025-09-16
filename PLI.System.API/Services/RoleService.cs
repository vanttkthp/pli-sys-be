﻿using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Services;
using PLI.System.Core.Services;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;

namespace Project.Core.Services
{
    public class RoleService : BaseService<Role, RoleViewModel>, IRoleService
    {
        private readonly IBaseMapper<Role, RoleViewModel> _roleViewModelMapper;
        private readonly IBaseMapper<RoleCreateViewModel, Role> _roleCreateMapper;
        private readonly IBaseMapper<RoleUpdateViewModel, Role> _roleUpdateMapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserContext _userContext;

        public RoleService(
            IBaseMapper<Role, RoleViewModel> roleViewModelMapper,
            IBaseMapper<RoleCreateViewModel, Role> roleCreateMapper,
            IBaseMapper<RoleUpdateViewModel, Role> roleUpdateMapper,
            IRoleRepository roleRepository,
            IUserContext userContext)
            : base(roleViewModelMapper, roleRepository)
        {
            _roleCreateMapper = roleCreateMapper;
            _roleUpdateMapper = roleUpdateMapper;
            _roleViewModelMapper = roleViewModelMapper;
            _roleRepository = roleRepository;
            _userContext = userContext;
        }

        public async Task<RoleViewModel> Create(RoleCreateViewModel model, CancellationToken cancellationToken)
        {
            //Mapping through AutoMapper
            var entity = _roleCreateMapper.MapModel(model);

            // Set additional properties or perform other logic as needed
            //entity.NormalizedName = model.Name.ToUpper();
            entity.EntryDate = DateTime.Now;
            entity.EntryBy = Convert.ToInt32(_userContext.UserId);

            return _roleViewModelMapper.MapModel(await _roleRepository.Create(entity, cancellationToken));
        }

        public async Task Update(RoleUpdateViewModel model, CancellationToken cancellationToken)
        {
            var existingData = await _roleRepository.GetById(model.Id, cancellationToken);

            //Mapping through AutoMapper
            _roleUpdateMapper.MapModel(model, existingData);

            // Set additional properties or perform other logic as needed
            existingData.UpdatedDate = DateTime.Now;
            existingData.UpdatedBy = Convert.ToInt32(_userContext.UserId);

            await _roleRepository.Update(existingData, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _roleRepository.GetById(id, cancellationToken);
            await _roleRepository.Delete(entity, cancellationToken);
        }

    }
}