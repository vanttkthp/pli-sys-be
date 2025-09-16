using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.General
{
    public class Role : Base<int>
    {
        [Required, StringLength(maximumLength: 10, MinimumLength = 2)]
        public required string Code { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}