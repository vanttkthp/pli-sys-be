using PLI.System.API.Common;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IMapper;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;


namespace PLI.System.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _repo.GetByEmailAsync(email);
        }

        public async Task<User> RegisterAsync(RegisterUserDto dto)
        {

            if (String.IsNullOrEmpty(dto.EmployeeId) || String.IsNullOrEmpty(dto.Email) || String.IsNullOrEmpty(dto.Password))
            {
                throw new Exception("EmployeeId, Email, Password is required");
            }
            // Check Valid email
            if (!StringUtlis.IsValidEmail(dto.Email))
            {
                throw new Exception("Email is not valid");
            }    

            // Check duplicate email
            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                FullName = dto.FullName,
                EmployeeId = dto.EmployeeId,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Email = dto.Email,
                Organization = dto.Organization,
                JobDescription = dto.JobDescription,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            return await _repo.AddAsync(user);
        }

        //Task<ResponseViewModel> IUserService.Create(UserCreateViewModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<ResponseViewModel> IUserService.Update(UserUpdateViewModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IUserService.Delete(int id, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

    }
}