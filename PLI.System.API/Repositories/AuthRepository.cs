using Microsoft.AspNetCore.Identity;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;

namespace PLI.System.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthRepository(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ResponseViewModel<UserViewModel>> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !user.IsActive)
            {
                return new ResponseViewModel<UserViewModel>
                {
                    Success = false,
                };
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return new ResponseViewModel<UserViewModel>
                {
                    Success = true,
                    Data = new UserViewModel { Id = user.Id, EmployeeId = user.EmployeeId },
                };
            }
            else
            {
                return new ResponseViewModel<UserViewModel>
                {
                    Success = false
                };
            }

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

    }

}