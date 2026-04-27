using Employee.api.Models;
using Employee.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _context;

        public DepartmentRepository(EmployeeDbContext context)
        {
            _context = context;

        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();

        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Departments
                .AnyAsync(d => d.Name == name);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);

            if (dept == null)
                return;

             _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();

        }
    }
}



