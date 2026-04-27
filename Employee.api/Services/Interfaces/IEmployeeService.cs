using Employee.api.Dtos.Employees;

namespace Employee.api.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDto>> GetAllEmployeesAsync();
        Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(CreateEmployeeDto dto);
        Task UpdateEmployeeAsync(int id,UpdateEmployeeDto dto);
        Task DeleteEmployeeAsync(int id);
    }
}