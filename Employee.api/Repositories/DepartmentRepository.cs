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

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);

            if (dept != null)
            {
                _context.Departments.Remove(dept);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            var dept = await _context.Departments.FindAsync(department.Id);

            if (dept != null)
            {
                dept.Name = department.Name;
                dept.IsActive = department.IsActive;

                await _context.SaveChangesAsync();
            }
        }
    }
}



