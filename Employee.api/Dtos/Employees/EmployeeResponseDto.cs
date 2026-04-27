using System.ComponentModel.DataAnnotations;

namespace Employee.api.Dtos.Employees
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
        public string? AltContactNo { get; set; }
        public string? Address { get; set; }
        public int DesignationId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
