using System.ComponentModel.DataAnnotations;

namespace PLI.System.API.Entities.General
{
    public class Attendant : Base
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public string? JobDescription { get; set; }
        public string? AttendanceTime { get; set; }
        public bool? Parttime { get; set; }
        public bool? Fulltime { get; set; }
        public int? Rank { get; set; }
        public string? Email { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? ScheduleId { get; set; }
    }
}
