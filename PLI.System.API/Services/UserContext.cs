using PLI.System.API.Interfaces.IServices;

namespace PLI.System.API.Services
{
    public class UserContext : IUserContext
    {
        public string UserId { get; set; }
    }
}