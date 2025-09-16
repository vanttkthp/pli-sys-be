using PLI.System.API.Entities.Business;

namespace PLI.System.API.Interfaces.IServices
{
    public interface IAuthService
    {
        Task<ResponseViewModel<UserViewModel>> Login(string employeeId, string password);
        Task Logout();
    }
}