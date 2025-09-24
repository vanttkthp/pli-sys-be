namespace PLI.System.API.Mapper.Dto
{
    public class RegisterUserDto
    {
        public string FullName { get; set; }
        public string EmployeeId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Organization { get; set; }
        public string? JobDescription { get; set; }
    }
}
