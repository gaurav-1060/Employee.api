namespace Employee.api.Dtos.Designations
{
    public class DesignationResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
