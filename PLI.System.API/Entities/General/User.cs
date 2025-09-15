using Microsoft.AspNetCore.Identity;

namespace PLI.System.API.Entities.General
{
    public class User : Base<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
    }
}
