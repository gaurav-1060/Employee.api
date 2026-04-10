using Employee.api.Model;
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
            var deptList = _context.Departments.ToList();
            return Ok(deptList);
        }

        // Add Department.
        [HttpPost("AddDepartment")]
        public IActionResult AddDepaartment([FromBody] Department dept)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return Ok("Department is Added Successfully !");

        }
        

        // Update the department.
        [HttpPut("UpdateDepartment")]
        public IActionResult UpdateDepartment([FromBody] Department dept)
        {
            var existingDept = _context.Departments.Find(dept.Id);
            if(existingDept == null)
            {
                return NotFound("Department is not present.");

            }

            existingDept.Name = dept.Name;
            existingDept.IsActive = dept.IsActive;

            _context.SaveChanges();
            return Ok("Department is upsdated Successfully. ");
        }

        //Delete the Department.
        [HttpDelete("DeleteDepartment/{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var existingDept = _context.Departments.Find(id);
            if(existingDept == null)
            {
                return NotFound("Departmetn is not present.");
            }

            _context.Departments.Remove(existingDept);
            _context.SaveChanges();
            return Ok("Department is deleted successfully.");

        }

    }
}
