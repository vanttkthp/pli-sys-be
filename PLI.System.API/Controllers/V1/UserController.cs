using Microsoft.AspNetCore.Mvc;
using PLI.System.API.Interfaces.IServices;
using PLI.System.API.Mapper.Dto;

namespace PLI.System.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                var user = await _userService.RegisterAsync(dto);
                return Ok(new
                {
                    message = "User registered successfully.",
                    data = new
                    {
                        user.Id,
                        user.FullName,
                        user.Email,
                        user.EmployeeId,
                        user.Organization,
                        user.JobDescription
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }

}