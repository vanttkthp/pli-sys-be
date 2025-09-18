using Microsoft.AspNetCore.Identity;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;

namespace PLI.System.API.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<int> Create(UserCreateViewModel model);
        Task<int> Update(UserUpdateViewModel model);
        //Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
    }
}