using PLI.System.API.Entities.General;
using PLI.System.API.Mapper.Dto;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IAuthServices
    {
        Task<string> LoginAsync(LoginDto dto);
        Task LogoutAsync(string email);
        Task<bool> CheckLoginStatusAsync(string email);
    }
}
