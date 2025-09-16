using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLI.System.API.Entities.General
{
    public class User : Base<int>
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
    }
}