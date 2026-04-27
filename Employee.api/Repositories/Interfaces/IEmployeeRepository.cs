
using Employee.api.Models;

namespace Employee.api.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task <List<EmployeeEntity>> GetAllEmployeesAsync();
        Task<EmployeeEntity> GetEmployeeByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task AddEmployeeAsync(EmployeeEntity employee);
        Task UpdateEmployeeAsync(EmployeeEntity employee);
        Task DeleteEmployeeAsync(int id);

    }
}
