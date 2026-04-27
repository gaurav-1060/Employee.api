using Employee.api.Models;
using Employee.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.api.Repositories
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly EmployeeDbContext _context;

        public DesignationRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Designation>> GetAllDesignationsAsync()
        {
            return await _context.Designations.ToListAsync();
        }

        public async Task<Designation> GetDesignationByIdAsync(int id)
        {
            return await _context.Designations.FindAsync(id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Designations
                .AnyAsync(d => d.Name == name);
        }
        public async Task AddDesignationAsync(Designation designation)
        {
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDesignationAsync(Designation designation)
        {
             _context.Designations.Update(designation);
             await _context.SaveChangesAsync();
          
        }

        public async Task DeleteDesignationAsync(int id)
        {
            var designation = await _context.Designations.FindAsync(id);

            if (designation == null) return;

             _context.Designations.Remove(designation);
             await _context.SaveChangesAsync();

        }
    }
}