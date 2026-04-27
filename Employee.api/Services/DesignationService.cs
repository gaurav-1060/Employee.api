using Employee.api.Dtos.Designations;
using Employee.api.CustomExceptions;
using Employee.api.Repositories.Interfaces;
using Employee.api.Models;
using Employee.api.Services.Interfaces;

namespace Employee.api.Services
{
    public class DesignationService:IDesignationService
    {
        private readonly IDesignationRepository _repository;
        private readonly ILogger<DesignationService> _logger;

        public DesignationService(IDesignationRepository repository, ILogger<DesignationService> logger)
        {
            _repository = repository;
            _logger = logger;
            
        }

        public async Task<List<DesignationResponseDto>> GetAllDesignationsAsync()
        {
            _logger.LogInformation("Fetching all designations.");

            var designations = await _repository.GetAllDesignationsAsync();

            return designations.Select(des => new DesignationResponseDto
            {
                Id = des.Id,
                Name = des.Name,
                DepartmentId = des.DepartmentId
            }).ToList();
        }

        public async Task<DesignationResponseDto> GetDesignationByIdAsync(int id)
        {
            _logger.LogInformation("Fetching designation with Id {Id}", id);

            var designation = await _repository.GetDesignationByIdAsync(id);

            if(designation == null)
            {
                _logger.LogWarning("Designation with Id {Id} is not found", id);
                throw new NotFoundException($"Designation with Id {id} is not present");
            }

            _logger.LogInformation("Designation retrieved successfully");

            return new DesignationResponseDto
            {
                Id = designation.Id,
                Name = designation.Name,
                DepartmentId = designation.DepartmentId
            };
        }

        public async Task CreateDesignationAsync(CreateDesignationDto dto)
        {
            _logger.LogInformation("Creating designation with Name {Name}", dto.Name);

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                _logger.LogWarning("Designation name should not be null or empty");
                throw new ValidationException("Designation name should not be null or empty");
            }

            bool exist = await _repository.ExistsByNameAsync(dto.Name);
            if (exist)
            {
                _logger.LogWarning("Designation with Name {Name} is already present", dto.Name);
                throw new ConflictException($"Designation with Name {dto.Name} is already present");
            }

            var designation = new Designation
            {
                Name = dto.Name,
                DepartmentId = dto.DepartmentId
            };

            await _repository.AddDesignationAsync(designation);
            _logger.LogInformation("Designation with Name {Name} is created successfully", dto.Name);
        }

        public async Task UpdateDesignationAsync(int id, UpdateDesignationDto dto)
        {
            _logger.LogInformation("Updating designation with Id {Id}.", id);

            var designation = await _repository.GetDesignationByIdAsync(id);

            if(designation == null)
            {
                _logger.LogWarning("Designation with ID {Id} is not found", id);
                throw new NotFoundException($"Designation with Id {id} is not found");

            }

            designation.Name = dto.Name;
            designation.DepartmentId = dto.DepartmentId;

            await _repository.UpdateDesignationAsync(designation);

            _logger.LogInformation("Designation with Id {Id} is updated", id);


        }

        public async Task DeleteDesignationAsync(int id)
        {
            _logger.LogInformation("Deleting designation with Id {Id}", id);

            var designation = await _repository.GetDesignationByIdAsync(id);

            if(designation == null)
            {
                _logger.LogWarning("Designation with Id {Id} is not found", id);
                throw new NotFoundException($"Designation with Id {id} is not found");
            }

             await _repository.DeleteDesignationAsync(id);

            _logger.LogInformation("Designation with Id {id} is deleted",id);
        }
    }
}




