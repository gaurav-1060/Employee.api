using Employee.api.Dtos.Departments;

namespace Employee.api.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);

        Task CreateDepartmentAsync(CreateDepartmentDto dto);
        Task UpdateDepartmentAsync(UpdateDepartmentDto dto);

        Task DeleteDepartmentAsync(int id);
    }
}