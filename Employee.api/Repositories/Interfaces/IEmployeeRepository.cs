
using Employee.api.Models;

namespace Employee.api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task <List<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);

        Task DeleteEmployeeAsync(int id);

    }
}
