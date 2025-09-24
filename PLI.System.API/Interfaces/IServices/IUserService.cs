using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterUserDto dto);
        Task<User?> GetByEmailAsync(string email);
    }
}