using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.General
{
    //Base class for entities common properties
    public class Base
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();  // Tạo UUID mặc định
        public int? EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}