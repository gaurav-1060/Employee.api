using Employee.api.Models;

namespace Employee.api.Repositories.Interfaces
{
    public interface IDesignationRepository
    {
         Task <List<Designation>> GetAllDesignationsAsync();
         Task<Designation> GetDesignationByIdAsync(int id);
         Task<bool> ExistsByNameAsync(string name);
         Task AddDesignationAsync(Designation designation);
         Task  UpdateDesignationAsync(Designation designation);
         Task  DeleteDesignationAsync(int id);
    }
}