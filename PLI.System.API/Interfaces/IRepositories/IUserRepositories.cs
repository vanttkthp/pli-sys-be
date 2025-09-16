using Microsoft.AspNetCore.Identity;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;

namespace PLI.System.API.Interfaces.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IdentityResult> Create(UserCreateViewModel model);
        Task<IdentityResult> Update(UserUpdateViewModel model);
        //Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
    }
}