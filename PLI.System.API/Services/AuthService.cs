using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PLI.System.API.Data;
using PLI.System.API.Entities.General;
using PLI.System.API.Interfaces.IRepositories;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PLI.System.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _db;
        public AuthService(IUserRepository userRepo, IConfiguration config, ApplicationDbContext db)
        {
            _userRepo = userRepo;
            _config = config;
            _db = db;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("Invalid email or password");
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("Invalid email or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            string? secretKey = _config["AppSettings:Jwt:Key"];
            if (String.IsNullOrEmpty(secretKey))
            {
                throw new Exception("Secret key not found");
            }
            var key = Encoding.UTF8.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FullName)
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["AppSettings:Jwt:Issuer"],
                Audience = _config["AppSettings:Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            // Save token to DB
            var userToken = new UserToken
            {
                UserEmail = dto.Email,
                AccessToken = accessToken,
                ExpiredAt = tokenDescriptor.Expires ?? DateTime.Now.AddHours(2),
                CreatedAt = DateTime.Now,
            };

            _db.UserTokens.Add(userToken);
            await _db.SaveChangesAsync();

            return accessToken;

        }

        public async Task LogoutAsync(string email)
        {
            var userToken = await _db.UserTokens.FirstOrDefaultAsync(t => t.UserEmail == email);
            if (userToken != null)
            {
                _db.UserTokens.Remove(userToken);
            }
            else
            {
                throw new Exception("user don't login");
            }
                //var expiredTokens = _db.UserTokens
                //    .Where(t => t.ExpiredAt < DateTime.Now);

                //_db.UserTokens.RemoveRange(expiredTokens);

            await _db.SaveChangesAsync();
        }

        public async Task<bool> CheckLoginStatusAsync(string email)
        {
            var userToken = await _db.UserTokens
                .FirstOrDefaultAsync(t => t.UserEmail == email);

            if (userToken == null)
                return false;

            return userToken.ExpiredAt > DateTime.UtcNow;
        }
    }
}
