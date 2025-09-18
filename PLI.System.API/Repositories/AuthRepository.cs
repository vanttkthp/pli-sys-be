using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PLI.System.API.Data;
using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using System.Threading.Tasks;

namespace PLI.System.API.Repositories
{
    //public class AuthRepository : BaseRepository<User>, IAuthRepository
    //{
    //    private readonly SignInManager<User> _signInManager;
    //    private readonly UserManager<User> _userManager;

    //    public AuthRepository(ApplicationDbContext dbContext,
    //                          UserManager<User> userManager,
    //                          SignInManager<User> signInManager)
    //        : base(dbContext)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    public async Task<ResponseViewModel<UserViewModel>> Login(string employeeId, string password)
    //    {
    //        // Find user by employeeId
    //        var user = await _userManager.Users
    //            .FirstOrDefaultAsync(u => u.EmployeeId == employeeId);

    //        if (user == null || !user.IsActive)
    //        {
    //            return new ResponseViewModel<UserViewModel>
    //            {
    //                Success = false,
    //                Message = "Invalid employee ID or inactive user."
    //            };
    //        }

    //        // Check password and sign in
    //        var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

    //        if (result.Succeeded)
    //        {
    //            return new ResponseViewModel<UserViewModel>
    //            {
    //                Success = true,
    //                Data = new UserViewModel
    //                {
    //                    //Id = user.Id,
    //                    EmployeeId = user.EmployeeId
    //                }
    //            };
    //        }

    //        return new ResponseViewModel<UserViewModel>
    //        {
    //            Success = false,
    //            Message = "Invalid password."
    //        };
    //    }

    //    public async Task Logout()
    //    {
    //        await _signInManager.SignOutAsync();
    //    }
    //}
}
