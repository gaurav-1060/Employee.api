using Employee.api.Dtos.Departments;
using Employee.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DepartmentMasterController(EmployeeDbContext context)
        {
            _context = context;
        }

        // Read all departments from the table.
        [HttpGet("GetAllDepartment")]
        public IActionResult GetDepartment()
        {
            var deptList = _context.Departments
                                   .Select(d => new DepartmentResponseDto
                                   {
                                       Id = d.Id,
                                       Name = d.Name,
                                       IsActive = d.IsActive,
                                   }).ToList();
            return Ok(deptList);
        }

        // Add Department.
        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment([FromBody] CreateDepartmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = new Department()
            {
                Name = dto.Name,
                IsActive = dto.IsActive

            };
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok("Department is Added Successfully !");

        }
        

        // Update the department.
        [HttpPut("UpdateDepartment/{id:int}")]
        public IActionResult UpdateDepartment(int id,[FromBody] UpdateDepartmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingDept = _context.Departments.Find(id);

            if (existingDept == null)
            {
                return NotFound("Department is not present.");

            }

            existingDept.Name = dto.Name;
            existingDept.IsActive = dto.IsActive;

            _context.SaveChanges();
            return Ok("Department is updated Successfully. ");
        }

        //Delete the Department.
        [HttpDelete("DeleteDepartment/{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var existingDept = _context.Departments.Find(id);
            if(existingDept == null)
            {
                return NotFound("Department is not present.");
            }

            _context.Departments.Remove(existingDept);
            _context.SaveChanges();
            return Ok("Department is deleted successfully.");

        }

    }
}
