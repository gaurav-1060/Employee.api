
using Employee.api.Models;

namespace Employee.api.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        Task <List<Department>> GetAllDepartmentsAsync();
        Task <Department> GetDepartmentByIdAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
        Task AddDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);

    }
}
