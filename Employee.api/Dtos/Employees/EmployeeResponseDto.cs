using System.ComponentModel.DataAnnotations;

namespace Employee.api.Dtos.Employees
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string AltContactNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int DesignationId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
