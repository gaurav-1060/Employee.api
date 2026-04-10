using System.ComponentModel.DataAnnotations;

namespace Employee.api.Dtos.Employees
{
    public class CreateEmployeeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(10), MinLength(10)]
        public string ContactNo { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required, MaxLength(6), MinLength(6)]
        public string PinCode { get; set; } = string.Empty;
        [MaxLength(10), MinLength(10)]
        public string AltContactNo { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int DesignationId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
