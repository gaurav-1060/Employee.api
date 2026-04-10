using System.ComponentModel.DataAnnotations;

namespace Employee.api.Dtos.Departments
{
    public class DepartmentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
