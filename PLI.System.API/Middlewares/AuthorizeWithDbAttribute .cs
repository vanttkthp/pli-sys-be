using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PLI.System.API.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLI.System.API.Middlewares
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeWithDbAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;

            var config = httpContext.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration;
            var db = httpContext.RequestServices.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("Missing JWT token");
                return;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(config["AppSettings:Jwt:Key"]);

                // Validate chữ ký và issuer
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = config["AppSettings:Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = config["AppSettings:Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Check DB
                var dbToken = await db.UserTokens.FirstOrDefaultAsync(t => t.AccessToken == token);
                if (dbToken == null || dbToken.ExpiredAt < DateTime.Now)
                {
                    context.Result = new UnauthorizedObjectResult("Token expired or not found in DB");
                    return;
                }
            }
            catch
            {
                context.Result = new UnauthorizedObjectResult("Invalid JWT token");
            }
        }
    }
}
