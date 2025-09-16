using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PLI.System.API.Common;
using PLI.System.API.Entities.Business;
using PLI.System.API.Helpers;
using PLI.System.API.Interfaces.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PLI.System.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;







    }

}