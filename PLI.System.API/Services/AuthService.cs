using PLI.System.API.Entities.Business;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;

namespace PLI.System.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ResponseViewModel<UserViewModel>> Login(string userName, string password)
        {
            var result = await _authRepository.Login(userName, password);
            if (result.Success)
            {
                return new ResponseViewModel<UserViewModel>
                {
                    Success = true,
                    Message = "Login successful",
                    Data = result.Data
                };
            }
            else
            {
                return new ResponseViewModel<UserViewModel>
                {
                    Success = false,
                    Message = "Login failed",
                    Error = new ErrorViewModel
                    {
                        Code = "LOGIN_ERROR",
                        Message = "Incorrect username or password. Please check your credentials and try again."
                    }
                };
            }
        }

        public async Task Logout()
        {
            await _authRepository.Logout();
        }


    }
}