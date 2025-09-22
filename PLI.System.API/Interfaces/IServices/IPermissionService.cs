using PLI.System.API.Mapper.Dto;
using PLI.System.API.Mapper.Dto.Permission;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IPermissionService
    {
        Task<PagedResult<PermissionDto>> GetAllAsync(int page, int pageSize);
        Task<PermissionDto?> GetByIdAsync(int id);
        Task<PermissionDto> CreateAsync(CreatePermissionDto dto);
        Task<PermissionDto?> UpdateAsync(int id, UpdatePermissionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
