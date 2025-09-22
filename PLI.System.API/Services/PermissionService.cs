using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;
using PLI.System.API.Mapper.Dto.Permission;

namespace PLI.System.API.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repo;
        private readonly ApplicationDbContext _db;
        public PermissionService(IPermissionRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        public async Task<PagedResult<PermissionDto>> GetAllAsync(int page, int pageSize)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0) pageSize = 10;
            var query = _db.Permissions.AsQueryable();
            var totalRecords = await query.CountAsync();
            var data = await query
            .OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new PermissionDto
            {
                Id = x.Id,
                Name = x.Name,
                Path = x.Path,
                HttpMethod = x.HttpMethod
            })
            .ToListAsync();

            return new PagedResult<PermissionDto>
            {
                Page = page,
                PageSize = pageSize,
                TotalRecords = totalRecords,
                Data = data
            };
        }

        public async Task<PermissionDto?> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;

            return new PermissionDto
            {
                Id = p.Id,
                HttpMethod = p.HttpMethod,
                Path = p.Path,
                Description = p.Description,
                Name = p.Name
            };
        }

        public async Task<PermissionDto> CreateAsync(CreatePermissionDto dto)
        {
            var entity = new Permission
            {
                HttpMethod = dto.HttpMethod,
                Path = dto.Path,
                Description = dto.Description,
                Name = dto.Name,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            await _repo.AddAsync(entity);

            return new PermissionDto
            {
                Id = entity.Id,
                HttpMethod = entity.HttpMethod,
                Path = entity.Path,
                Description = entity.Description,
                Name = entity.Name,
                IsActive = entity.IsActive
            };
        }

        public async Task<PermissionDto?> UpdateAsync(int id, UpdatePermissionDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            entity.HttpMethod = dto.HttpMethod;
            entity.Path = dto.Path;
            entity.Description = dto.Description;
            entity.Name = dto.Name;
            entity.UpdatedAt = DateTime.Now;
            entity.IsActive = dto.IsActive;
            await _repo.UpdateAsync(entity);

            return new PermissionDto
            {
                Id = entity.Id,
                HttpMethod = entity.HttpMethod,
                Path = entity.Path,
                Description = entity.Description,
                Name = entity.Name
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;
            await _repo.UpdateAsync(entity);
            entity.HttpMethod = entity.HttpMethod;
            entity.Path = entity.Path;
            entity.Description = entity.Description;
            entity.Name = entity.Name;
            entity.UpdatedAt = DateTime.Now;
            entity.IsActive = false;
            await _repo.UpdateAsync(entity);
            return true;
        }

        
    }
}
