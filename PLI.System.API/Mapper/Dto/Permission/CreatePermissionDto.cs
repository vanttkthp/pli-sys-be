using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Mapper.Dto.Permission
{
    public class CreatePermissionDto
    {
        [Required]
        public string HttpMethod { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
