using Employee.api.Dtos.Designations;
using Employee.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Employee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationMasterController : ControllerBase
    {
        private readonly IDesignationService _service;

        public DesignationMasterController(IDesignationService service)
        {
            _service = service;
        }

        // GET all designations
        [HttpGet]
        public async Task<IActionResult> GetAllDesignations()
        {
            var result = await _service.GetAllDesignationsAsync();
            return Ok(result);
        }

        // GET designation by ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var result = await _service.GetDesignationByIdAsync(id);
            return Ok(result);
        }

        // ADD designation
        [HttpPost]
        public async Task<IActionResult> AddDesignation([FromBody] CreateDesignationDto dto)
        {
            await _service.CreateDesignationAsync(dto);
            return StatusCode(201, "Designation created successfully");
        }

        // UPDATE designation
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDesignation(int id, [FromBody] UpdateDesignationDto dto)
        {
            await _service.UpdateDesignationAsync(id, dto);
            return Ok("Designation updated successfully");
        }

        // DELETE designation
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            await _service.DeleteDesignationAsync(id);
            return Ok("Designation deleted successfully");
        }
    }
}