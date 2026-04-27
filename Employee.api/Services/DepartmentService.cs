using Employee.api.CustomExceptions;
using Employee.api.Dtos.Departments;
using Employee.api.Dtos.Designations;
using Employee.api.Models;
using Employee.api.Repositories.Interfaces;
using Employee.api.Services.Interfaces;

namespace Employee.api.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository repository, ILogger<DepartmentService> logger)
        {
            _repository = repository;
            _logger = logger;
            
        }

        public async Task<List<DepartmentResponseDto>> GetAllDepartmentsAsync()
        {
            _logger.LogInformation("Fetching all departments");

            var departments =  await _repository.GetAllDepartmentsAsync();

            return departments.Select(d => new DepartmentResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                IsActive = d.IsActive
            }).ToList();
        }

        public async Task<DepartmentResponseDto> GetDepartmentByIdAsync(int id)
        {
            _logger.LogInformation("Fetching department with ID {Id}",id);

            var dept = await _repository.GetDepartmentByIdAsync(id);

            if (dept == null)
            {
                _logger.LogWarning("Department with {Id} is not found",id);
                throw new NotFoundException($"Department with Id {id} not found");
            }

            _logger.LogInformation("Department retrieved successfully");

            return new DepartmentResponseDto
            {
                Id = dept.Id,
                Name = dept.Name,
                IsActive = dept.IsActive
            };

        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto dto)
        {
            _logger.LogInformation("Creating department with Name {Name}",dto.Name);

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                _logger.LogWarning("Department name should not be null");
                throw new ValidationException("Department name should not be null");

            }

            bool exist = await _repository.ExistsByNameAsync(dto.Name);
            if (exist)
            {
                _logger.LogWarning("Department of {Name} already exists",dto.Name);
                throw new ConflictException($"Department of name {dto.Name} is already present");
            }


            var dept = new Department
            {
                Name = dto.Name,
                IsActive = dto.IsActive
            };

            await _repository.AddDepartmentAsync(dept);

            _logger.LogInformation("Department {Name} created successfully", dto.Name);

        }

        public async Task UpdateDepartmentAsync(int id, UpdateDepartmentDto dto)
        {
            _logger.LogInformation("Updating department with ID {Id}", id);

            var department = await _repository.GetDepartmentByIdAsync(id);

            if (department == null)
            {
                _logger.LogWarning("Department with ID {Id} not found", id);
                throw new NotFoundException($"Department with ID {id} not found");
            }

            department.Name = dto.Name;
            department.IsActive = dto.IsActive;

              await _repository.UpdateDepartmentAsync(department);

            _logger.LogInformation("Department updated successfully");
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            _logger.LogInformation("Deleting Department with ID {Id}",id);

            var department = await _repository.GetDepartmentByIdAsync(id);

            if (department == null)
            {
                _logger.LogWarning("Department with ID {Id} not found", id);
                throw new NotFoundException($"Department with ID {id} not found");

            }

            await _repository.DeleteDepartmentAsync(id);
            _logger.LogInformation("Department with Id {Id} deleted successfully", id);


        }


    }
}
