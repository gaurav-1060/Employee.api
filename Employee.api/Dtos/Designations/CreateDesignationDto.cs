using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.api.Dtos.Designations
{
    public class CreateDesignationDto
    {
      
        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
    }
}
