using Microsoft.AspNetCore.Mvc;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;
using PLI.System.API.Middlewares;

namespace PLI.System.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthServices _authServices;

        public AuthController(ILogger<AuthController> logger, IAuthServices authServices)
        {
            _logger = logger;
            _authServices = authServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var token = await _authServices.LoginAsync(dto);
                return Ok(new
                {
                    message = "Login successful",
                    token = token
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [HttpPost("logout")]
        //[AuthorizeWithDb]
        public async Task<IActionResult> Logout([FromQuery] string email)
        {
            try
            {
                await _authServices.LogoutAsync(email);
                return Ok(new { message = "Logout successful" });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("status")]
        public async Task<IActionResult> CheckStatus([FromQuery] string email)
        {
            var isLoggedIn = await _authServices.CheckLoginStatusAsync(email);
            return Ok(new { loggedIn = isLoggedIn });
        }
    }

}