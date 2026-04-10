using Employee.api.Dtos.Designations;

namespace Employee.api.Services.Interfaces
{
    public interface IDesignationService
    {
        Task<List<DesignationResponseDto>> GetAllDesignationsAsync();
        Task<DesignationResponseDto?> GetDesignationByIdAsync(int id);

        Task CreateDesignationAsync(CreateDesignationDto dto);
        Task UpdateDesignationAsync(UpdateDesignationDto dto);

        Task DeleteDesignationAsync(int id);
    }
}