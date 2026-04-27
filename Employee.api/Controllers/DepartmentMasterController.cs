using Employee.api.Dtos.Departments;
using Employee.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Employee.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentMasterController(IDepartmentService service)
        {
            _service = service;
        }

        // GET all departments
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            var result = await _service.GetAllDepartmentsAsync();
            return Ok(result);
        }

        // GET department by ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _service.GetDepartmentByIdAsync(id);
            return Ok(result);
        }

        // ADD department
        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] CreateDepartmentDto dto)
        {
            await _service.CreateDepartmentAsync(dto);
            return Ok("Department is added successfully");
        }

        // UPDATE department
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto dto)
        {
            await _service.UpdateDepartmentAsync(id, dto);
            return Ok("Department updated successfully");
        }

        // DELETE department
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await _service.DeleteDepartmentAsync(id);
            return Ok("Department deleted successfully");
        }
    }
}