using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.api.Model
{
    [Table("DepartmentTbl")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }




    }
}
