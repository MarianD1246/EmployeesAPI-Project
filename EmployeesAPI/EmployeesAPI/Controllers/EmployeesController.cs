#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeesAPI;
using EmployeesAPI.Model;
using EmployeesAPI.Services;

namespace EmployeesAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employee = await _context.Employees.Select(x => Utilities.EmployeeToDTO(x)).ToListAsync();
            return employee;
        }

        // GET: api/Employees/id/5
        //[HttpGet("id/{id:int:min(1)}")]
        //public async Task<ActionResult<Employee>> GetEmployee(int id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return employee;
        //}

        // GET: api/Employees/id/5 NEW METHOD TEST
        [HttpGet("id/")]
        public async Task<ActionResult<Employee>> GetEmployee()
        {
            int id = Int32.Parse(HttpContext.Request.Query["id"]);
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET Employees by Surname
        [HttpGet("name_search/{lastName}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByName(string lastName)
        {
            var employee = await _context.Employees.Where(e => e.LastName == lastName).OrderBy(e => e.FirstName).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET Employee by Full name
        [HttpGet("name_search/{lastName}/{firstName}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByFullName(string lastName, string firstName)
        {
            var employee = await _context.Employees.Where(e => e.LastName == lastName && e.FirstName == firstName).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync(); 

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET Employee by Job Title
        [HttpGet("jobtitle_search/{jobTitle}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByJobTitle(string jobTitle)
        {
            var employee = await _context.Employees.Where(e => e.Title == jobTitle.Replace('-',' ')).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET: api/employees/city/London 
        [HttpGet("city/{city}")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesByCity(string city)
        {
            var employee = await _context.Employees.Where(e => e.City == city).Select(e => Utilities.EmployeeToDTO(e)).ToListAsync();
            return employee; 
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
