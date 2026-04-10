namespace Employee.api.Dtos.Departments
{
    public class UpdateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
