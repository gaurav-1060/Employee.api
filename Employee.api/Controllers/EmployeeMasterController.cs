using Employee.api.Dtos.Employees;
using Employee.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeMasterController(IEmployeeService service)
        {
            _service = service;
        }

        // GET all employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _service.GetAllEmployeesAsync();
            return Ok(result);
        }

        // GET employee by Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _service.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        // CREATE employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        {
            await _service.CreateEmployeeAsync(dto);
            return StatusCode(201, "Employee created successfully");
        }

        // UPDATE employee
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto dto)
        {
            await _service.UpdateEmployeeAsync(id, dto);
            return Ok("Employee updated successfully");
        }

        // DELETE employee
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _service.DeleteEmployeeAsync(id);
            return Ok("Employee deleted successfully");
        }
    }
}