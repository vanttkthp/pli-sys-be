using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.General
{
    public class Permission
    {
        public int Id { get; set; }
        public string HttpMethod { get; set; }  
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        // Quan hệ với User
        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
