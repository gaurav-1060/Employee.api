using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.api.Dtos.Departments
{
    public class CreateDepartmentDto
    {
       
            [Required, MaxLength(50)]
            public string Name { get; set; } = string.Empty;
            public bool IsActive { get; set; }


    }
}
