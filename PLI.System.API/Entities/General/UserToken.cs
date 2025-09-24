using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PLI.System.API.Entities.General
{
    [Index(nameof(UserEmail), IsUnique = true)]
    public class UserToken : Base<int>
    {
        [Required]
        public required string UserEmail { get; set; }

        [Required]
        public required string AccessToken { get; set; }

        public DateTime ExpiredAt { get; set; }

        [ForeignKey("UserEmail")]
        public User User { get; set; }
    }
}
