namespace PLI.System.API.Mapper.Dto.Permission
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string HttpMethod { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
