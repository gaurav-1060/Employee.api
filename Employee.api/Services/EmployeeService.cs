using Employee.api.CustomExceptions;
using Employee.api.Dtos.Employees;
using Employee.api.Models;
using Employee.api.Repositories.Interfaces;
using Employee.api.Services.Interfaces;

namespace Employee.api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository repository, ILogger<EmployeeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Fetching all employees");

            var employees = await _repository.GetAllEmployeesAsync();

            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                ContactNo = e.ContactNo,
                City = e.City,
                State = e.State,
                PinCode = e.PinCode,
                AltContactNo = e.AltContactNo,
                Address = e.Address,
                DesignationId = e.DesignationId
            }).ToList();
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id)
        {
            _logger.LogInformation("Fetching employee with ID {Id}", id);

            var employee = await _repository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                _logger.LogWarning("Employee with ID {Id} not found", id);
                throw new NotFoundException($"Employee with ID {id} not found");
            }

            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                ContactNo = employee.ContactNo,
                City = employee.City,
                State = employee.State,
                PinCode = employee.PinCode,
                AltContactNo = employee.AltContactNo,
                Address = employee.Address,
                DesignationId = employee.DesignationId
            };
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            _logger.LogInformation("Creating employee with Name {Name}", dto.Name);

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                _logger.LogWarning("Employee name is required");
                throw new ValidationException("Employee name is required");
            }

            bool exists = await _repository.ExistsByNameAsync(dto.Name);
            if (exists)
            {
                _logger.LogWarning("Employee with Name {Name} already exists", dto.Name);
                throw new ConflictException($"Employee with Name {dto.Name} already exists");
            }

            var employee = new EmployeeEntity
            {
                Name = dto.Name,
                ContactNo = dto.ContactNo,
                City = dto.City,
                State = dto.State,
                PinCode = dto.PinCode,
                AltContactNo = dto.AltContactNo,
                Address = dto.Address,
                DesignationId = dto.DesignationId
            };

            await _repository.AddEmployeeAsync(employee);

            _logger.LogInformation("Employee with Name {Name} created successfully", dto.Name);
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
        {
            _logger.LogInformation("Updating employee with ID {Id}", id);

            var existing = await _repository.GetEmployeeByIdAsync(id);

            if(existing == null)
            {
                _logger.LogWarning("Employee with ID {Id} not found", id);
                throw new NotFoundException($"Employee with ID {id} not found");
            }

            existing.Name = dto.Name;
            existing.ContactNo = dto.ContactNo;
            existing.City = dto.City;
            existing.State = dto.State;
            existing.AltContactNo = dto.AltContactNo;
            existing.Address = dto.Address;
            existing.DesignationId = dto.DesignationId;


            await _repository.UpdateEmployeeAsync(existing);

            _logger.LogInformation("Employee with ID {Id} updated successfully", id);
        }


        public async Task DeleteEmployeeAsync(int id)
        {
            _logger.LogInformation("Deleting employee with ID {Id}", id);

            var existing = await _repository.GetEmployeeByIdAsync(id);

            if (existing == null)
            {
                _logger.LogWarning("Employee with ID {Id} not found", id);
                throw new NotFoundException($"Employee with ID {id} not found");
            }

            await _repository.DeleteEmployeeAsync(id);

            _logger.LogInformation("Employee with ID {Id} deleted successfully", id);
        }
    }
}