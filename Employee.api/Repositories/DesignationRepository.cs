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

        public async Task<Designation?> GetDesignationByIdAsync(int id)
        {
            return await _context.Designations.FindAsync(id);
        }

        public async Task AddDesignationAsync(Designation designation)
        {
            await _context.Designations.AddAsync(designation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDesignationAsync(Designation designation)
        {
            var existing = await _context.Designations.FindAsync(designation.Id);

            if (existing != null)
            {
                existing.Name = designation.Name;
                existing.DepartmentId = designation.DepartmentId;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteDesignationAsync(int id)
        {
            var designation = await _context.Designations.FindAsync(id);

            if (designation != null)
            {
                _context.Designations.Remove(designation);
                await _context.SaveChangesAsync();
            }
        }
    }
}