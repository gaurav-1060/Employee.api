using System.ComponentModel.DataAnnotations;

namespace Employee.api.Dtos.Designations
{
    public class UpdateDesignationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
    }
}
