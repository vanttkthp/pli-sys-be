using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.Business
{
    public class LoginViewModel
    {
        [Required, StringLength(20, MinimumLength = 2)]
        public string? EmployeeId { get; set; }

        [Required, StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}