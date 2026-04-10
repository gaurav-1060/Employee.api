using Employee.api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationMasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DesignationMasterController(EmployeeDbContext context)
        {
            _context = context;
            
        }

        [HttpGet("GetAllDesignations")]
        public IActionResult GetDesignations()
        {
            var designations = _context.Designations.ToList();
            _context.SaveChanges();
            return Ok(designations);
        }

        [HttpPost("AddDesignation")]
        public IActionResult AddDesignation([FromBody] Designation des)
        {

            _context.Designations.Add(des);
            _context.SaveChanges();
            return Ok("Designation is added successfully.");

        }

        [HttpPut("UpdateDesignation")]
        public IActionResult UpdateDesignation(Designation des)
        {
            var designation = _context.Designations.Find(des.Id);
            if(designation == null)
            {
                return BadRequest();
            }

            designation.Name = des.Name;
            designation.DepartmentId = des.DepartmentId;
            _context.SaveChanges();

            return Ok("Designation is updated successfully.");

        }

        [HttpDelete("DeleteDesignation/{id:int}")]
        public IActionResult DeleteDesignation(int id )
        {
            var designation = _context.Designations.Find(id);
            if(designation == null)
            {
                return BadRequest();
            }

            _context.Designations.Remove(designation);
            _context.SaveChanges();
            return Ok("Designation is deleted successfully.");
        }



    }
}
