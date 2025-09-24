using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace PLI.System.API.Entities.General
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(EmployeeId), IsUnique = true)]
    public class User : Base<int>
    public class User : Base
    {
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string FullName { get; set; }
        public bool IsActive { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string EmployeeId { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Password { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Email { get; set; }
        public string? Organization { get; set; }
        public string? JobDescription { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}