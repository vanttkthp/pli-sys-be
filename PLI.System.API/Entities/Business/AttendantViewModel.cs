namespace PLI.System.API.Entities.Business
{
    public class AttendantViewModel
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? Organization { get; set; }
        public string? AttendanceTime { get; set; }
        public bool? Parttime { get; set; }
        public bool? Fulltime { get; set; }
        public string? EmployeeId { get; set; }
        public string? JobDescription { get; set; }
    }

    public class AttendantCreateViewModel
    {
        public string? FullName { get; set; }
        public string? Organization { get; set; }
        public string? AttendanceTime { get; set; }
        public bool? Parttime { get; set; }
        public bool? Fulltime { get; set; }
        public string? EmployeeId { get; set; }
        public string? JobDescription { get; set; }
        public string? TeamId { get; set; }
        public string? ScheduleId { get; set; }
    }
}
