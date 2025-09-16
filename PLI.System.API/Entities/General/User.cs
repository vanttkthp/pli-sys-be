using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLI.System.API.Entities.General
{
    public class User : Base<int>
    {
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public required string FullName { get; set; }
        [Required]
        public required string EmployeeId { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public bool IsActive { get; set; }
        //[Required]
        //public int RoleId { get; set; }
        //[ForeignKey(nameof(RoleId))]
        //public required Role Role { get; set; }
    }
}