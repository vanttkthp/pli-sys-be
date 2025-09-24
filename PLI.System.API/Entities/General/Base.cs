using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.General
{
    //Base class for entities common properties
    public class Base
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();  // Tạo UUID mặc định

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}