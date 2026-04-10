
using Employee.api.Models;

namespace Employee.api.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task <List<Department>> GetAllDepartmentsAsync();
        Task <Department?> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
        Task UpdateDepartmentAsync(Department department);
      
    }
}
