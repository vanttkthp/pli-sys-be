
using PLI.System.API.Entities.Business;

namespace PLI.System.API.Interfaces.IRepositories
{
    public interface IAuthRepository
    {

        Task<ResponseViewModel<UserViewModel>> Login(string employeeId, string password);
        Task Logout();
    }
}