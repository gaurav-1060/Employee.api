using Employee.api.Models;
using Employee.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Employees
                .AnyAsync(d => d.Name == name);
        }

        public async Task AddEmployeeAsync(EmployeeEntity employee)
        {
             _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeEntity employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if(emp == null) return;

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            
        }
    }
}